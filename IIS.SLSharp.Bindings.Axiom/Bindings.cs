using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Axiom.Core;
using Axiom.Graphics;
using Axiom.Math;
using IIS.SLSharp.Annotations;
using IIS.SLSharp.Descriptions;
using IIS.SLSharp.Reflection;
using IIS.SLSharp.Shaders;
using IIS.SLSharp.Translation;
using IIS.SLSharp.Translation.GLSL;
using IIS.SLSharp.Translation.HLSL;

namespace IIS.SLSharp.Bindings.Axiom
{
    public enum ShaderLanguage
    {
        GLSL,
        HLSL,
        CG
    }

    sealed class SLSharpBinding: ISLSharpBinding
    {
        public SLSharpBinding(ITransform trans)
        {
            Transform = trans;
        }

        public Dictionary<ReflectionToken, MethodInfo> PassiveMethods
        {
            get { return SLSharp.Handlers; }
        }

        public ITransform Transform { get; private set; }

        #region Active Methods

        public void TexActivate(int textureUnit, object tex)
        {
            throw new NotImplementedException();
        }

        public void TexFinish(int textureUnit, object tex)
        {
            throw new NotImplementedException();
        }

        public void TexReset()
        {
            throw new NotImplementedException();
        }

        public object Compile(Shader shader, ShaderType type, SourceDescription source)
        {
            // just pass through source units as MOGRE forces us to merge the sourcecode
            return new System.Tuple<ShaderType, SourceDescription>(
                type, source);
        }

        private static int _shaderCounter;

        public IProgram Link(Shader shader, IEnumerable<object> u)
        {
            var units = u.Cast<System.Tuple<ShaderType, SourceDescription>>();

            var name = "SLSharp_" + _shaderCounter++;
            const string group = ResourceGroupManager.DefaultResourceGroupName;


            var frags = units.Where(x => x.Item1 == ShaderType.FragmentShader).Select(x => x.Item2);
            var verts = units.Where(x => x.Item1 == ShaderType.VertexShader).Select(x => x.Item2);

            var combinedFrags = frags.Aggregate(SourceDescription.Empty, (x, y) => x.Merge(y));
            var combinedVerts = verts.Aggregate(SourceDescription.Empty, (x, y) => x.Merge(y));

            var samplerRegs = 0;
            var samplers = new List<VariableDescription>();

            HighLevelGpuProgram ps = null;
            if (combinedFrags.Functions.Count > 0)
            {
                // init default regs
                foreach (var x in combinedFrags.Uniforms)
                {
                    if (!x.IsSampler() || x.DefaultRegister.HasValue)
                        continue;
                    x.DefaultRegister = samplerRegs++;
                    samplers.Add(x);
                }

                switch (SLSharp.Language)
                {
                    case ShaderLanguage.GLSL:
                        ps = HighLevelGpuProgramManager.Instance.CreateProgram(name + "_ps", group, "glsl", GpuProgramType.Fragment);
                        ps.Source = combinedFrags.ToGlsl(ShaderType.FragmentShader);
                        break;
                    case ShaderLanguage.HLSL:
                        ps = HighLevelGpuProgramManager.Instance.CreateProgram(name + "_ps", group, "hlsl", GpuProgramType.Fragment);
                        ps.SetParam("entry_point", "SLSharp_FragmentMain");
                        ps.SetParam("target", "ps_3_0");
                        ps.Source = combinedFrags.ToHlsl();
                        break;
                    case ShaderLanguage.CG:
                        ps = HighLevelGpuProgramManager.Instance.CreateProgram(name + "_ps", group, "cg", GpuProgramType.Fragment);
                        ps.SetParam("entry_point", "SLSharp_FragmentMain");
                        ps.SetParam("target", "ps_3_0");
                        ps.Source = combinedFrags.ToHlsl();
                        break;
                }
            }

            HighLevelGpuProgram vs = null;
            if (combinedVerts.Functions.Count > 0)
            {
                // init default regs
                foreach (var x in combinedVerts.Uniforms)
                {
                    if (!x.IsSampler() || x.DefaultRegister.HasValue)
                        continue;
                    x.DefaultRegister = samplerRegs++;
                    samplers.Add(x);
                }

                switch (SLSharp.Language)
                {
                    case ShaderLanguage.GLSL:
                        vs = HighLevelGpuProgramManager.Instance.CreateProgram(name + "_vs", group, "glsl", GpuProgramType.Vertex);
                        var vsSource = combinedVerts.ToGlsl(ShaderType.VertexShader);

                        foreach (var vin in combinedVerts.VertexIns)
                        {
                            var sem = SemanticToMogre(vin.Semantic);
                            vsSource = vsSource.Replace(vin.Name, sem);
                        }
                        vs.Source = vsSource;
                        break;
                    case ShaderLanguage.HLSL:
                        vs = HighLevelGpuProgramManager.Instance.CreateProgram(name + "_vs", group, "hlsl", GpuProgramType.Vertex);
                        vs.SetParam("entry_point", "SLSharp_VertexMain");
                        vs.SetParam("target", "vs_3_0");
                        vs.Source = combinedVerts.ToHlsl();
                        break;
                    case ShaderLanguage.CG:
                        vs = HighLevelGpuProgramManager.Instance.CreateProgram(name + "_vs", group, "cg", GpuProgramType.Vertex);
                        vs.SetParam("entry_point", "SLSharp_VertexMain");
                        vs.SetParam("target", "vs_3_0");
                        vs.Source = combinedVerts.ToHlsl();
                        break;
                }
            }

            var prog = new Program(name, vs, ps, samplers);

            if (SLSharp.Language == ShaderLanguage.GLSL)
            {
                if (vs != null)
                {
                    var pars = prog.Pass.VertexProgramParameters;
                    foreach (var x in combinedVerts.Uniforms)
                    {
                        if (!x.IsSampler())
                            continue;
                        pars.SetNamedConstant(x.Name, x.DefaultRegister.GetValueOrDefault());
                    }
                }

                if (ps != null)
                {
                    var pars = prog.Pass.FragmentProgramParameters;
                    foreach (var x in combinedFrags.Uniforms)
                    {
                        if (!x.IsSampler())
                            continue;
                        pars.SetNamedConstant(x.Name, x.DefaultRegister.GetValueOrDefault());
                    }
                }
            }

            return prog;
        }

        private string SemanticToMogre(UsageSemantic semantic)
        {
            switch (semantic)
            {
                case UsageSemantic.Position0:
                    return "vertex";
                case UsageSemantic.Normal0:
                    return "normal";
                case UsageSemantic.Texcoord0:
                    return "uv0";
                case UsageSemantic.Texcoord1:
                    return "uv1";
                case UsageSemantic.Texcoord2:
                    return "uv2";
                case UsageSemantic.Texcoord3:
                    return "uv3";
                case UsageSemantic.Texcoord4:
                    return "uv4";
                case UsageSemantic.Texcoord5:
                    return "uv5";
                case UsageSemantic.Texcoord6:
                    return "uv6";
                case UsageSemantic.Texcoord7:
                    return "uv7";
            }
            throw new SLSharpException(string.Format("Semantic not supported: {0}", semantic));
        }

        public void Initialize()
        {
            //_quad = new Quad();
        }

        public void Cleanup()
        {
            //_quad.Dispose();
            //_quad = null;
        }

        public void FullscreenQuad(int vertexLocation, bool positive)
        {
            throw new NotImplementedException();
            //_quad.Render(vertexLocation, positive);
        }

        #endregion
    }

    public class Program : IProgram
    {
        public static Program CurrentProgram;

        public static Dictionary<Material, Program> MatToProg = new Dictionary<Material, Program>();

        public readonly HighLevelGpuProgram VertexShader;

        public readonly HighLevelGpuProgram PixelShader;

        public readonly Material Material;
        private readonly Technique _tech;
        internal Pass Pass;

        private readonly Dictionary<string, TextureUnitState> _textureUnits = new Dictionary<string, TextureUnitState>();

        public Program(string name, HighLevelGpuProgram vs, HighLevelGpuProgram ps, 
            IEnumerable<VariableDescription> samplers)
        {
            VertexShader = vs;
            PixelShader = ps;

            LogManager.Instance.Write("VS:");
            LogManager.Instance.Write("================================================================================");
            LogManager.Instance.Write(vs.Source);
            LogManager.Instance.Write("PS:");
            LogManager.Instance.Write("================================================================================");
            LogManager.Instance.Write(ps.Source);

            var mm = MaterialManager.Instance;

            Material = (Material)mm.Create(name, "SLSharp");
            var mat = Material;
            mat.RemoveAllTechniques();
            _tech = mat.CreateTechnique();
            _tech.SchemeName = "SLSharp";
            _tech.RemoveAllPasses();
            Pass = _tech.CreatePass();
            if (vs != null)
                Pass.SetVertexProgram(vs.Name);
            if (ps != null)
                Pass.SetFragmentProgram(ps.Name);

            foreach (var s in samplers)
            {
                var tu = Pass.CreateTextureUnitState();
                tu.Name = s.Name;
                _textureUnits.Add(s.Name, tu);
            }

            Pass.LightingEnabled = false;
            mat.Load();

            MatToProg.Add(mat, this);
        }

        public void Activate()
        {
            CurrentProgram = this;
        }

        public void Finish()
        {
            CurrentProgram = null;
        }

        public int GetUniformIndex(string name)
        {
            var vpp = Pass.VertexProgramParameters;
            var vd = vpp.FindNamedConstantDefinition(name, false);
            if (vd != null)
                return vd.LogicalIndex;


            var fpp = Pass.FragmentProgramParameters;
            var fd = fpp.FindNamedConstantDefinition(name, false);
            if (fd != null)
                return (int)((uint)fd.LogicalIndex | 0x80000000);

            return -1;
            //throw new NotImplementedException();
        }

        public string GetUniformName(int idx)
        {
            throw new NotImplementedException();
        }

        public int GetAttributeIndex(string name)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Material.Dispose();
            //_tech.Dispose();
            //Pass.Dispose();            
            VertexShader.Dispose();
            PixelShader.Dispose();
            MatToProg.Remove(Material);
        }

        public void SetAuto(string name, GpuProgramParameters.AutoConstantType ac)
        {
            Pass.VertexProgramParameters.SetNamedAutoConstant(name, ac);
            //_pass.GetFragmentProgramParameters().SetNamedAutoConstant(name, ac);
        }

        public void SetAuto(string name, GpuProgramParameters.AutoConstantType ac, int extraInfo)
        {
            Pass.VertexProgramParameters.SetNamedAutoConstant(name, ac, extraInfo);
            //_pass.GetFragmentProgramParameters().SetNamedAutoConstant(name, ac);
        }

        public TextureUnitState Sampler(string name)
        {
            return _textureUnits[name];
        }
    }

    public static class SLSharp
    {
        public static void Init()
        {
            if (HighLevelGpuProgramManager.Instance.IsLanguageSupported("glsl"))
                Language = ShaderLanguage.GLSL;
            else if (HighLevelGpuProgramManager.Instance.IsLanguageSupported("hlsl"))
                Language = ShaderLanguage.HLSL;
            else if (HighLevelGpuProgramManager.Instance.IsLanguageSupported("cg"))
                Language = ShaderLanguage.CG;
            else
                throw new SLSharpException("Axiom neither supports GLSL nor HLSL nor CG");

            var trans = Language == ShaderLanguage.GLSL ? (ITransform)new GlslTransform() : new HlslTransform();

            Binding.Register(new SLSharpBinding(trans));

            MaterialManager.Instance.AddListener(x =>
            {
                if (x.OriginalMaterial.Group == "SLSharp")
                {
                    var prog = Program.MatToProg[x.OriginalMaterial];
                    prog.Activate();
                    return x.OriginalMaterial.GetTechnique(0);
                }
                return null;
            });

            ResourceGroupManager.Instance.CreateResourceGroup("SLSharp");
        }

        public static Material ToMaterial(this Shader shader)
        {
            var prog = (Program)shader.Program;
            return prog.Material;
        }

        public static Material CloneMaterial(this Shader shader, string newName)
        {
            var prog = (Program)shader.Program;
            var mat = prog.Material;
            var clone = mat.Clone(newName);
            Program.MatToProg.Add(clone, prog);
            return clone;
        }

        public static void SetAuto<T>(this Shader shader, Expression<Func<T>> loc,
            GpuProgramParameters.AutoConstantType ac)
        {
            var name = Shader.UniformName(loc);
            var prog = (Program)shader.Program;
            prog.SetAuto(name, ac);
        }

        public static void SetAuto<T>(this Shader shader, Expression<Func<T>> loc,
            GpuProgramParameters.AutoConstantType ac, int extraInfo)
        {
            var name = Shader.UniformName(loc);
            var prog = (Program)shader.Program;
            prog.SetAuto(name, ac, extraInfo);
        }

        public static TextureUnitState Sampler<T>(this Shader shader, Expression<Func<T>> loc)
        {

            var name = Shader.UniformName(loc);
            var prog = (Program)shader.Program;
            return prog.Sampler(name);
        }

        #region Passive Methods
        private static MethodInfo GetMethod(Action<int> a)
        {
            return a.Method;
        }

        private static MethodInfo GetMethod<T>(Action<int, T> a)
        {
            return a.Method;
        }

        internal static Dictionary<ReflectionToken, MethodInfo> Handlers = new Dictionary<ReflectionToken, MethodInfo>
                                                                               {
            {ReflectionToken.ShaderVec1Helper, GetMethod<float>(Uniform1F) },
            {ReflectionToken.ShaderVec2Helper, GetMethod(Uniform2F) },
            {ReflectionToken.ShaderVec3Helper, GetMethod(Uniform3F) },
            {ReflectionToken.ShaderVec4Helper, GetMethod(Uniform4F) },
            {ReflectionToken.ShaderDvec1Helper, GetMethod<double>(Uniform1D) },
            {ReflectionToken.ShaderDvec2Helper, GetMethod(Uniform2D) },
            {ReflectionToken.ShaderDvec3Helper, GetMethod(Uniform3D) },
            {ReflectionToken.ShaderDvec4Helper, GetMethod(Uniform4D) },
            {ReflectionToken.ShaderSamplerHelper, GetMethod(UniformSampler) },
            {ReflectionToken.ShaderUniformMatrix4X4Helper, GetMethod(UniformMatrix4X4) },
        };

        public static GpuProgramType ToMOGRE(this ShaderType type)
        {
            switch (type)
            {
                case ShaderType.FragmentShader:
                    return GpuProgramType.Fragment;
                case ShaderType.VertexShader:
                    return GpuProgramType.Vertex;
            }
            throw new SLSharpException("Unhandled shader type: " + type);
        }
        

        #region Uniform Local Storage

        internal struct UniformStorage
        {
            public Vector2 F2;
            public Vector3 F3;
            public Vector4 F4;
            public Matrix3 F3X3;
            public Matrix4 F4X4;
            public int Sampler;
        }

        // use ThreadStatic when multiple render contexts are planned
        // if speed is a concern cache with UniformStorage[64] or so
        // and access as UniformStorage[CurrentThreadID] as long the tid 
        // is < 64, otherwise fallback to TLS var
        //[ThreadStatic]
        private static UniformStorage _storage;

        public static ShaderLanguage Language { get; private set; }

        public static ShaderDefinition.vec2 ToVector2F(this Vector2 v)
        { _storage.F2 = v; return null; }

        public static ShaderDefinition.vec3 ToVector3F(this Vector3 v)
        { _storage.F3 = v; return null; }

        public static ShaderDefinition.vec4 ToVector4F(this Vector4 v)
        { _storage.F4 = v; return null; }

        public static ShaderDefinition.mat4 ToMatrix3F(this Matrix3 v)
        { _storage.F3X3 = v; return null; }
        
        public static ShaderDefinition.mat4 ToMatrix4F(this Matrix4 v)
        { _storage.F4X4 = v; return null; }

        public static ShaderDefinition.SamplerTmp ToSampler(this int v)
        { _storage.Sampler = v; return null; }

        #endregion


        public static int GetLocation(int program, string name)
        {
            throw new NotImplementedException();
            //return GL.GetUniformLocation(program, name);
        }

        private static GpuProgramParameters GetParams(ref int location)
        {
            if (location == -1)
                throw new NotImplementedException();
            if ((location & 0x80000000) == 0)
                return Program.CurrentProgram.Pass.VertexProgramParameters;
            location &= 0x7FFFFFFF;
            return Program.CurrentProgram.Pass.FragmentProgramParameters;
        }

        public static void Uniform1F(int location, float value)
        {
            GetParams(ref location).SetConstant(location, value);
        }

        public static void Uniform2F(int location)
        {
            throw new NotImplementedException();
        }

        public static void Uniform3F(int location)
        {
            GetParams(ref location).SetConstant(location, _storage.F3);
        }

        public static void Uniform4F(int location)
        {
            GetParams(ref location).SetConstant(location, _storage.F4);
        }

        public static void Uniform1D(int location, double value)
        {
            throw new NotImplementedException();
            //GL.Uniform1(location, value);
        }

        public static void Uniform2D(int location)
        {
            throw new NotImplementedException();
            //var d2L = _storage.D2;
            //GL.Uniform2(location, d2L.X, d2L.Y);
        }

        public static void Uniform3D(int location)
        {
            throw new NotImplementedException();
            //var d3L = _storage.D3;
            //GL.Uniform3(location, d3L.X, d3L.Y, d3L.Z);
        }

        public static void Uniform4D(int location)
        {
            throw new NotImplementedException();
            //var d4L = _storage.D4;
            //GL.Uniform4(location, d4L.X, d4L.Y, d4L.Z, d4L.W);
        }

        public static void UniformMatrix4X4(int location)
        {
            GetParams(ref location).SetConstant(location, _storage.F4X4);
        }

        public static void UniformDMatrix4X4(int location)
        {
            throw new NotImplementedException();
        }

        public static void UniformSampler(int location)
        {
            GetParams(ref location).SetConstant(location, _storage.Sampler);
        }
        #endregion
    }
}
