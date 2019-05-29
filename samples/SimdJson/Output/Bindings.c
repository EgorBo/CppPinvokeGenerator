// This file is auto-generated. Do not edit.

#if (defined WIN32 || defined _WIN32)
#define EXPORTS(returntype) extern "C" __declspec(dllexport) returntype __cdecl
#else
#define EXPORTS(returntype) extern "C" __attribute__((visibility("default"))) returntype
#endif

#include "simdjson.h"
EXPORTS(padded_string*) padded_string_padded_string0() { return new padded_string(); }

EXPORTS(padded_string*) padded_string_padded_string1(size_t length) { return new padded_string(length); }

EXPORTS(padded_string*) padded_string_padded_string2(char* data, size_t length) { return new padded_string(data, length); }

EXPORTS(padded_string*) padded_string_padded_string5(const padded_string& o) { return new padded_string(o); }

EXPORTS(void) padded_string_swap6(padded_string* target, padded_string& o) { target->swap(o); }

EXPORTS(size_t) padded_string_size7(padded_string* target) { return target->size(); }

EXPORTS(size_t) padded_string_length8(padded_string* target) { return target->length(); }

EXPORTS(char*) padded_string_data9(padded_string* target) { return target->data(); }

EXPORTS(ParsedJson*) ParsedJson_ParsedJson0() { return new ParsedJson(); }

EXPORTS(ParsedJson*) ParsedJson_ParsedJson2(const ParsedJson& p) { return new ParsedJson(p); }

EXPORTS(bool) ParsedJson_allocateCapacity3(ParsedJson* target, size_t len, size_t maxdepth) { return target->allocateCapacity(len, maxdepth); }

EXPORTS(bool) ParsedJson_isValid4(ParsedJson* target) { return target->isValid(); }

EXPORTS(void) ParsedJson_deallocate5(ParsedJson* target) { target->deallocate(); }

EXPORTS(void) ParsedJson_init6(ParsedJson* target) { target->init(); }

EXPORTS(void) ParsedJson_write_tape9(ParsedJson* target, uint64_t val, uint8_t c) { target->write_tape(val, c); }

EXPORTS(void) ParsedJson_write_tape_s6410(ParsedJson* target, int64_t i) { target->write_tape_s64(i); }

EXPORTS(void) ParsedJson_write_tape_double11(ParsedJson* target, double d) { target->write_tape_double(d); }

EXPORTS(uint32_t) ParsedJson_get_current_loc12(ParsedJson* target) { return target->get_current_loc(); }

EXPORTS(void) ParsedJson_annotate_previousloc13(ParsedJson* target, uint32_t saved_loc, uint64_t val) { target->annotate_previousloc(saved_loc, val); }

EXPORTS(ParsedJson::iterator*) iterator_iterator0(ParsedJson& pj_) { return new ParsedJson::iterator(pj_); }

EXPORTS(ParsedJson::iterator*) iterator_iterator1(const iterator& o) { return new ParsedJson::iterator(o); }

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

