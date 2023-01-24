# enum toString vs nameof

- enum 이름값을 string 변수로 사용해야할 때, `ToString` 보단 `nameof`를 사용하자.
- enum 은 struct 타입이므로 ToString 사용시 boxing이 발생한다.

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
|       Method |      Job |  Runtime |       Mean |     Error |    StdDev |     Median |
|------------- |--------- |--------- |-----------:|----------:|----------:|-----------:|
| EnumToString | .NET 6.0 | .NET 6.0 | 30.9977 ns | 1.7511 ns | 5.1632 ns | 29.6397 ns |
|       NameOf | .NET 6.0 | .NET 6.0 |  0.1395 ns | 0.0721 ns | 0.2115 ns |  0.0000 ns |
| EnumToString | .NET 7.0 | .NET 7.0 | 26.2810 ns | 1.6668 ns | 4.8884 ns | 24.1122 ns |
|       NameOf | .NET 7.0 | .NET 7.0 |  1.1564 ns | 0.1471 ns | 0.4291 ns |  1.0473 ns |
