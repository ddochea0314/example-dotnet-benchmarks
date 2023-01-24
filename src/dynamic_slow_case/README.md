# dynamic slow case

- 느리다. 가급적 쓰지 않는게 좋다.
- 안느릴 수 있는 케이스를 찾기가 어렵다.
- 그나마 ()를 이용한 cast 보단 is, as 를 이용한 형식 체크 값 반환이 속도가 빠르다.

## 벤치마크 환경
``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22000.1335/21H2)
Intel Core i7-6700 CPU 3.40GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.101
  [Host]   : .NET 6.0.12 (6.0.1222.56807), X64 RyuJIT AVX2
  .NET 6.0 : .NET 6.0.12 (6.0.1222.56807), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2

  
```

## 벤치마크 결과
|                              Method |      Job |  Runtime |      Mean |     Error |    StdDev |    Median |
|------------------------------------ |--------- |--------- |----------:|----------:|----------:|----------:|
|               ReturnStringValueCall | .NET 6.0 | .NET 6.0 | 0.3204 ns | 0.0966 ns | 0.2849 ns | 0.3017 ns |
|              ReturnDynamicValueCall | .NET 6.0 | .NET 6.0 | 7.6210 ns | 0.3945 ns | 1.1631 ns | 7.3036 ns |
|      ReturnDynamicValueCallWithCast | .NET 6.0 | .NET 6.0 | 8.0942 ns | 0.1606 ns | 0.3094 ns | 8.0685 ns |
| ReturnDynamicValueCallWithCastAndIs | .NET 6.0 | .NET 6.0 | 0.3678 ns | 0.1016 ns | 0.0951 ns | 0.3956 ns |
| ReturnDynamicValueCallWithCastAndAs | .NET 6.0 | .NET 6.0 | 0.4803 ns | 0.0961 ns | 0.1068 ns | 0.4769 ns |
|               ReturnStringValueCall | .NET 7.0 | .NET 7.0 | 1.1536 ns | 0.1041 ns | 0.1877 ns | 1.1292 ns |
|              ReturnDynamicValueCall | .NET 7.0 | .NET 7.0 | 8.4676 ns | 0.1690 ns | 0.2824 ns | 8.4751 ns |
|      ReturnDynamicValueCallWithCast | .NET 7.0 | .NET 7.0 | 9.1786 ns | 0.2392 ns | 0.7016 ns | 8.9976 ns |
| ReturnDynamicValueCallWithCastAndIs | .NET 7.0 | .NET 7.0 | 1.2476 ns | 0.1111 ns | 0.2003 ns | 1.2355 ns |
| ReturnDynamicValueCallWithCastAndAs | .NET 7.0 | .NET 7.0 | 1.5061 ns | 0.1119 ns | 0.2408 ns | 1.4522 ns |
