// This file is auto-generated. Do not edit.

using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace SimdJsonSharp
{
﻿    public unsafe partial class padded_string : SafeHandleZeroOrMinusOneIsInvalid
    {
        #region Handle
        /// <summary>
        /// Pointer to the underlying native object
        /// </summary>
        public IntPtr Handle => DangerousGetHandle();

        /// <summary>
        /// Create padded_string from a native pointer
        /// ownsHandle=false means GC won't delete the underlying native object if this C# wrapper goes out of scope
        /// </summary>
        public padded_string(IntPtr handle, bool ownsHandle = true) : base(ownsHandle) => SetHandle(handle);
        #endregion

        #region API
//TODO: %API%
        #endregion

        #region DllImports
        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr padded_string_padded_string_0();

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr padded_string_padded_string_s(IntPtr/*size_t*/ length);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr padded_string_padded_string_cs(SByte* data, IntPtr/*size_t*/ length);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr padded_string_padded_string_p(IntPtr o);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern void padded_string_swap_p(IntPtr target, IntPtr o);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr/*size_t*/ padded_string_size_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr/*size_t*/ padded_string_length_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern SByte* padded_string_data_0(IntPtr target);
        #endregion

        #region ReleaseHandle
        protected override bool ReleaseHandle()
        {
            padded_string__delete(Handle);
            return true;
        }

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern void padded_string__delete(IntPtr target);
        #endregion
    }

﻿    public unsafe partial class ParsedJson : SafeHandleZeroOrMinusOneIsInvalid
    {
        #region Handle
        /// <summary>
        /// Pointer to the underlying native object
        /// </summary>
        public IntPtr Handle => DangerousGetHandle();

        /// <summary>
        /// Create ParsedJson from a native pointer
        /// ownsHandle=false means GC won't delete the underlying native object if this C# wrapper goes out of scope
        /// </summary>
        public ParsedJson(IntPtr handle, bool ownsHandle = true) : base(ownsHandle) => SetHandle(handle);
        #endregion

        #region API
//TODO: %API%
        #endregion

        #region DllImports
        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr ParsedJson_ParsedJson_0();

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr ParsedJson_ParsedJson_P(IntPtr p);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte ParsedJson_allocateCapacity_ss(IntPtr target, IntPtr/*size_t*/ len, IntPtr/*size_t*/ maxdepth);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte ParsedJson_isValid_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern void ParsedJson_deallocate_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern void ParsedJson_init_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern void ParsedJson_write_tape_uu(IntPtr target, UInt64 val, Byte c);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern void ParsedJson_write_tape_s64_i(IntPtr target, Int64 i);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern void ParsedJson_write_tape_double_d(IntPtr target, Double d);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt32 ParsedJson_get_current_loc_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern void ParsedJson_annotate_previousloc_uu(IntPtr target, UInt32 saved_loc, UInt64 val);
        #endregion

        #region ReleaseHandle
        protected override bool ReleaseHandle()
        {
            ParsedJson__delete(Handle);
            return true;
        }

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern void ParsedJson__delete(IntPtr target);
        #endregion
    }

﻿    public unsafe partial class InvalidJSON : SafeHandleZeroOrMinusOneIsInvalid
    {
        #region Handle
        /// <summary>
        /// Pointer to the underlying native object
        /// </summary>
        public IntPtr Handle => DangerousGetHandle();

        /// <summary>
        /// Create InvalidJSON from a native pointer
        /// ownsHandle=false means GC won't delete the underlying native object if this C# wrapper goes out of scope
        /// </summary>
        public InvalidJSON(IntPtr handle, bool ownsHandle = true) : base(ownsHandle) => SetHandle(handle);
        #endregion

        #region API
//TODO: %API%
        #endregion

        #region DllImports
        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern SByte* InvalidJSON_what_0(IntPtr target);
        #endregion

        #region ReleaseHandle
        protected override bool ReleaseHandle()
        {
            InvalidJSON__delete(Handle);
            return true;
        }

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern void InvalidJSON__delete(IntPtr target);
        #endregion
    }

﻿    public unsafe partial class iterator : SafeHandleZeroOrMinusOneIsInvalid
    {
        #region Handle
        /// <summary>
        /// Pointer to the underlying native object
        /// </summary>
        public IntPtr Handle => DangerousGetHandle();

        /// <summary>
        /// Create iterator from a native pointer
        /// ownsHandle=false means GC won't delete the underlying native object if this C# wrapper goes out of scope
        /// </summary>
        public iterator(IntPtr handle, bool ownsHandle = true) : base(ownsHandle) => SetHandle(handle);
        #endregion

        #region API
//TODO: %API%
        #endregion

        #region DllImports
        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr iterator_iterator_P(IntPtr pj_);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr iterator_iterator_i(IntPtr o);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_isOk_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr/*size_t*/ iterator_get_tape_location_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr/*size_t*/ iterator_get_tape_length_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr/*size_t*/ iterator_get_depth_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_get_scope_type_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_move_forward_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_get_type_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Int64 iterator_get_integer_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern SByte* iterator_get_string_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt32 iterator_get_string_length_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Double iterator_get_double_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_is_object_or_array_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_is_object_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_is_array_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_is_string_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_is_integer_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_is_double_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_is_true_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_is_false_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_is_null_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_is_object_or_array_u(Byte type);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_move_to_key_c(IntPtr target, SByte* key);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_next_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_prev_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_up_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_down_0(IntPtr target);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern void iterator_to_start_scope_0(IntPtr target);
        #endregion

        #region ReleaseHandle
        protected override bool ReleaseHandle()
        {
            iterator__delete(Handle);
            return true;
        }

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern void iterator__delete(IntPtr target);
        #endregion
    }

﻿    public unsafe partial class scopeindex_t : SafeHandleZeroOrMinusOneIsInvalid
    {
        #region Handle
        /// <summary>
        /// Pointer to the underlying native object
        /// </summary>
        public IntPtr Handle => DangerousGetHandle();

        /// <summary>
        /// Create scopeindex_t from a native pointer
        /// ownsHandle=false means GC won't delete the underlying native object if this C# wrapper goes out of scope
        /// </summary>
        public scopeindex_t(IntPtr handle, bool ownsHandle = true) : base(ownsHandle) => SetHandle(handle);
        #endregion

        #region API
//TODO: %API%
        #endregion

        #region DllImports

        #endregion

        #region ReleaseHandle
        protected override bool ReleaseHandle()
        {
            scopeindex_t__delete(Handle);
            return true;
        }

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern void scopeindex_t__delete(IntPtr target);
        #endregion
    }

﻿    public unsafe static partial class GlobalFunctions
    {
        #region DllImports
        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte _add_overflow_uuu(UInt64 value1, UInt64 value2, UInt64* result);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte _mul_overflow_uuu(UInt64 value1, UInt64 value2, UInt64* result);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Int32 _trailingzeroes_u(UInt64 input_num);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Int32 _leadingzeroes_u(UInt64 input_num);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Int32 _hamming_u(UInt64 input_num);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern void* _aligned_malloc_ss(IntPtr/*size_t*/ alignment, IntPtr/*size_t*/ size);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern SByte* _aligned_malloc_char_ss(IntPtr/*size_t*/ alignment, IntPtr/*size_t*/ size);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern void _aligned_free_v(void* memblock);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern void _aligned_free_char_c(SByte* memblock);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern SByte* _allocate_padded_buffer_s(IntPtr/*size_t*/ length);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt32 _is_not_structural_or_whitespace_u(Byte c);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt32 _is_structural_or_whitespace_u(Byte c);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt32 _hex_to_u32_nocheck_u(Byte* src);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr/*size_t*/ _codepoint_to_utf8_uu(UInt32 cp, Byte* c);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern void _print_with_escapes_u(Byte* src);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern void _print_with_escapes_us(Byte* src, IntPtr/*size_t*/ len);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr/*size_t*/ _jsonminify_usu(Byte* buf, IntPtr/*size_t*/ len, Byte* @out);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr/*size_t*/ _jsonminify_csc(SByte* buf, IntPtr/*size_t*/ len, SByte* @out);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr/*size_t*/ _jsonminify_pc(IntPtr p, SByte* @out);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte _find_structural_bits_usP(Byte* buf, IntPtr/*size_t*/ len, IntPtr pj);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte _find_structural_bits_csP(SByte* buf, IntPtr/*size_t*/ len, IntPtr pj);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte _handle_unicode_codepoint_uu(Byte* src_ptr, Byte* dst_ptr);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte _parse_string_usPuu(Byte* buf, IntPtr/*size_t*/ len, IntPtr pj, UInt32 depth, UInt32 offset);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte _is_integer_c(SByte c);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte _is_not_structural_or_whitespace_or_exponent_or_decimal_or_null_u(Byte c);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte _parse_float_uPub(Byte* buf, IntPtr pj, UInt32 offset, Byte found_minus);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte _parse_large_integer_uPub(Byte* buf, IntPtr pj, UInt32 offset, Byte found_minus);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte _parse_number_uPub(Byte* buf, IntPtr pj, UInt32 offset, Byte found_minus);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern void _init_state_machine_0();

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Int32 _unified_machine_usP(Byte* buf, IntPtr/*size_t*/ len, IntPtr pj);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Int32 _unified_machine_csP(SByte* buf, IntPtr/*size_t*/ len, IntPtr pj);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Int32 _json_parse_usPb(Byte* buf, IntPtr/*size_t*/ len, IntPtr pj, Byte reallocifneeded);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Int32 _json_parse_csPb(SByte* buf, IntPtr/*size_t*/ len, IntPtr pj, Byte reallocifneeded);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern Int32 _json_parse_pP(IntPtr s, IntPtr pj);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr _build_parsed_json_usb(Byte* buf, IntPtr/*size_t*/ len, Byte reallocifneeded);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr _build_parsed_json_csb(SByte* buf, IntPtr/*size_t*/ len, Byte reallocifneeded);

        [DllImport(SimdJsonN.NativeLib, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr _build_parsed_json_p(IntPtr s);
        #endregion
    }
}
