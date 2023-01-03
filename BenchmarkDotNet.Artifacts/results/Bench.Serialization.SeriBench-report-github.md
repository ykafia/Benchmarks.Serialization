``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 10 (10.0.19044.2251/21H2/November2021Update)
Intel Core i5-8265U CPU 1.60GHz (Whiskey Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|           Method |     Mean |   Error |   StdDev |
|----------------- |---------:|--------:|---------:|
| SerializeMemPack | 176.3 ns | 5.05 ns | 14.48 ns |
|  SerializeStride |       NA |      NA |       NA |

Benchmarks with issues:
  SeriBench.SerializeStride: DefaultJob
