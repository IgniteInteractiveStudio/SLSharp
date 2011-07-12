using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using IIS.SLSharp.Annotations;
using IIS.SLSharp.Shaders;

namespace IIS.SLSharp.Examples.Tests
{
    internal sealed class ShaderBuilder
    {
        private readonly TypeBuilder _type;

        private ILGenerator _vertexBody;

        private ILGenerator _fragmentBody;

        private FieldBuilder _output;

        public ShaderBuilder(TypeBuilder type)
        {
            _type = type;

            DefineConstructor();
            DefineVertexMain();
            DefineFragmentMain();
            DefineOutput();
        }

        #region DefineConstructor

        private void DefineConstructor()
        {
            var shaderType = typeof(Shader);
            var cctor = _type.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, Type.EmptyTypes);
            var link = shaderType.GetMethod("Link", BindingFlags.NonPublic | BindingFlags.Instance,
                                            null, new[] { typeof(Shader[]), typeof(int) }, null);
            var baseCtor = shaderType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic,
                                                     null, Type.EmptyTypes, null);

            var ilgen = cctor.GetILGenerator();
            ilgen.Emit(OpCodes.Ldarg_0);
            ilgen.Emit(OpCodes.Call, baseCtor);
            ilgen.Emit(OpCodes.Ldarg_0);
            ilgen.Emit(OpCodes.Ldnull); // link no additional shaders
            ilgen.Emit(OpCodes.Ldc_I4, 130); // compile v130 shader
            ilgen.EmitCall(OpCodes.Call, link, null);
            ilgen.Emit(OpCodes.Ret);
        }

        #endregion

        #region DefineVertexMain

        private void DefineVertexMain()
        {
            // define [VertexShader(entrypoint = true)]
            var ctor = typeof(VertexShaderAttribute).GetConstructor(new[] { typeof(bool) });
            var entryAttrib = new CustomAttributeBuilder(ctor, new object[] { true });

            // define the shaders entypoint
            var entrypoint = _type.DefineMethod("VertexMain", MethodAttributes.Public, typeof(void), Type.EmptyTypes);
            entrypoint.SetCustomAttribute(entryAttrib);

            _vertexBody = entrypoint.GetILGenerator();
        }

        #endregion

        #region DefineFragmentMain

        private void DefineFragmentMain()
        {
            // define [FragmentShader(entrypoint = true)]
            var ctor = typeof(FragmentShaderAttribute).GetConstructor(new[] { typeof(bool) });
            var entryAttrib = new CustomAttributeBuilder(ctor, new object[] { true });

            // define the shaders entypoint
            var entrypoint = _type.DefineMethod("FragmentMain", MethodAttributes.Public, typeof(void), Type.EmptyTypes);
            entrypoint.SetCustomAttribute(entryAttrib);

            // emit fragmentxmain body
            _fragmentBody = entrypoint.GetILGenerator();
            
        }

        #endregion

        #region DefineOutput

        private void DefineOutput()
        {
            var ctor = typeof(FragmentOutAttribute).GetConstructor(new[] { typeof(UsageSemantic) });
            var fragmentOutAttrib = new CustomAttributeBuilder(ctor, new object[] { UsageSemantic.Color0 });
            _output = _type.DefineField("output", typeof(ShaderDefinition.vec4), FieldAttributes.Public);
            _output.SetCustomAttribute(fragmentOutAttrib);
        }

        #endregion

        #region DefineInput

        public void DefineInput(IList<Type> inputTypes)
        {
            // define a uniform we use to pass input to
            var ctor = typeof(UniformAttribute).GetConstructor(Type.EmptyTypes);
            var uniformAttrib = new CustomAttributeBuilder(ctor, new object[] { });
            for (var i = 0; i < inputTypes.Count; i++)
            {
                var inputType = inputTypes[i];
                var uniformProp = _type.DefineProperty("input" + i, PropertyAttributes.None, inputType, Type.EmptyTypes);
                uniformProp.SetCustomAttribute(uniformAttrib);

                var setter = _type.DefineMethod("set_" + uniformProp.Name, MethodAttributes.Public | MethodAttributes.Abstract | MethodAttributes.Virtual | MethodAttributes.NewSlot);
                var getter = _type.DefineMethod("get_" + uniformProp.Name, MethodAttributes.Public | MethodAttributes.Abstract | MethodAttributes.Virtual | MethodAttributes.NewSlot);
                getter.SetReturnType(inputType);
                setter.SetParameters(new[] { inputType });

                uniformProp.SetSetMethod(setter);
                uniformProp.SetGetMethod(getter);
            }
        }

        #endregion

        


        public void DefineVertexBody()
        {
            _vertexBody.Emit(OpCodes.Ldarg_0);
            _vertexBody.Emit(OpCodes.Ldc_R4, 0.0f);
            _vertexBody.Emit(OpCodes.Newobj, typeof(ShaderDefinition.vec4).GetConstructor(new[] { typeof(float) }));
            _vertexBody.Emit(OpCodes.Stfld, typeof(Shader).GetField("gl_Position", BindingFlags.Instance | BindingFlags.NonPublic));
            _vertexBody.Emit(OpCodes.Ret);
        }

        public void DefineFragmentBody()
        {
            _fragmentBody.Emit(OpCodes.Ldarg_0);
            _fragmentBody.Emit(OpCodes.Ldc_R4, 10.5f);
            _fragmentBody.Emit(OpCodes.Newobj, typeof(ShaderDefinition.vec4).GetConstructor(new[] { typeof(float) }));
            _fragmentBody.Emit(OpCodes.Stfld, _output);
            _fragmentBody.Emit(OpCodes.Ret);
        }

    }
}