// ReSharper disable InconsistentNaming

namespace IIS.SLSharp.Shaders
{
    public abstract partial class ShaderDefinition
    {
        #region mat matrixCompMult (mat x, mat y)

        /// <summary>
        /// Multiply matrix x by matrix y component-wise, i.e., result[i][j] is the scalar product of x[i][j] and y[i][j].
        /// Note: to get linear algebraic matrix multiplication, use the multiply operator (*).
        /// </summary>
        public mat2 matrixCompMult(mat2 x, mat2 y) { throw _invalidAccess; }

        /// <summary>
        /// Multiply matrix x by matrix y component-wise, i.e., result[i][j] is the scalar product of x[i][j] and y[i][j].
        /// Note: to get linear algebraic matrix multiplication, use the multiply operator (*).
        /// </summary>
        public mat2x3 matrixCompMult(mat2x3 x, mat2x3 y) { throw _invalidAccess; }

        /// <summary>
        /// Multiply matrix x by matrix y component-wise, i.e., result[i][j] is the scalar product of x[i][j] and y[i][j].
        /// Note: to get linear algebraic matrix multiplication, use the multiply operator (*).
        /// </summary>
        public mat2x4 matrixCompMult(mat2x4 x, mat2x4 y) { throw _invalidAccess; }

        /// <summary>
        /// Multiply matrix x by matrix y component-wise, i.e., result[i][j] is the scalar product of x[i][j] and y[i][j].
        /// Note: to get linear algebraic matrix multiplication, use the multiply operator (*).
        /// </summary>
        public mat3x2 matrixCompMult(mat3x2 x, mat3x2 y) { throw _invalidAccess; }

        /// <summary>
        /// Multiply matrix x by matrix y component-wise, i.e., result[i][j] is the scalar product of x[i][j] and y[i][j].
        /// Note: to get linear algebraic matrix multiplication, use the multiply operator (*).
        /// </summary>
        public mat3 matrixCompMult(mat3 x, mat3 y) { throw _invalidAccess; }

        /// <summary>
        /// Multiply matrix x by matrix y component-wise, i.e., result[i][j] is the scalar product of x[i][j] and y[i][j].
        /// Note: to get linear algebraic matrix multiplication, use the multiply operator (*).
        /// </summary>
        public mat3x4 matrixCompMult(mat3x4 x, mat3x4 y) { throw _invalidAccess; }

        /// <summary>
        /// Multiply matrix x by matrix y component-wise, i.e., result[i][j] is the scalar product of x[i][j] and y[i][j].
        /// Note: to get linear algebraic matrix multiplication, use the multiply operator (*).
        /// </summary>
        public mat4x2 matrixCompMult(mat4x2 x, mat4x2 y) { throw _invalidAccess; }

        /// <summary>
        /// Multiply matrix x by matrix y component-wise, i.e., result[i][j] is the scalar product of x[i][j] and y[i][j].
        /// Note: to get linear algebraic matrix multiplication, use the multiply operator (*).
        /// </summary>
        public mat4x3 matrixCompMult(mat4x3 x, mat4x3 y) { throw _invalidAccess; }

        /// <summary>
        /// Multiply matrix x by matrix y component-wise, i.e., result[i][j] is the scalar product of x[i][j] and y[i][j].
        /// Note: to get linear algebraic matrix multiplication, use the multiply operator (*).
        /// </summary>
        public mat4 matrixCompMult(mat4 x, mat4 y) { throw _invalidAccess; }

        #endregion

        #region outerProduct

        /// <summary>
        /// Treats the first parameter c as a column vector (matrix with one column) 
        /// and the second parameter r as a row vector (matrix with one row) 
        /// and does a linear algebraic matrix multiply c * r, yielding a matrix 
        /// whose number of rows is the number of components in c and whose number 
        /// of columns is the number of components in r.
        /// </summary>
        /// <param name="c">left side column vector</param>
        /// <param name="r">right side row vector</param>
        /// <returns></returns>
        public mat2 outerProduct(vec2 c, vec2 r) { throw _invalidAccess; }

        /// <summary>
        /// Treats the first parameter c as a column vector (matrix with one column) 
        /// and the second parameter r as a row vector (matrix with one row) 
        /// and does a linear algebraic matrix multiply c * r, yielding a matrix 
        /// whose number of rows is the number of components in c and whose number 
        /// of columns is the number of components in r.
        /// </summary>
        /// <param name="c">left side column vector</param>
        /// <param name="r">right side row vector</param>
        /// <returns></returns>
        public mat3 outerProduct(vec3 c, vec3 r) { throw _invalidAccess; }

        /// <summary>
        /// Treats the first parameter c as a column vector (matrix with one column) 
        /// and the second parameter r as a row vector (matrix with one row) 
        /// and does a linear algebraic matrix multiply c * r, yielding a matrix 
        /// whose number of rows is the number of components in c and whose number 
        /// of columns is the number of components in r.
        /// </summary>
        /// <param name="c">left side column vector</param>
        /// <param name="r">right side row vector</param>
        /// <returns></returns>
        public mat4 outerProduct(vec4 c, vec4 r) { throw _invalidAccess; }

        /// <summary>
        /// Treats the first parameter c as a column vector (matrix with one column) 
        /// and the second parameter r as a row vector (matrix with one row) 
        /// and does a linear algebraic matrix multiply c * r, yielding a matrix 
        /// whose number of rows is the number of components in c and whose number 
        /// of columns is the number of components in r.
        /// </summary>
        /// <param name="c">left side column vector</param>
        /// <param name="r">right side row vector</param>
        /// <returns></returns>
        public mat2x3 outerProduct(vec3 c, vec2 r) { throw _invalidAccess; }

        /// <summary>
        /// Treats the first parameter c as a column vector (matrix with one column) 
        /// and the second parameter r as a row vector (matrix with one row) 
        /// and does a linear algebraic matrix multiply c * r, yielding a matrix 
        /// whose number of rows is the number of components in c and whose number 
        /// of columns is the number of components in r.
        /// </summary>
        /// <param name="c">left side column vector</param>
        /// <param name="r">right side row vector</param>
        /// <returns></returns>
        public mat3x2 outerProduct(vec2 c, vec3 r) { throw _invalidAccess; }

        /// <summary>
        /// Treats the first parameter c as a column vector (matrix with one column) 
        /// and the second parameter r as a row vector (matrix with one row) 
        /// and does a linear algebraic matrix multiply c * r, yielding a matrix 
        /// whose number of rows is the number of components in c and whose number 
        /// of columns is the number of components in r.
        /// </summary>
        /// <param name="c">left side column vector</param>
        /// <param name="r">right side row vector</param>
        /// <returns></returns>
        public mat2x4 outerProduct(vec4 c, vec2 r) { throw _invalidAccess; }

        /// <summary>
        /// Treats the first parameter c as a column vector (matrix with one column) 
        /// and the second parameter r as a row vector (matrix with one row) 
        /// and does a linear algebraic matrix multiply c * r, yielding a matrix 
        /// whose number of rows is the number of components in c and whose number 
        /// of columns is the number of components in r.
        /// </summary>
        /// <param name="c">left side column vector</param>
        /// <param name="r">right side row vector</param>
        /// <returns></returns>
        public mat4x2 outerProduct(vec2 c, vec4 r) { throw _invalidAccess; }

        /// <summary>
        /// Treats the first parameter c as a column vector (matrix with one column) 
        /// and the second parameter r as a row vector (matrix with one row) 
        /// and does a linear algebraic matrix multiply c * r, yielding a matrix 
        /// whose number of rows is the number of components in c and whose number 
        /// of columns is the number of components in r.
        /// </summary>
        /// <param name="c">left side column vector</param>
        /// <param name="r">right side row vector</param>
        /// <returns></returns>
        public mat3x4 outerProduct(vec4 c, vec3 r) { throw _invalidAccess; }

        /// <summary>
        /// Treats the first parameter c as a column vector (matrix with one column) 
        /// and the second parameter r as a row vector (matrix with one row) 
        /// and does a linear algebraic matrix multiply c * r, yielding a matrix 
        /// whose number of rows is the number of components in c and whose number 
        /// of columns is the number of components in r.
        /// </summary>
        /// <param name="c">left side column vector</param>
        /// <param name="r">right side row vector</param>
        /// <returns></returns>
        public mat4x3 outerProduct(vec3 c, vec4 r) { throw _invalidAccess; }

        #endregion

        #region transpose

        /// <summary>
        /// Returns a matrix that is the transpose of m. 
        /// The input matrix m is not modified.
        /// </summary>
        public mat2 transpose(mat2 m) { throw _invalidAccess; }

        /// <summary>
        /// Returns a matrix that is the transpose of m. 
        /// The input matrix m is not modified.
        /// </summary>
        public mat3 transpose(mat3 m) { throw _invalidAccess; }

        /// <summary>
        /// Returns a matrix that is the transpose of m. 
        /// The input matrix m is not modified.
        /// </summary>
        public mat4 transpose(mat4 m) { throw _invalidAccess; }

        /// <summary>
        /// Returns a matrix that is the transpose of m. 
        /// The input matrix m is not modified.
        /// </summary>
        public mat2x3 transpose(mat3x2 m) { throw _invalidAccess; }

        /// <summary>
        /// Returns a matrix that is the transpose of m. 
        /// The input matrix m is not modified.
        /// </summary>
        public mat3x2 transpose(mat2x3 m) { throw _invalidAccess; }

        /// <summary>
        /// Returns a matrix that is the transpose of m. 
        /// The input matrix m is not modified.
        /// </summary>
        public mat2x4 transpose(mat4x2 m) { throw _invalidAccess; }

        /// <summary>
        /// Returns a matrix that is the transpose of m. 
        /// The input matrix m is not modified.
        /// </summary>
        public mat4x2 transpose(mat2x4 m) { throw _invalidAccess; }

        /// <summary>
        /// Returns a matrix that is the transpose of m. 
        /// The input matrix m is not modified.
        /// </summary>
        public mat3x4 transpose(mat4x3 m) { throw _invalidAccess; }

        /// <summary>
        /// Returns a matrix that is the transpose of m. 
        /// The input matrix m is not modified.
        /// </summary>
        public mat4x3 transpose(mat3x4 m) { throw _invalidAccess; }

        #endregion

        #region determinant

        /// <summary>Returns the determinant of m. </summary>
        public float determinant(mat2 m) { throw _invalidAccess; }

        /// <summary>Returns the determinant of m. </summary>
        public float determinant(mat3 m) { throw _invalidAccess; }

        /// <summary>Returns the determinant of m. </summary>
        public float determinant(mat4 m) { throw _invalidAccess; }

        #endregion
    }
}

// ReSharper enable InconsistentNaming