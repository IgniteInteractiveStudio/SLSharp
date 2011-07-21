using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            ilgen.Emit(OpCodes.Call, link);
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

        private PropertyInfo DefineInput(Expression input, string name)
        {
            var type = input.Type;

            // define a uniform we use to pass input to
            var ctor = typeof(UniformAttribute).GetConstructor(Type.EmptyTypes);
            var uniformAttrib = new CustomAttributeBuilder(ctor, new object[] { });

            var uniformProp = _type.DefineProperty(name, PropertyAttributes.None, type, Type.EmptyTypes);
            uniformProp.SetCustomAttribute(uniformAttrib);

            var setter = _type.DefineMethod("set_" + uniformProp.Name, MethodAttributes.Public | MethodAttributes.Abstract | MethodAttributes.Virtual | MethodAttributes.NewSlot);
            var getter = _type.DefineMethod("get_" + uniformProp.Name, MethodAttributes.Public | MethodAttributes.Abstract | MethodAttributes.Virtual | MethodAttributes.NewSlot);
            getter.SetReturnType(type);
            setter.SetParameters(new[] { type });

            uniformProp.SetSetMethod(setter);
            uniformProp.SetGetMethod(getter);

            return uniformProp;
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

        public void DefineFragmentBody(Expression exp)
        {
            if (exp is MethodCallExpression)
            {
                var call = (MethodCallExpression)exp;

                // required for the output setfld below
                _fragmentBody.Emit(OpCodes.Ldarg_0);

                // load arguments to stack
                for (var i = 0; i < call.Arguments.Count; i++)
                {
                    var arg = call.Arguments[i];
                    var input = DefineInput(arg, "input" + i);
                    var getter = input.GetGetMethod();

                    _fragmentBody.Emit(OpCodes.Ldarg_0);
                    _fragmentBody.Emit(OpCodes.Callvirt, getter);
                }

                // call the test method
                _fragmentBody.Emit(OpCodes.Call, call.Method);

                // convert the result to a vec4
                _fragmentBody.Emit(OpCodes.Newobj, typeof(ShaderDefinition.vec4).GetConstructor(new[] { typeof(float) }));

                // and store it to the output
                _fragmentBody.Emit(OpCodes.Stfld, _output);

                // finally ret
                _fragmentBody.Emit(OpCodes.Ret);
            }
            else
            {
                throw new NotImplementedException("Unit testing currently only supports simple expressions");
            }             
        }

    }
}