# Struct Type Dictionary 
- Class 형식의 값에선 unsafe 와 기존 방식 모두 퍼포먼스에 큰 차이는 없다.
- Struct 형식을 값으로 담을 경우 값 형식 차이로 인한 성능차이로 보인다.

## 벤치마크 환경
``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22000.1455/21H2)
Intel Core i7-6700 CPU 3.40GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.101
  [Host]   : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2
  .NET 6.0 : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2


```

## 벤치마크 결과
|                  Method |      Job |  Runtime |     Mean |    Error |   StdDev | Allocated |
|------------------------ |--------- |--------- |---------:|---------:|---------:|----------:|
|         UpdateUserClass | .NET 6.0 | .NET 6.0 | 12.47 ns | 0.336 ns | 0.373 ns |         - |
|  UpdateUserClass_Unsafe | .NET 6.0 | .NET 6.0 | 12.85 ns | 0.342 ns | 0.407 ns |         - |
|        UpdateUserStruct | .NET 6.0 | .NET 6.0 | 38.83 ns | 0.796 ns | 1.239 ns |         - |
| UpdateUserStruct_Unsafe | .NET 6.0 | .NET 6.0 | 18.88 ns | 0.355 ns | 0.296 ns |         - |
|         UpdateUserClass | .NET 7.0 | .NET 7.0 | 10.56 ns | 0.290 ns | 0.485 ns |         - |
|  UpdateUserClass_Unsafe | .NET 7.0 | .NET 7.0 | 12.01 ns | 0.318 ns | 0.390 ns |         - |
|        UpdateUserStruct | .NET 7.0 | .NET 7.0 | 32.84 ns | 0.682 ns | 1.021 ns |         - |
| UpdateUserStruct_Unsafe | .NET 7.0 | .NET 7.0 | 17.88 ns | 0.383 ns | 0.456 ns |         - |
