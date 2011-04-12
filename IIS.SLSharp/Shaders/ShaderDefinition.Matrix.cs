// ReSharper disable InconsistentNaming
// ReSharper disable UnusedParameter.Local

namespace IIS.SLSharp.Shaders
{
    public abstract partial class ShaderDefinition
    {
        public sealed class mat2
        {
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
