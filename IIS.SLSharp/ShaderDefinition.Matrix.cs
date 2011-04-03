using OpenTK;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedParameter.Local

namespace IIS.SLSharp
{
    public abstract partial class ShaderDefinition
    {
        public sealed class mat2
        {
            #region .net uniform glue

            internal static float []value = new float[2*2];

            public static implicit operator mat2(Matrix4 v)
            { 
                value[0] = v.M11; value[1] = v.M12;
                value[2] = v.M21; value[3] = v.M22; 
                return null; 
            }

            public static implicit operator mat2(Vector4 v)
            {
                value[0] = v.X; value[1] = v.Y;
                value[2] = v.Z; value[3] = v.W;
                return null; 
            }

            #endregion

            #region .ctor
            /// <summary>  Initialized all diogonal entries to scale </summary>
            public mat2(float scale) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat2(mat2x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat2(mat2x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat2(mat3x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat2(mat3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat2(mat3x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat2(mat4x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat2(mat4x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat2(mat4 m) { throw _invalidAccess; }

            public mat2(vec2 column1, vec2 column2) { throw _invalidAccess; }

            /// <summary>initialized the matrix with a vec4</summary>
            public mat2(vec4 compressedMatrix) { throw _invalidAccess; }

            #endregion

            /// <summary>
            /// retrieves the selected column as vector
            /// </summary>
            /// <param name="column">zero based column index</param>
            /// <returns></returns>
            public vec2 this[int column] 
            { 
                get { throw _invalidAccess; }
                set { throw _invalidAccess; }
            }
        }

        public sealed class mat2x3
        {
            #region .net uniform glue

            internal static float[] value = new float[2*3];

            public static implicit operator mat2x3(Matrix4 v)
            {                
                value[0] = v.M11; value[1] = v.M12;
                value[2] = v.M21; value[3] = v.M22;
                value[4] = v.M31; value[5] = v.M32;
                return null;
            }

            #endregion

            #region .ctor

            /// <summary>  Initialized all diogonal entries to scale </summary>
            public mat2x3(float scale) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat2x3(mat2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat2x3(mat2x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat2x3(mat3x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat2x3(mat3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat2x3(mat3x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat2x3(mat4x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat2x3(mat4x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat2x3(mat4 m) { throw _invalidAccess; }

            public mat2x3(vec3 column1, vec3 column2) { throw _invalidAccess; }

            #endregion

            public vec3 this[int column]
            {
                get { throw _invalidAccess; }
                set { throw _invalidAccess; }
            }
        }

        public sealed class mat2x4
        {
            #region .net uniform glue

            internal static float[] value = new float[2*4];

            public static implicit operator mat2x4(Matrix4 v)
            {
                value[0] = v.M11; value[1] = v.M12;
                value[2] = v.M21; value[3] = v.M22;
                value[4] = v.M31; value[5] = v.M32;
                value[6] = v.M31; value[7] = v.M32;
                return null;
            }

            #endregion

            #region .ctor

            /// <summary>  Initialized all diogonal entries to scale </summary>
            public mat2x4(float scale) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat2x4(mat2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat2x4(mat2x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat2x4(mat3x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat2x4(mat3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat2x4(mat3x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat2x4(mat4x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat2x4(mat4x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat2x4(mat4 m) { throw _invalidAccess; }

            public mat2x4(vec4 column1, vec4 column2) { throw _invalidAccess; }

            #endregion

            public vec4 this[int column]
            {
                get { throw _invalidAccess; }
                set { throw _invalidAccess; }
            }
        }

        public sealed class mat3x2
        {
            #region .net uniform glue

            internal static float[] value = new float[3*2];

            public static implicit operator mat3x2(Matrix4 v)
            {
                value[0] = v.M11; value[1] = v.M12; value[2] = v.M13;
                value[3] = v.M21; value[4] = v.M22; value[5] = v.M23;
                return null;
            }

            #endregion

            #region .ctor

            /// <summary>  Initialized all diogonal entries to scale </summary>
            public mat3x2(float scale) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat3x2(mat2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat3x2(mat2x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat3x2(mat2x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat3x2(mat3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat3x2(mat3x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat3x2(mat4x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat3x2(mat4x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat3x2(mat4 m) { throw _invalidAccess; }

            public mat3x2(vec2 column1, vec2 column2, vec2 column3) { throw _invalidAccess; }

            #endregion

            public vec2 this[int column]
            {
                get { throw _invalidAccess; }
                set { throw _invalidAccess; }
            }
        }

        public sealed class mat3
        {
            #region .net uniform glue

            internal static float[] value = new float[3*3];

            public static implicit operator mat3(Matrix4 v)
            {
                value[0] = v.M11; value[1] = v.M12; value[2] = v.M13;
                value[3] = v.M21; value[4] = v.M22; value[5] = v.M23;
                value[6] = v.M31; value[7] = v.M32; value[8] = v.M33;
                return null;
            }

            #endregion

            #region .ctor

            /// <summary>  Initialized all diogonal entries to scale </summary>
            public mat3(float scale) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat3(mat2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat3(mat2x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat3(mat2x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat3(mat3x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat3(mat3x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat3(mat4x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat3(mat4x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat3(mat4 m) { throw _invalidAccess; }

            public mat3(vec3 column1, vec3 column2, vec3 column3) { throw _invalidAccess; }

            #endregion

            public vec3 this[int column]
            {
                get { throw _invalidAccess; }
                set { throw _invalidAccess; }
            }
        }

        public sealed class mat3x4
        {
            #region .net uniform glue

            internal static float[] value = new float[3*4];

            public static implicit operator mat3x4(Matrix4 v)
            {
                value[0] = v.M11; value[1] = v.M12; value[2] = v.M13;
                value[3] = v.M21; value[4] = v.M22; value[5] = v.M23;
                value[6] = v.M31; value[7] = v.M32; value[8] = v.M33;
                value[9] = v.M41; value[10] = v.M42; value[11] = v.M43;
                return null;
            }

            #endregion

            #region .ctor

            /// <summary>  Initialized all diogonal entries to scale </summary>
            public mat3x4(float scale) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat3x4(mat2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat3x4(mat2x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat3x4(mat2x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat3x4(mat3x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat3x4(mat3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat3x4(mat4x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat3x4(mat4x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat3x4(mat4 m) { throw _invalidAccess; }

            public mat3x4(vec4 column1, vec4 column2, vec4 column3) { throw _invalidAccess; }

            #endregion

            public vec4 this[int column]
            {
                get { throw _invalidAccess; }
                set { throw _invalidAccess; }
            }
        }

        public sealed class mat4x2
        {
            #region .net uniform glue

            internal static float[] value = new float[4*2];

            public static implicit operator mat4x2(Matrix4 v)
            {
                value[0] = v.M11; value[1] = v.M12; value[2] = v.M13; value[3] = v.M14;
                value[4] = v.M21; value[5] = v.M22; value[6] = v.M23; value[7] = v.M24;
                return null;
            }

            #endregion

            #region .ctor

            /// <summary>  Initialized all diogonal entries to scale </summary>
            public mat4x2(float scale) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat4x2(mat2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat4x2(mat2x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat4x2(mat2x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat4x2(mat3x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat4x2(mat3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat4x2(mat3x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat4x2(mat4x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat4x2(mat4 m) { throw _invalidAccess; }

            public mat4x2(vec2 column1, vec2 column2, 
                vec2 column3, vec2 column4) { throw _invalidAccess; }

            #endregion

            public vec2 this[int column]
            {
                get { throw _invalidAccess; }
                set { throw _invalidAccess; }
            }    
        }

        public sealed class mat4x3
        {
            #region .net uniform glue

            internal static float[] value = new float[4*3];

            public static implicit operator mat4x3(Matrix4 v)
            {
                value[0] = v.M11; value[1] = v.M12; value[2] = v.M13; value[3] = v.M14;
                value[4] = v.M21; value[5] = v.M22; value[6] = v.M23; value[7] = v.M24;
                value[8] = v.M31; value[9] = v.M32; value[10] = v.M33; value[11] = v.M34;
                return null;
            }

            #endregion

            #region .ctor

            /// <summary>  Initialized all diogonal entries to scale </summary>
            public mat4x3(float scale) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat4x3(mat2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat4x3(mat2x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat4x3(mat2x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat4x3(mat3x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat4x3(mat3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat4x3(mat3x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat4x3(mat4x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat4x3(mat4 m) { throw _invalidAccess; }

            public mat4x3(vec3 column1, vec3 column2, 
                vec3 column3, vec3 column4) { throw _invalidAccess; }

            #endregion

            public vec3 this[int column]
            {
                get { throw _invalidAccess; }
                set { throw _invalidAccess; }
            }    
        }
        
        public sealed class mat4
        {
            public static Matrix4 value;

            public static implicit operator mat4(Matrix4 v)
            { value = v; return null; }

                        #region .ctor

            /// <summary>  Initialized all diogonal entries to scale </summary>
            public mat4(float scale) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat4(mat2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat4(mat2x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat4(mat2x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat4(mat3x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat4(mat3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat4(mat3x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public mat4(mat4x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public mat4(mat4x3 m) { throw _invalidAccess; }

            public mat4(vec4 column1, vec4 column2, 
                vec4 column3, vec4 column4) { throw _invalidAccess; }

            #endregion

            public vec4 this[int column]
            {
                get { throw _invalidAccess; }
                set { throw _invalidAccess; }
            }   
        }
    }
}

// ReSharper restore InconsistentNaming
// ReSharper restore UnusedParameter.Local
