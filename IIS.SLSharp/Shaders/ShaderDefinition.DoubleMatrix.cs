// ReSharper disable InconsistentNaming
// ReSharper disable UnusedParameter.Local

namespace IIS.SLSharp.Shaders
{
    public abstract partial class ShaderDefinition
    {
        public sealed class dmat2
        {
            
            #region .ctor
            /// <summary>  Initialized all diogonal entries to scale </summary>
            public dmat2(double scale) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat2(dmat2x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat2(dmat2x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat2(dmat3x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat2(dmat3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat2(dmat3x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat2(dmat4x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat2(dmat4x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat2(dmat4 m) { throw _invalidAccess; }

            public dmat2(vec2 column1, vec2 column2) { throw _invalidAccess; }

            /// <summary>initialized the matrix with a vec4</summary>
            public dmat2(vec4 compressedMatrix) { throw _invalidAccess; }

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

        public sealed class dmat2x3
        {
            #region .ctor

            /// <summary>  Initialized all diogonal entries to scale </summary>
            public dmat2x3(double scale) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat2x3(dmat2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat2x3(dmat2x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat2x3(dmat3x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat2x3(dmat3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat2x3(dmat3x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat2x3(dmat4x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat2x3(dmat4x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat2x3(dmat4 m) { throw _invalidAccess; }

            public dmat2x3(vec3 column1, vec3 column2) { throw _invalidAccess; }

            #endregion

            public vec3 this[int column]
            {
                get { throw _invalidAccess; }
                set { throw _invalidAccess; }
            }
        }

        public sealed class dmat2x4
        {
            #region .ctor

            /// <summary>  Initialized all diogonal entries to scale </summary>
            public dmat2x4(double scale) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat2x4(dmat2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat2x4(dmat2x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat2x4(dmat3x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat2x4(dmat3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat2x4(dmat3x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat2x4(dmat4x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat2x4(dmat4x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat2x4(dmat4 m) { throw _invalidAccess; }

            public dmat2x4(vec4 column1, vec4 column2) { throw _invalidAccess; }

            #endregion

            public vec4 this[int column]
            {
                get { throw _invalidAccess; }
                set { throw _invalidAccess; }
            }
        }

        public sealed class dmat3x2
        {
            #region .ctor

            /// <summary>  Initialized all diogonal entries to scale </summary>
            public dmat3x2(double scale) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat3x2(dmat2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat3x2(dmat2x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat3x2(dmat2x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat3x2(dmat3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat3x2(dmat3x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat3x2(dmat4x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat3x2(dmat4x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat3x2(dmat4 m) { throw _invalidAccess; }

            public dmat3x2(vec2 column1, vec2 column2, vec2 column3) { throw _invalidAccess; }

            #endregion

            public vec2 this[int column]
            {
                get { throw _invalidAccess; }
                set { throw _invalidAccess; }
            }
        }

        public sealed class dmat3
        {
            #region .ctor

            /// <summary>  Initialized all diogonal entries to scale </summary>
            public dmat3(double scale) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat3(dmat2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat3(dmat2x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat3(dmat2x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat3(dmat3x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat3(dmat3x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat3(dmat4x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat3(dmat4x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat3(dmat4 m) { throw _invalidAccess; }

            public dmat3(vec3 column1, vec3 column2, vec3 column3) { throw _invalidAccess; }

            #endregion

            public vec3 this[int column]
            {
                get { throw _invalidAccess; }
                set { throw _invalidAccess; }
            }
        }

        public sealed class dmat3x4
        {
            #region .ctor

            /// <summary>  Initialized all diogonal entries to scale </summary>
            public dmat3x4(double scale) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat3x4(dmat2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat3x4(dmat2x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat3x4(dmat2x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat3x4(dmat3x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat3x4(dmat3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat3x4(dmat4x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat3x4(dmat4x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat3x4(dmat4 m) { throw _invalidAccess; }

            public dmat3x4(vec4 column1, vec4 column2, vec4 column3) { throw _invalidAccess; }

            #endregion

            public vec4 this[int column]
            {
                get { throw _invalidAccess; }
                set { throw _invalidAccess; }
            }
        }

        public sealed class dmat4x2
        {
            #region .ctor

            /// <summary>  Initialized all diogonal entries to scale </summary>
            public dmat4x2(double scale) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat4x2(dmat2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat4x2(dmat2x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat4x2(dmat2x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat4x2(dmat3x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat4x2(dmat3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat4x2(dmat3x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat4x2(dmat4x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat4x2(dmat4 m) { throw _invalidAccess; }

            public dmat4x2(vec2 column1, vec2 column2, 
                vec2 column3, vec2 column4) { throw _invalidAccess; }

            #endregion

            public vec2 this[int column]
            {
                get { throw _invalidAccess; }
                set { throw _invalidAccess; }
            }    
        }

        public sealed class dmat4x3
        {
            #region .ctor

            /// <summary>  Initialized all diogonal entries to scale </summary>
            public dmat4x3(double scale) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat4x3(dmat2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat4x3(dmat2x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat4x3(dmat2x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat4x3(dmat3x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat4x3(dmat3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat4x3(dmat3x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat4x3(dmat4x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat4x3(dmat4 m) { throw _invalidAccess; }

            public dmat4x3(vec3 column1, vec3 column2, 
                vec3 column3, vec3 column4) { throw _invalidAccess; }

            #endregion

            public vec3 this[int column]
            {
                get { throw _invalidAccess; }
                set { throw _invalidAccess; }
            }    
        }
        
        public sealed class dmat4
        {
            #region .ctor

            /// <summary>  Initialized all diogonal entries to scale </summary>
            public dmat4(double scale) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat4(dmat2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat4(dmat2x3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat4(dmat2x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat4(dmat3x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat4(dmat3 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat4(dmat3x4 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m
            /// sets the lower right diagonal component(s) to 1, everything else to 0</summary>
            public dmat4(dmat4x2 m) { throw _invalidAccess; }

            /// <summary>initialized the matrix with the upperleft part of m</summary>
            public dmat4(dmat4x3 m) { throw _invalidAccess; }

            public dmat4(vec4 column1, vec4 column2, 
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
