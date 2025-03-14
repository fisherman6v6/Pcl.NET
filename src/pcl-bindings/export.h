#pragma once

#ifndef EXPORT
    #define EXPORT(rettype) extern "C" __declspec( dllexport ) rettype __cdecl
#endif

#define CONCAT(prefix, fname) prefix##_##fname