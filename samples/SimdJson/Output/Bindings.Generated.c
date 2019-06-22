// This file is auto-generated. Do not edit.

#if (defined WIN32 || defined _WIN32)
#define EXPORTS(returntype) extern "C" __declspec(dllexport) returntype __cdecl
#else
#define EXPORTS(returntype) extern "C" __attribute__((visibility("default"))) returntype
#endif

#include "simdjson.h"

/************* Type: padded_string *************/

EXPORTS(padded_string*) padded_string_padded_string0() { return new padded_string(); }

EXPORTS(padded_string*) padded_string_padded_string1(size_t length) { return new padded_string(length); }

EXPORTS(padded_string*) padded_string_padded_string2(char* data, size_t length) { return new padded_string(data, length); }

//NOT_BOUND:  public padded_string(basic_string s)

//NOT_BOUND:  public padded_string(padded_string && o)

EXPORTS(padded_string*) padded_string_padded_string5(const padded_string& o) { return new padded_string(o); }

EXPORTS(void) padded_string_swap6(padded_string* target, padded_string& o) { target->swap(o); }

EXPORTS(size_t) padded_string_size7(padded_string* target) { return target->size(); }

EXPORTS(size_t) padded_string_length8(padded_string* target) { return target->length(); }

EXPORTS(char*) padded_string_data9(padded_string* target) { return target->data(); }

//NOT_BOUND:  private padded_string& operator=(const padded_string& o)

[EXPORT(void)] padded_string__delete(padded_string* target) { delete target; }

/************* Type: ParsedJson *************/

EXPORTS(ParsedJson*) ParsedJson_ParsedJson0() { return new ParsedJson(); }

//NOT_BOUND:  public ParsedJson(ParsedJson && p)

EXPORTS(ParsedJson*) ParsedJson_ParsedJson2(const ParsedJson& p) { return new ParsedJson(p); }

EXPORTS(bool) ParsedJson_allocateCapacity3(ParsedJson* target, size_t len, size_t maxdepth) { return target->allocateCapacity(len, maxdepth); }

EXPORTS(bool) ParsedJson_isValid4(ParsedJson* target) { return target->isValid(); }

EXPORTS(void) ParsedJson_deallocate5(ParsedJson* target) { target->deallocate(); }

EXPORTS(void) ParsedJson_init6(ParsedJson* target) { target->init(); }

//NOT_BOUND:  public bool printjson(basic_ostream& os)

//NOT_BOUND:  public bool dump_raw_tape(basic_ostream& os)

EXPORTS(void) ParsedJson_write_tape9(ParsedJson* target, uint64_t val, uint8_t c) { target->write_tape(val, c); }

EXPORTS(void) ParsedJson_write_tape_s6410(ParsedJson* target, int64_t i) { target->write_tape_s64(i); }

EXPORTS(void) ParsedJson_write_tape_double11(ParsedJson* target, double d) { target->write_tape_double(d); }

EXPORTS(uint32_t) ParsedJson_get_current_loc12(ParsedJson* target) { return target->get_current_loc(); }

EXPORTS(void) ParsedJson_annotate_previousloc13(ParsedJson* target, uint32_t saved_loc, uint64_t val) { target->annotate_previousloc(saved_loc, val); }

//NOT_BOUND:  private ParsedJson& operator=(const ParsedJson& o)

[EXPORT(void)] ParsedJson__delete(ParsedJson* target) { delete target; }

/************* Type: ParsedJson::InvalidJSON *************/

EXPORTS(const char*) InvalidJSON_what0(ParsedJson::InvalidJSON* target) { return target->what(); }

[EXPORT(void)] InvalidJSON__delete(ParsedJson::InvalidJSON* target) { delete target; }

/************* Type: ParsedJson::iterator *************/

EXPORTS(ParsedJson::iterator*) iterator_iterator0(ParsedJson& pj_) { return new ParsedJson::iterator(pj_); }

EXPORTS(ParsedJson::iterator*) iterator_iterator1(const iterator& o) { return new ParsedJson::iterator(o); }

//NOT_BOUND:  public iterator(ParsedJson::iterator && o)

EXPORTS(bool) iterator_isOk3(ParsedJson::iterator* target) { return target->isOk(); }

EXPORTS(size_t) iterator_get_tape_location4(ParsedJson::iterator* target) { return target->get_tape_location(); }

EXPORTS(size_t) iterator_get_tape_length5(ParsedJson::iterator* target) { return target->get_tape_length(); }

EXPORTS(size_t) iterator_get_depth6(ParsedJson::iterator* target) { return target->get_depth(); }

EXPORTS(uint8_t) iterator_get_scope_type7(ParsedJson::iterator* target) { return target->get_scope_type(); }

EXPORTS(bool) iterator_move_forward8(ParsedJson::iterator* target) { return target->move_forward(); }

EXPORTS(uint8_t) iterator_get_type9(ParsedJson::iterator* target) { return target->get_type(); }

EXPORTS(int64_t) iterator_get_integer10(ParsedJson::iterator* target) { return target->get_integer(); }

EXPORTS(const char*) iterator_get_string11(ParsedJson::iterator* target) { return target->get_string(); }

EXPORTS(uint32_t) iterator_get_string_length12(ParsedJson::iterator* target) { return target->get_string_length(); }

EXPORTS(double) iterator_get_double13(ParsedJson::iterator* target) { return target->get_double(); }

EXPORTS(bool) iterator_is_object_or_array14(ParsedJson::iterator* target) { return target->is_object_or_array(); }

EXPORTS(bool) iterator_is_object15(ParsedJson::iterator* target) { return target->is_object(); }

EXPORTS(bool) iterator_is_array16(ParsedJson::iterator* target) { return target->is_array(); }

EXPORTS(bool) iterator_is_string17(ParsedJson::iterator* target) { return target->is_string(); }

EXPORTS(bool) iterator_is_integer18(ParsedJson::iterator* target) { return target->is_integer(); }

EXPORTS(bool) iterator_is_double19(ParsedJson::iterator* target) { return target->is_double(); }

EXPORTS(bool) iterator_is_true20(ParsedJson::iterator* target) { return target->is_true(); }

EXPORTS(bool) iterator_is_false21(ParsedJson::iterator* target) { return target->is_false(); }

EXPORTS(bool) iterator_is_null22(ParsedJson::iterator* target) { return target->is_null(); }

EXPORTS(bool) iterator_is_object_or_array23(uint8_t type) { return ParsedJson::iterator::is_object_or_array(type); }

EXPORTS(bool) iterator_move_to_key24(ParsedJson::iterator* target, const char* key) { return target->move_to_key(key); }

EXPORTS(bool) iterator_next25(ParsedJson::iterator* target) { return target->next(); }

EXPORTS(bool) iterator_prev26(ParsedJson::iterator* target) { return target->prev(); }

EXPORTS(bool) iterator_up27(ParsedJson::iterator* target) { return target->up(); }

EXPORTS(bool) iterator_down28(ParsedJson::iterator* target) { return target->down(); }

EXPORTS(void) iterator_to_start_scope29(ParsedJson::iterator* target) { target->to_start_scope(); }

//NOT_BOUND:  public bool print(basic_ostream& os, bool escape_strings = true) const

//NOT_BOUND:  private iterator& operator=(const iterator& other)

[EXPORT(void)] iterator__delete(ParsedJson::iterator* target) { delete target; }

/************* Type: ParsedJson::iterator::scopeindex_t *************/

[EXPORT(void)] scopeindex_t__delete(ParsedJson::iterator::scopeindex_t* target) { delete target; }

/************* Global functions: *************/

EXPORTS(bool) _add_overflow0(uint64_t value1, uint64_t value2, uint64_t* result) { return add_overflow(value1, value2, result); }

EXPORTS(bool) _mul_overflow1(uint64_t value1, uint64_t value2, uint64_t* result) { return mul_overflow(value1, value2, result); }

EXPORTS(int) _trailingzeroes2(uint64_t input_num) { return trailingzeroes(input_num); }

EXPORTS(int) _leadingzeroes3(uint64_t input_num) { return leadingzeroes(input_num); }

EXPORTS(int) _hamming4(uint64_t input_num) { return hamming(input_num); }

EXPORTS(void*) _aligned_malloc5(size_t alignment, size_t size) { return aligned_malloc(alignment, size); }

EXPORTS(char*) _aligned_malloc_char6(size_t alignment, size_t size) { return aligned_malloc_char(alignment, size); }

EXPORTS(void) _aligned_free7(void* memblock) { aligned_free(memblock); }

EXPORTS(void) _aligned_free_char8(char* memblock) { aligned_free_char(memblock); }

EXPORTS(char*) _allocate_padded_buffer9(size_t length) { return allocate_padded_buffer(length); }

EXPORTS(uint32_t) _is_not_structural_or_whitespace10(uint8_t c) { return is_not_structural_or_whitespace(c); }

EXPORTS(uint32_t) _is_structural_or_whitespace11(uint8_t c) { return is_structural_or_whitespace(c); }

EXPORTS(uint32_t) _hex_to_u32_nocheck12(const uint8_t* src) { return hex_to_u32_nocheck(src); }

EXPORTS(size_t) _codepoint_to_utf813(uint32_t cp, uint8_t* c) { return codepoint_to_utf8(cp, c); }

EXPORTS(void) _print_with_escapes14(const unsigned char* src) { print_with_escapes(src); }

//NOT_BOUND:  static void print_with_escapes(const unsigned char* src, basic_ostream& os)

EXPORTS(void) _print_with_escapes16(const unsigned char* src, size_t len) { print_with_escapes(src, len); }

//NOT_BOUND:  static void print_with_escapes(const unsigned char* src, basic_ostream& os, size_t len)

//NOT_BOUND:  static void print_with_escapes(const char* src, basic_ostream& os)

//NOT_BOUND:  static void print_with_escapes(const char* src, basic_ostream& os, size_t len)

//NOT_BOUND:  padded_string get_corpus(const const basic_string& filename)

EXPORTS(size_t) _jsonminify21(const uint8_t* buf, size_t len, uint8_t* out) { return jsonminify(buf, len, out); }

EXPORTS(size_t) _jsonminify22(const char* buf, size_t len, char* out) { return jsonminify(buf, len, out); }

//NOT_BOUND:  static size_t jsonminify(const const basic_string_view& p, char* out)

EXPORTS(size_t) _jsonminify24(const padded_string& p, char* out) { return jsonminify(p, out); }

//NOT_BOUND:  void dumpbits_always(uint64_t v, const const basic_string& msg)

//NOT_BOUND:  void dumpbits32_always(uint32_t v, const const basic_string& msg)

EXPORTS(bool) _find_structural_bits27(const uint8_t* buf, size_t len, ParsedJson& pj) { return find_structural_bits(buf, len, pj); }

EXPORTS(bool) _find_structural_bits28(const char* buf, size_t len, ParsedJson& pj) { return find_structural_bits(buf, len, pj); }

EXPORTS(bool) _handle_unicode_codepoint29(const uint8_t** src_ptr, uint8_t** dst_ptr) { return handle_unicode_codepoint(src_ptr, dst_ptr); }

EXPORTS(bool) _parse_string30(const uint8_t* buf, size_t len, ParsedJson& pj, const uint32_t depth, uint32_t offset) { return parse_string(buf, len, pj, depth, offset); }

EXPORTS(bool) _is_integer31(char c) { return is_integer(c); }

EXPORTS(bool) _is_not_structural_or_whitespace_or_exponent_or_decimal_or_null32(unsigned char c) { return is_not_structural_or_whitespace_or_exponent_or_decimal_or_null(c); }

EXPORTS(bool) _parse_float33(const const uint8_t* buf, ParsedJson& pj, const uint32_t offset, bool found_minus) { return parse_float(buf, pj, offset, found_minus); }

EXPORTS(bool) _parse_large_integer34(const const uint8_t* buf, ParsedJson& pj, const uint32_t offset, bool found_minus) { return parse_large_integer(buf, pj, offset, found_minus); }

EXPORTS(bool) _parse_number35(const const uint8_t* buf, ParsedJson& pj, const uint32_t offset, bool found_minus) { return parse_number(buf, pj, offset, found_minus); }

EXPORTS(void) _init_state_machine36() { init_state_machine(); }

EXPORTS(int) _unified_machine37(const uint8_t* buf, size_t len, ParsedJson& pj) { return unified_machine(buf, len, pj); }

EXPORTS(int) _unified_machine38(const char* buf, size_t len, ParsedJson& pj) { return unified_machine(buf, len, pj); }

EXPORTS(int) _json_parse39(const uint8_t* buf, size_t len, ParsedJson& pj, bool reallocifneeded) { return json_parse(buf, len, pj, reallocifneeded); }

EXPORTS(int) _json_parse40(const char* buf, size_t len, ParsedJson& pj, bool reallocifneeded) { return json_parse(buf, len, pj, reallocifneeded); }

//NOT_BOUND:  int json_parse(const const basic_string& s, ParsedJson& pj)

EXPORTS(int) _json_parse42(const padded_string& s, ParsedJson& pj) { return json_parse(s, pj); }

EXPORTS(ParsedJson) _build_parsed_json43(const uint8_t* buf, size_t len, bool reallocifneeded) { return build_parsed_json(buf, len, reallocifneeded); }

EXPORTS(ParsedJson) _build_parsed_json44(const char* buf, size_t len, bool reallocifneeded) { return build_parsed_json(buf, len, reallocifneeded); }

//NOT_BOUND:  ParsedJson build_parsed_json(const const basic_string& s)

EXPORTS(ParsedJson) _build_parsed_json46(const padded_string& s) { return build_parsed_json(s); }

