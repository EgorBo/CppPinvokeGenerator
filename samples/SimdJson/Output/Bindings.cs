// This file is auto-generated. Do not edit.

using System;
using System.Runtime.InteropServices;

namespace MyNamespace
{
﻿    public unsafe partial class padded_string : IDisposable
    {
        /// <summary>
        /// Pointer to the underlying native object
        /// </summary>
        public IntPtr Handle { get; private set; }

        /// <summary>
        /// Create padded_string from a native pointer
        /// </summary>
        public padded_string(IntPtr handle) => this.Handle = handle;

        #region DllImports
        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr padded_string_padded_string0();

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr padded_string_padded_string1(Int64/*size_t*/ length);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr padded_string_padded_string2(SByte* data, Int64/*size_t*/ length);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr padded_string_padded_string5(IntPtr o);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void padded_string_swap6(IntPtr target, IntPtr o);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Int64/*size_t*/ padded_string_size7(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Int64/*size_t*/ padded_string_length8(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern SByte* padded_string_data9(IntPtr target);

        #endregion

        #region IDisposable
        private static readonly object DisposeSync = new object();

        public void Dispose()
        {
            if (Handle != IntPtr.Zero)
            {
                lock (DisposeSync)
                {
                    if (Handle != IntPtr.Zero)
                    {
                        padded_string_Dispose(Handle);
                        Handle = IntPtr.Zero;
                    }
                }
            }
        }

        ~padded_string() => Dispose();

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void padded_string_Dispose(IntPtr target);
        #endregion
    }

﻿    public unsafe partial class ParsedJson : IDisposable
    {
        /// <summary>
        /// Pointer to the underlying native object
        /// </summary>
        public IntPtr Handle { get; private set; }

        /// <summary>
        /// Create ParsedJson from a native pointer
        /// </summary>
        public ParsedJson(IntPtr handle) => this.Handle = handle;

        #region DllImports
        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr ParsedJson_ParsedJson0();

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr ParsedJson_ParsedJson2(IntPtr p);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte ParsedJson_allocateCapacity3(IntPtr target, Int64/*size_t*/ len, Int64/*size_t*/ maxdepth);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte ParsedJson_isValid4(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void ParsedJson_deallocate5(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void ParsedJson_init6(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void ParsedJson_write_tape9(IntPtr target, UInt64 val, Byte c);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void ParsedJson_write_tape_s6410(IntPtr target, Int64 i);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void ParsedJson_write_tape_double11(IntPtr target, Double d);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt32 ParsedJson_get_current_loc12(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void ParsedJson_annotate_previousloc13(IntPtr target, UInt32 saved_loc, UInt64 val);

        #endregion

        #region IDisposable
        private static readonly object DisposeSync = new object();

        public void Dispose()
        {
            if (Handle != IntPtr.Zero)
            {
                lock (DisposeSync)
                {
                    if (Handle != IntPtr.Zero)
                    {
                        ParsedJson_Dispose(Handle);
                        Handle = IntPtr.Zero;
                    }
                }
            }
        }

        ~ParsedJson() => Dispose();

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void ParsedJson_Dispose(IntPtr target);
        #endregion
    }

﻿    public unsafe partial class iterator : IDisposable
    {
        /// <summary>
        /// Pointer to the underlying native object
        /// </summary>
        public IntPtr Handle { get; private set; }

        /// <summary>
        /// Create iterator from a native pointer
        /// </summary>
        public iterator(IntPtr handle) => this.Handle = handle;

        #region DllImports
        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr iterator_iterator0(IntPtr pj_);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr iterator_iterator1(IntPtr o);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_isOk3(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Int64/*size_t*/ iterator_get_tape_location4(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Int64/*size_t*/ iterator_get_tape_length5(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Int64/*size_t*/ iterator_get_depth6(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_get_scope_type7(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_move_forward8(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_get_type9(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Int64 iterator_get_integer10(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern SByte* iterator_get_string11(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern UInt32 iterator_get_string_length12(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Double iterator_get_double13(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_is_object_or_array14(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_is_object15(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_is_array16(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_is_string17(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_is_integer18(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_is_double19(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_is_true20(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_is_false21(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_is_null22(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_is_object_or_array23(Byte type);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_move_to_key24(IntPtr target, SByte* key);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_next25(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_prev26(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_up27(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern Byte iterator_down28(IntPtr target);

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void iterator_to_start_scope29(IntPtr target);

        #endregion

        #region IDisposable
        private static readonly object DisposeSync = new object();

        public void Dispose()
        {
            if (Handle != IntPtr.Zero)
            {
                lock (DisposeSync)
                {
                    if (Handle != IntPtr.Zero)
                    {
                        iterator_Dispose(Handle);
                        Handle = IntPtr.Zero;
                    }
                }
            }
        }

        ~iterator() => Dispose();

        [DllImport("simdjson.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void iterator_Dispose(IntPtr target);
        #endregion
    }

}
