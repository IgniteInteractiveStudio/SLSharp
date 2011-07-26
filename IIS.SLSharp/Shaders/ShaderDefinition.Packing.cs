// ReSharper disable InconsistentNaming

namespace IIS.SLSharp.Shaders
{
    public abstract partial class ShaderDefinition
    {
        /// <summary>
        /// First, converts each component of the normalized floating-point value v into 8- or 16-bit integer values.
        /// Then, the results are packed into the returned 32-bit unsigned integer.
        /// The conversion for component c of v to fixed point is done as follows:
        /// Round(Clamp(c, 0, +1) * 65535.0)
        /// The first component of the vector will be written to the least significant bits of the output; 
        /// the last component will be written to the most significant bits.
        /// </summary>
        protected static uint packUnorm2x16 (vec2 v) { throw _invalidAccess; }

        /// <summary>
        /// First, converts each component of the normalized floating-point value v into 8- or 16-bit integer values.
        /// Then, the results are packed into the returned 32-bit unsigned integer.
        /// The conversion for component c of v to fixed point is done as follows:
        /// Round(Clamp(c, 0, +1) * 255.0)
        /// The first component of the vector will be written to the least significant bits of the output; 
        /// the last component will be written to the most significant bits.
        /// </summary>
        protected static uint packUnorm4x8 (vec4 v) { throw _invalidAccess; }

        /// <summary>
        /// First, converts each component of the normalized floating-point value v into 8- or 16-bit integer values.
        /// Then, the results are packed into the returned 32-bit unsigned integer.
        /// The conversion for component c of v to fixed point is done as follows:
        /// Round(Clamp(c, -1, +1) * 127.0)
        /// The first component of the vector will be written to the least significant bits of the output; 
        /// the last component will be written to the most significant bits.
        /// </summary>
        protected static uint packSnorm4x8(vec4 v) { throw _invalidAccess; }

        /// <summary>
        /// First, unpacks a single 32-bit unsigned integer p into a pair of 16-bit unsigned integers, four 8-bit 
        /// unsigned integers, or four 8-bit signed integers. Then, each component is converted to a normalized 
        /// floating-point value to generate the returned two- or four-component vector.
        /// The conversion for unpacked fixed-point value f to floating point is done as follows:
        /// f / 65535.0
        /// The first component of the returned vector will be extracted from the least significant bits of the input; 
        /// the last component will be extracted from the most significant bits.
        /// </summary>
        protected static vec2 unpackUnorm2x16 (uint p) { throw _invalidAccess; }

        /// <summary>
        /// First, unpacks a single 32-bit unsigned integer p into a pair of 16-bit unsigned integers, four 8-bit 
        /// unsigned integers, or four 8-bit signed integers. Then, each component is converted to a normalized 
        /// floating-point value to generate the returned two- or four-component vector.
        /// The conversion for unpacked fixed-point value f to floating point is done as follows:
        /// f / 255.0
        /// The first component of the returned vector will be extracted from the least significant bits of the input; 
        /// the last component will be extracted from the most significant bits.
        /// </summary>
        protected static vec4 unpackUnorm4x8 (uint p) { throw _invalidAccess; }

        /// <summary>
        /// First, unpacks a single 32-bit unsigned integer p into a pair of 16-bit unsigned integers, four 8-bit 
        /// unsigned integers, or four 8-bit signed integers. Then, each component is converted to a normalized 
        /// floating-point value to generate the returned two- or four-component vector.
        /// The conversion for unpacked fixed-point value f to floating point is done as follows:
        /// Clamp(f / 127.0, -1, +1)
        /// The first component of the returned vector will be extracted from the least significant bits of the input; 
        /// the last component will be extracted from the most significant bits.
        /// </summary>
        protected static vec4 unpackSnorm4x8(uint p) { throw _invalidAccess; }


        /// <summary>
        /// Returns a double-precision value obtained by packing the components of v into a 64-bit value. 
        /// If an IEEE 754 Inf or NaN is created, it will not signal, and the resulting floating point 
        /// value is unspecified. Otherwise, the bitlevel representation of v is preserved. 
        /// The first vector component specifies the 32 least significant bits; 
        /// the second component specifies the 32 most significant bits.
        /// </summary>
        protected static double packDouble2x32(uvec2 v) { throw _invalidAccess; }

        /// <summary>
        /// Returns a two-component unsigned integer vector representation of v. 
        /// The bit-level representation of v is preserved. The first component of the vector contains 
        /// the 32 least significant bits of the double; 
        /// the second component consists the 32 most significant bits.
        /// </summary>
        protected static uvec2 unpackDouble2x32(double v) { throw _invalidAccess; }
    }
}

// ReSharper enable InconsistentNaming
