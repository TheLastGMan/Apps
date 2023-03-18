#pragma once

using namespace std;

//Action Pointers (Lambda simulation)
#define Action(name) void (*name)(void)
#define Action1(name, in1) void (*name)(in1)
#define Action2(name, in1, in2) void (*name)(in1, in2)
#define Action3(name, in1, in2, in3) void (*name)(in1, in2, in3)
#define Action4(name, in1, in2, in3, in4) void (*name)(in1, in2, in3, in4)
#define Action5(name, in1, in2, in3, in4, in5) void (*name)(in1, in2, in3, in4, in5)
#define Action6(name, in1, in2, in3, in4, in5, in6) void (*name)(in1, in2, in3, in4, in5, in6)
#define Action7(name, in1, in2, in3, in4, in5, in6, in7) void (*name)(in1, in2, in3, in4, in5, in6, in7)
#define Action8(name, in1, in2, in3, in4, in5, in6, in7, in8) void (*name)(in1, in2, in3, in4, in5, in6, in7, in8)

//Function Pointers (Lambda simulation)
#define Func(name, out) out (*name)(void)
#define Func1(name, out, in1) out (*name)(in1)
#define Func2(name, out, in1, in2) out (*name)(in1, in2)
#define Func3(name, out, in1, in2, in3) out (*name)(in1, in2, in3)
#define Func4(name, out, in1, in2, in3, in4) out (*name)(in1, in2, in3, in4)
#define Func5(name, out, in1, in2, in3, in4, in5) out (*name)(in1, in2, in3, in4, in5)
#define Func6(name, out, in1, in2, in3, in4, in5, in6) out (*name)(in1, in2, in3, in4, in5, in6)
#define Func7(name, out, in1, in2, in3, in4, in5, in6, in7) out (*name)(in1, in2, in3, in4, in5, in6, in7)
#define Func8(name, out, in1, in2, in3, in4, in5, in6, in7, in8) out (*name)(in1, in2, in3, in4, in5, in6, in7, in8)

//Predicate Pointers (Lambda simulation)
#define Predicate(name) Func(name, bool)
#define Predicate1(name, in1) Func1(name, bool, in1)
#define Predicate2(name, in1, in2) Func2(name, bool, in1, in2)
#define Predicate3(name, in1, in2, in3) Func3(name, bool, in1, in2, in3)
#define Predicate4(name, in1, in2, in3, in4) Func4(name, bool, in1, in2, in3, in4)
#define Predicate5(name, in1, in2, in3, in4, in5) Func5(name, bool, in1, in2, in3, in4, in5)
#define Predicate6(name, in1, in2, in3, in4, in5, in6) Func6(name, bool, in1, in2, in3, in4, in5, in6)
#define Predicate7(name, in1, in2, in3, in4, in5, in6, in7) Func7(name, bool, in1, in2, in3, in4, in5, in6, in7)
#define Predicate8(name, in1, in2, in3, in4, in5, in6, in7, in8) Func8(name, bool, in1, in2, in3, in4, in5, in6, in7, in8)

//Null values
#define null 0
#define Null null
#ifndef NULL
#define NULL null
#endif

//Pointer
typedef void* IntPtr;
typedef IntPtr object;
typedef IntPtr Object;

#define sbyte char
#define Int8 sbyte
#define byte unsigned char
#define UInt8 byte

#define Int16 short
#define ushort unsigned short
#define UInt16 ushort

#define Int32 int
#define uint unsigned int
#define UInt32 uint

#define Int64 long long				//some weird reason, long is same as int on x86 architecture, long long is 64bits
#define ulong unsigned long long
#define UInt64 ulong
