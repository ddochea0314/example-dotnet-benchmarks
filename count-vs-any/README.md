# count vs any

- 특정 조건에 대한 값이 존재하는지 유무를 따질 땐, `Count()` 보단 `Any()`를 사용하는 것이 좋다.
- 조건은 `Where()`로 처리하는게 더 유리하다.

``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 11 (10.0.22000.1335/21H2)
Intel Core i7-6700 CPU 3.40GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.101
  [Host]   : .NET 6.0.12 (6.0.1222.56807), X64 RyuJIT AVX2
  .NET 6.0 : .NET 6.0.12 (6.0.1222.56807), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2


```
|                Method |      Job |  Runtime |        Mean |      Error |     StdDev |      Median |   Gen0 | Allocated |
|---------------------- |--------- |--------- |------------:|-----------:|-----------:|------------:|-------:|----------:|
|      IsExistsUseCount | .NET 6.0 | .NET 6.0 |    12.66 ns |   0.305 ns |   0.889 ns |    12.39 ns |      - |         - |
|        IsExistsUseAny | .NET 6.0 | .NET 6.0 |    12.81 ns |   0.288 ns |   0.413 ns |    12.78 ns |      - |         - |
| IsItem100ExistsCount1 | .NET 6.0 | .NET 6.0 | 7,031.76 ns | 138.620 ns | 198.804 ns | 7,025.99 ns | 0.0076 |      32 B |
| IsItem100ExistsCount2 | .NET 6.0 | .NET 6.0 | 2,485.07 ns |  49.684 ns |  72.826 ns | 2,463.69 ns | 0.0114 |      48 B |
|   IsItem100ExistsAny1 | .NET 6.0 | .NET 6.0 |   698.90 ns |  13.834 ns |  20.706 ns |   695.52 ns | 0.0076 |      32 B |
|   IsItem100ExistsAny2 | .NET 6.0 | .NET 6.0 |   323.11 ns |   5.399 ns |   6.428 ns |   324.02 ns | 0.0114 |      48 B |
|      IsExistsUseCount | .NET 7.0 | .NET 7.0 |    10.38 ns |   0.244 ns |   0.358 ns |    10.45 ns |      - |         - |
|        IsExistsUseAny | .NET 7.0 | .NET 7.0 |    13.35 ns |   0.300 ns |   0.613 ns |    13.25 ns |      - |         - |
| IsItem100ExistsCount1 | .NET 7.0 | .NET 7.0 | 7,276.72 ns | 143.112 ns | 218.547 ns | 7,234.79 ns | 0.0076 |      32 B |
| IsItem100ExistsCount2 | .NET 7.0 | .NET 7.0 | 3,471.19 ns |  69.154 ns |  67.918 ns | 3,484.87 ns | 0.0114 |      48 B |
|   IsItem100ExistsAny1 | .NET 7.0 | .NET 7.0 |   733.56 ns |  14.655 ns |  21.018 ns |   725.20 ns | 0.0076 |      32 B |
|   IsItem100ExistsAny2 | .NET 7.0 | .NET 7.0 |   329.38 ns |   6.588 ns |   7.586 ns |   331.38 ns | 0.0114 |      48 B |
