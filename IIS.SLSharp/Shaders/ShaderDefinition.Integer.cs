// ReSharper disable InconsistentNaming

namespace IIS.SLSharp.Shaders
{
    public abstract partial class ShaderDefinition
    {
        #region genUType uaddCarry (genUType x, genUType y, out genUType carry)

        /// <summary> Adds 32-bit unsigned integer x and y, returning the sum modulo 2**32. 
        /// The value carry is set to 0 if the sum was less than 232, or to 1 otherwise. </summary>
        protected static uint uaddCarry(uint x, uint y, out uint carry)
        {
            throw _invalidAccess;
        }

        /// <summary> Adds 32-bit unsigned integer x and y, returning the sum modulo 2**32. 
        /// The value carry is set to 0 if the sum was less than 232, or to 1 otherwise. </summary>
        protected static uvec2 uaddCarry(uvec2 x, uvec2 y, out uvec2 carry)
        {
            throw _invalidAccess;
        }

        /// <summary> Adds 32-bit unsigned integer x and y, returning the sum modulo 2**32. 
        /// The value carry is set to 0 if the sum was less than 232, or to 1 otherwise. </summary>
        protected static uvec3 uaddCarry(uvec3 x, uvec3 y, out uvec3 carry)
        {
            throw _invalidAccess;
        }

        /// <summary> Adds 32-bit unsigned integer x and y, returning the sum modulo 2**32. 
        /// The value carry is set to 0 if the sum was less than 232, or to 1 otherwise. </summary>
        protected static uvec4 uaddCarry(uvec4 x, uvec4 y, out uvec4 carry)
        {
            throw _invalidAccess;
        }

        #endregion

        #region genUType usubBorrow (genUType x, genUType y, out genUType borrow)

        /// <summary> Subtracts the 32-bit unsigned integer y from x, returning the difference 
        /// if non-negative, or 2**32 plus the difference otherwise. 
        /// The value borrow is set to 0 if x >= y, or to 1 otherwise. </summary>
        protected static uint usubBorrow(uint x, uint y, out uint borrow)
        {
            throw _invalidAccess;
        }

        /// <summary> Subtracts the 32-bit unsigned integer y from x, returning the difference 
        /// if non-negative, or 2**32 plus the difference otherwise. 
        /// The value borrow is set to 0 if x >= y, or to 1 otherwise. </summary>
        protected static uvec2 usubBorrow(uvec2 x, uvec2 y, out uvec2 borrow)
        {
            throw _invalidAccess;
        }

        /// <summary> Subtracts the 32-bit unsigned integer y from x, returning the difference 
        /// if non-negative, or 2**32 plus the difference otherwise. 
        /// The value borrow is set to 0 if x >= y, or to 1 otherwise. </summary>
        protected static uvec3 usubBorrow(uvec3 x, uvec3 y, out uvec3 borrow)
        {
            throw _invalidAccess;
        }

        /// <summary> Subtracts the 32-bit unsigned integer y from x, returning the difference 
        /// if non-negative, or 2**32 plus the difference otherwise. 
        /// The value borrow is set to 0 if x >= y, or to 1 otherwise. </summary>
        protected static uvec4 usubBorrow(uvec4 x, uvec4 y, out uvec4 borrow)
        {
            throw _invalidAccess;
        }

        #endregion

        #region void umulExtended (genUType x, genUType y, out genUType msb, out genUType lsb)

        /// <summary>
        /// Multiplies 32-bit integers x and y, producing a 64-bit result. 
        /// The 32 least-significant bits are returned in lsb. The 32 most-significant bits are returned in msb.
        /// </summary>
        protected static void umulExtended(uint x, uint y, out uint msb, out uint lsb)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Multiplies 32-bit integers x and y, producing a 64-bit result. 
        /// The 32 least-significant bits are returned in lsb. The 32 most-significant bits are returned in msb.
        /// </summary>
        protected static void umulExtended(uvec2 x, uvec2 y, out uvec2 msb, out uvec2 lsb)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Multiplies 32-bit integers x and y, producing a 64-bit result. 
        /// The 32 least-significant bits are returned in lsb. The 32 most-significant bits are returned in msb.
        /// </summary>
        protected static void umulExtended(uvec3 x, uvec3 y, out uvec3 msb, out uvec3 lsb)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Multiplies 32-bit integers x and y, producing a 64-bit result. 
        /// The 32 least-significant bits are returned in lsb. The 32 most-significant bits are returned in msb.
        /// </summary>
        protected static void umulExtended(uvec4 x, uvec4 y, out uvec4 msb, out uvec4 lsb)
        {
            throw _invalidAccess;
        }

        #endregion

        #region void imulExtended (genIType x, genIType y, out genIType msb, out genIType lsb)

        /// <summary>
        /// Multiplies 32-bit integers x and y, producing a 64-bit result. 
        /// The 32 least-significant bits are returned in lsb. The 32 most-significant bits are returned in msb.
        /// </summary>
        protected static void imulExtended(int x, int y, out int msb, out int lsb)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Multiplies 32-bit integers x and y, producing a 64-bit result. 
        /// The 32 least-significant bits are returned in lsb. The 32 most-significant bits are returned in msb.
        /// </summary>
        protected static void imulExtended(ivec2 x, ivec2 y, out ivec2 msb, out ivec2 lsb)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Multiplies 32-bit integers x and y, producing a 64-bit result. 
        /// The 32 least-significant bits are returned in lsb. The 32 most-significant bits are returned in msb.
        /// </summary>
        protected static void imulExtended(ivec3 x, ivec3 y, out ivec3 msb, out ivec3 lsb)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Multiplies 32-bit integers x and y, producing a 64-bit result. 
        /// The 32 least-significant bits are returned in lsb. The 32 most-significant bits are returned in msb.
        /// </summary>
        protected static void imulExtended(ivec4 x, ivec4 y, out ivec4 msb, out ivec4 lsb)
        {
            throw _invalidAccess;
        }

        #endregion

        #region genIType bitfieldExtract (genIType value, int offset, int bits)

        /// <summary>
        /// Extracts bits [offset, offset + bits - 1] from value, returning them 
        /// in the least significant bits of the result.
        /// The most significant bits will be set to the value of bit offset + base – 1.
        /// If bits is zero, the result will be zero. The result will be undefined if 
        /// offset or bits is negative, or if the sum of offset and bits is greater than 
        /// the number of bits used to store the operand.
        /// </summary>
        /// <returns></returns>
        protected static int bitfieldExtract(int value, int offset, int bits)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Extracts bits [offset, offset + bits - 1] from value, returning them 
        /// in the least significant bits of the result.
        /// The most significant bits will be set to the value of bit offset + base – 1.
        /// If bits is zero, the result will be zero. The result will be undefined if 
        /// offset or bits is negative, or if the sum of offset and bits is greater than 
        /// the number of bits used to store the operand.
        /// </summary>
        /// <returns></returns>
        protected static ivec2 bitfieldExtract(ivec2 value, int offset, int bits)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Extracts bits [offset, offset + bits - 1] from value, returning them 
        /// in the least significant bits of the result.
        /// The most significant bits will be set to the value of bit offset + base – 1.
        /// If bits is zero, the result will be zero. The result will be undefined if 
        /// offset or bits is negative, or if the sum of offset and bits is greater than 
        /// the number of bits used to store the operand.
        /// </summary>
        /// <returns></returns>
        protected static ivec3 bitfieldExtract(ivec3 value, int offset, int bits)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Extracts bits [offset, offset + bits - 1] from value, returning them 
        /// in the least significant bits of the result.
        /// The most significant bits will be set to the value of bit offset + base – 1.
        /// If bits is zero, the result will be zero. The result will be undefined if 
        /// offset or bits is negative, or if the sum of offset and bits is greater than 
        /// the number of bits used to store the operand.
        /// </summary>
        /// <returns></returns>
        protected static ivec4 bitfieldExtract(ivec4 value, int offset, int bits)
        {
            throw _invalidAccess;
        }
        
        #endregion

        #region genUType bitfieldExtract (genUType value, int offset, int bits)

        /// <summary>
        /// Extracts bits [offset, offset + bits - 1] from value, returning them 
        /// in the least significant bits of the result.
        /// The most significant bits of the result will be set to zero.
        /// If bits is zero, the result will be zero. The result will be undefined if 
        /// offset or bits is negative, or if the sum of offset and bits is greater than 
        /// the number of bits used to store the operand.
        /// </summary>
        /// <returns></returns>
        protected static uint bitfieldExtract(uint value, int offset, int bits)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Extracts bits [offset, offset + bits - 1] from value, returning them 
        /// in the least significant bits of the result.
        /// The most significant bits of the result will be set to zero.
        /// If bits is zero, the result will be zero. The result will be undefined if 
        /// offset or bits is negative, or if the sum of offset and bits is greater than 
        /// the number of bits used to store the operand.
        /// </summary>
        /// <returns></returns>
        protected static uvec2 bitfieldExtract(uvec2 value, int offset, int bits)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Extracts bits [offset, offset + bits - 1] from value, returning them 
        /// in the least significant bits of the result.
        /// The most significant bits of the result will be set to zero.
        /// If bits is zero, the result will be zero. The result will be undefined if 
        /// offset or bits is negative, or if the sum of offset and bits is greater than 
        /// the number of bits used to store the operand.
        /// </summary>
        /// <returns></returns>
        protected static uvec3 bitfieldExtract(uvec3 value, int offset, int bits)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Extracts bits [offset, offset + bits - 1] from value, returning them 
        /// in the least significant bits of the result.
        /// The most significant bits of the result will be set to zero.
        /// If bits is zero, the result will be zero. The result will be undefined if 
        /// offset or bits is negative, or if the sum of offset and bits is greater than 
        /// the number of bits used to store the operand.
        /// </summary>
        /// <returns></returns>
        protected static uvec4 bitfieldExtract(uvec4 value, int offset, int bits)
        {
            throw _invalidAccess;
        }

        #endregion

        #region genIType bitfieldInsert (genIType base, genIType insert, int offset, int bits)

        /// <summary>
        /// Returns the insertion the bits least-significant bits of insert into base.
        /// The result will have bits [offset, offset + bits - 1] taken from bits [0, bits – 1] 
        /// of insert, and all other bits taken directly from the corresponding bits of base. 
        /// If bits is zero, the result will simply be base. 
        /// The result will be undefined if offset or bits is negative, or if the sum of
        /// offset and bits is greater than the number of bits used to store the operand.
        /// </summary>
        protected static int bitfieldInsert(int _base, int insert, int offset, int bits)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Returns the insertion the bits least-significant bits of insert into base.
        /// The result will have bits [offset, offset + bits - 1] taken from bits [0, bits – 1] 
        /// of insert, and all other bits taken directly from the corresponding bits of base. 
        /// If bits is zero, the result will simply be base. 
        /// The result will be undefined if offset or bits is negative, or if the sum of
        /// offset and bits is greater than the number of bits used to store the operand.
        /// </summary>
        protected static ivec2 bitfieldInsert(ivec2 _base, ivec2 insert, int offset, int bits)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Returns the insertion the bits least-significant bits of insert into base.
        /// The result will have bits [offset, offset + bits - 1] taken from bits [0, bits – 1] 
        /// of insert, and all other bits taken directly from the corresponding bits of base. 
        /// If bits is zero, the result will simply be base. 
        /// The result will be undefined if offset or bits is negative, or if the sum of
        /// offset and bits is greater than the number of bits used to store the operand.
        /// </summary>
        protected static ivec3 bitfieldInsert(ivec3 _base, ivec3 insert, int offset, int bits)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Returns the insertion the bits least-significant bits of insert into base.
        /// The result will have bits [offset, offset + bits - 1] taken from bits [0, bits – 1] 
        /// of insert, and all other bits taken directly from the corresponding bits of base. 
        /// If bits is zero, the result will simply be base. 
        /// The result will be undefined if offset or bits is negative, or if the sum of
        /// offset and bits is greater than the number of bits used to store the operand.
        /// </summary>
        protected static ivec4 bitfieldInsert(ivec4 _base, ivec4 insert, int offset, int bits)
        {
            throw _invalidAccess;
        }

        #endregion

        #region genUType bitfieldInsert (genUType base, genUType insert, int offset, int bits)

        /// <summary>
        /// Returns the insertion the bits least-significant bits of insert into base.
        /// The result will have bits [offset, offset + bits - 1] taken from bits [0, bits – 1] 
        /// of insert, and all other bits taken directly from the corresponding bits of base. 
        /// If bits is zero, the result will simply be base. 
        /// The result will be undefined if offset or bits is negative, or if the sum of
        /// offset and bits is greater than the number of bits used to store the operand.
        /// </summary>
        protected static uint bitfieldInsert(uint _base, uint insert, int offset, int bits)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Returns the insertion the bits least-significant bits of insert into base.
        /// The result will have bits [offset, offset + bits - 1] taken from bits [0, bits – 1] 
        /// of insert, and all other bits taken directly from the corresponding bits of base. 
        /// If bits is zero, the result will simply be base. 
        /// The result will be undefined if offset or bits is negative, or if the sum of
        /// offset and bits is greater than the number of bits used to store the operand.
        /// </summary>
        protected static uvec2 bitfieldInsert(uvec2 _base, uvec2 insert, int offset, int bits)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Returns the insertion the bits least-significant bits of insert into base.
        /// The result will have bits [offset, offset + bits - 1] taken from bits [0, bits – 1] 
        /// of insert, and all other bits taken directly from the corresponding bits of base. 
        /// If bits is zero, the result will simply be base. 
        /// The result will be undefined if offset or bits is negative, or if the sum of
        /// offset and bits is greater than the number of bits used to store the operand.
        /// </summary>
        protected static uvec3 bitfieldInsert(uvec3 _base, uvec3 insert, int offset, int bits)
        {
            throw _invalidAccess;
        }

        /// <summary>
        /// Returns the insertion the bits least-significant bits of insert into base.
        /// The result will have bits [offset, offset + bits - 1] taken from bits [0, bits – 1] 
        /// of insert, and all other bits taken directly from the corresponding bits of base. 
        /// If bits is zero, the result will simply be base. 
        /// The result will be undefined if offset or bits is negative, or if the sum of
        /// offset and bits is greater than the number of bits used to store the operand.
        /// </summary>
        protected static uvec4 bitfieldInsert(uvec4 _base, uvec4 insert, int offset, int bits)
        {
            throw _invalidAccess;
        }

        #endregion

        #region genIType bitfieldReverse (genIType value)

        /// <summary>
        /// Returns the reversal of the bits of value. The bit numbered n of the result will be taken from 
        /// bit (bits - 1) - n of value, where bits is the total number of bits used to represent value.
        /// </summary>
        protected static int bitfieldReverse(int value) { throw _invalidAccess; }

        /// <summary>
        /// Returns the reversal of the bits of value. The bit numbered n of the result will be taken from 
        /// bit (bits - 1) - n of value, where bits is the total number of bits used to represent value.
        /// </summary>
        protected static ivec2 bitfieldReverse(ivec2 value) { throw _invalidAccess; }

        /// <summary>
        /// Returns the reversal of the bits of value. The bit numbered n of the result will be taken from 
        /// bit (bits - 1) - n of value, where bits is the total number of bits used to represent value.
        /// </summary>
        protected static ivec3 bitfieldReverse(ivec3 value) { throw _invalidAccess; }

        /// <summary>
        /// Returns the reversal of the bits of value. The bit numbered n of the result will be taken from 
        /// bit (bits - 1) - n of value, where bits is the total number of bits used to represent value.
        /// </summary>
        protected static ivec4 bitfieldReverse(ivec4 value) { throw _invalidAccess; }

        #endregion

        #region genUType bitfieldReverse (genUType value)

        /// <summary>
        /// Returns the reversal of the bits of value. The bit numbered n of the result will be taken from 
        /// bit (bits - 1) - n of value, where bits is the total number of bits used to represent value.
        /// </summary>
        protected static uint bitfieldReverse(uint value) { throw _invalidAccess; }

        /// <summary>
        /// Returns the reversal of the bits of value. The bit numbered n of the result will be taken from 
        /// bit (bits - 1) - n of value, where bits is the total number of bits used to represent value.
        /// </summary>
        protected static uvec2 bitfieldReverse(uvec2 value) { throw _invalidAccess; }

        /// <summary>
        /// Returns the reversal of the bits of value. The bit numbered n of the result will be taken from 
        /// bit (bits - 1) - n of value, where bits is the total number of bits used to represent value.
        /// </summary>
        protected static uvec3 bitfieldReverse(uvec3 value) { throw _invalidAccess; }

        /// <summary>
        /// Returns the reversal of the bits of value. The bit numbered n of the result will be taken from 
        /// bit (bits - 1) - n of value, where bits is the total number of bits used to represent value.
        /// </summary>
        protected static uvec4 bitfieldReverse(uvec4 value) { throw _invalidAccess; }

        #endregion
        
        #region genIType bitCount (genIType value)

        /// <summary>Returns the number of bits set to 1 in the binary representation of value.</summary>
        protected static int bitCount(int value) { throw _invalidAccess; }

        /// <summary>Returns the number of bits set to 1 in the binary representation of value.</summary>
        protected static ivec2 bitCount(ivec2 value) { throw _invalidAccess; }

        /// <summary>Returns the number of bits set to 1 in the binary representation of value.</summary>
        protected static ivec3 bitCount(ivec3 value) { throw _invalidAccess; }

        /// <summary>Returns the number of bits set to 1 in the binary representation of value.</summary>
        protected static ivec4 bitCount(ivec4 value) { throw _invalidAccess; }

        #endregion

        #region genIType bitCount (genUType value)

        /// <summary>Returns the number of bits set to 1 in the binary representation of value.</summary>
        protected static int bitCount(uint value) { throw _invalidAccess; }

        /// <summary>Returns the number of bits set to 1 in the binary representation of value.</summary>
        protected static ivec2 bitCount(uvec2 value) { throw _invalidAccess; }

        /// <summary>Returns the number of bits set to 1 in the binary representation of value.</summary>
        protected static ivec3 bitCount(uvec3 value) { throw _invalidAccess; }

        /// <summary>Returns the number of bits set to 1 in the binary representation of value.</summary>
        protected static ivec4 bitCount(uvec4 value) { throw _invalidAccess; }

        #endregion

        #region genIType findLSB (genIType value)

        /// <summary> Returns the bit number of the least significant bit set to 1 in the 
        /// binary representation of value. If value is zero, -1 will be returned. </summary>
        protected static int findLSB(int value) { throw _invalidAccess; }

        /// <summary> Returns the bit number of the least significant bit set to 1 in the 
        /// binary representation of value. If value is zero, -1 will be returned. </summary>
        protected static ivec2 findLSB(ivec2 value) { throw _invalidAccess; }

        /// <summary> Returns the bit number of the least significant bit set to 1 in the 
        /// binary representation of value. If value is zero, -1 will be returned. </summary>
        protected static ivec3 findLSB(ivec3 value) { throw _invalidAccess; }

        /// <summary> Returns the bit number of the least significant bit set to 1 in the 
        /// binary representation of value. If value is zero, -1 will be returned. </summary>
        protected static ivec4 findLSB(ivec4 value) { throw _invalidAccess; }

        #endregion
        
        #region genIType findLSB (genUType value)

        /// <summary> Returns the bit number of the least significant bit set to 1 in the 
        /// binary representation of value. If value is zero, -1 will be returned. </summary>
        protected static int findLSB(uint value) { throw _invalidAccess; }

        /// <summary> Returns the bit number of the least significant bit set to 1 in the 
        /// binary representation of value. If value is zero, -1 will be returned. </summary>
        protected static ivec2 findLSB(uvec2 value) { throw _invalidAccess; }

        /// <summary> Returns the bit number of the least significant bit set to 1 in the 
        /// binary representation of value. If value is zero, -1 will be returned. </summary>
        protected static ivec3 findLSB(uvec3 value) { throw _invalidAccess; }

        /// <summary> Returns the bit number of the least significant bit set to 1 in the 
        /// binary representation of value. If value is zero, -1 will be returned. </summary>
        protected static ivec4 findLSB(uvec4 value) { throw _invalidAccess; }

        #endregion

        #region genIType findMSB (genIType value)

        /// <summary>
        /// Returns the bit number of the most significant bit in the binary representation of value.
        /// For positive integers, the result will be the bit number of the most significant bit set to 1.
        /// For negative integers, the result will be the bit number of the most significant bit set to 0. 
        /// For a value of zero or negative one, -1 will be returned.
        /// </summary>
        protected static int findMSB(int value) { throw _invalidAccess; }

        /// <summary>
        /// Returns the bit number of the most significant bit in the binary representation of value.
        /// For positive integers, the result will be the bit number of the most significant bit set to 1.
        /// For negative integers, the result will be the bit number of the most significant bit set to 0. 
        /// For a value of zero or negative one, -1 will be returned.
        /// </summary>
        protected static ivec2 findMSB(ivec2 value) { throw _invalidAccess; }

        /// <summary>
        /// Returns the bit number of the most significant bit in the binary representation of value.
        /// For positive integers, the result will be the bit number of the most significant bit set to 1.
        /// For negative integers, the result will be the bit number of the most significant bit set to 0. 
        /// For a value of zero or negative one, -1 will be returned.
        /// </summary>
        protected static ivec3 findMSB(ivec3 value) { throw _invalidAccess; }

        /// <summary>
        /// Returns the bit number of the most significant bit in the binary representation of value.
        /// For positive integers, the result will be the bit number of the most significant bit set to 1.
        /// For negative integers, the result will be the bit number of the most significant bit set to 0. 
        /// For a value of zero or negative one, -1 will be returned.
        /// </summary>
        protected static ivec4 findMSB(ivec4 value) { throw _invalidAccess; }

        #endregion

        #region genIType findMSB (genUType value)

        /// <summary>
        /// Returns the bit number of the most significant bit in the binary representation of value.
        /// The result will be the bit number of the most significant bit set to 1.
        /// For a value of zero, -1 will be returned.
        /// </summary>
        protected static int findMSB(uint value) { throw _invalidAccess; }

        /// <summary>
        /// Returns the bit number of the most significant bit in the binary representation of value.
        /// The result will be the bit number of the most significant bit set to 1.
        /// For a value of zero, -1 will be returned.
        /// </summary>
        protected static int findMSB(uvec2 value) { throw _invalidAccess; }

        /// <summary>
        /// Returns the bit number of the most significant bit in the binary representation of value.
        /// The result will be the bit number of the most significant bit set to 1.
        /// For a value of zero, -1 will be returned.
        /// </summary>
        protected static int findMSB(uvec3 value) { throw _invalidAccess; }

        /// <summary>
        /// Returns the bit number of the most significant bit in the binary representation of value.
        /// The result will be the bit number of the most significant bit set to 1.
        /// For a value of zero, -1 will be returned.
        /// </summary>
        protected static int findMSB(uvec4 value) { throw _invalidAccess; }

        #endregion
    }
}

// ReSharper enable InconsistentNaming
