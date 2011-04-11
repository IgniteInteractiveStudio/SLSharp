using System;
using System.Collections.Generic;
using System.Reflection;
using IIS.SLSharp.Reflection;
using IIS.SLSharp.Shaders;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace IIS.SLSharp.Bindings.OpenTK
{

    public static class SLSharp
    {
        public static void Init()
        {
            Binding.Register(Handlers);
        }

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

        #region Uniform Local Storage
        private static Vector2 _f2;
        private static Vector3 _f3;
        private static Vector4 _f4;
        private static Vector2d _d2;
        private static Vector3d _d3;
        private static Vector4d _d4;
        private static Matrix4 _f4X4;

        public static ShaderDefinition.vec2 ToVector2F(this Vector2 v)
        { _f2 = v; return null; }

        public static ShaderDefinition.vec3 ToVector3F(this Vector3 v)
        { _f3 = v; return null; }

        public static ShaderDefinition.vec4 ToVector4F(this Vector4 v)
        { _f4 = v; return null; }

        public static ShaderDefinition.dvec2 ToVector2D(this Vector2d v)
        { _d2 = v; return null; }

        public static ShaderDefinition.dvec3 ToVector3D(this Vector3d v)
        { _d3 = v; return null; }

        public static ShaderDefinition.dvec4 ToVector4D(this Vector4d v)
        { _d4 = v; return null; }

        public static ShaderDefinition.mat4 ToMatrix4F(this Matrix4 v)
        { _f4X4 = v; return null; }

        #endregion


        public static int GetLocation(int program, string name)
        {
            return GL.GetUniformLocation(program, name);
        }

        public static void Uniform1F(int location, float value)
        {
            GL.Uniform1(location, value);
        }

        public static void Uniform2F(int location)
        {
            GL.Uniform2(location, ref _f2);
        }

        public static void Uniform3F(int location)
        {
            GL.Uniform3(location, ref _f3);
        }

        public static void Uniform4F(int location)
        {
            GL.Uniform4(location, ref _f4);
        }

        public static void Uniform1D(int location, double value)
        {
            GL.Uniform1(location, value);
        }

        public static void Uniform2D(int location)
        {
            GL.Uniform2(location, _d2.X, _d2.Y);
        }

        public static void Uniform3D(int location)
        {
            GL.Uniform3(location, _d3.X, _d3.Y, _d3.Z);
        }

        public static void Uniform4D(int location)
        {
            GL.Uniform4(location, _d4.X, _d4.Y, _d4.Z, _d4.W);
        }

        public static void UniformMatrix4X4(int location)
        {
            GL.UniformMatrix4(location, false, ref _f4X4);
        }

        public static void UniformSampler(int location)
        {
            GL.Uniform1(location, ShaderDefinition.Sampler.value);
        }
    }

    
}
