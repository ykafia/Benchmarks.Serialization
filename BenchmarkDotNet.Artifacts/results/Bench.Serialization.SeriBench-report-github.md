``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 10 (10.0.14393.5246/1607/AnniversaryUpdate/Redstone1), VM=VMware
Intel Xeon CPU E5-2698 v3 2.30GHz, 32 CPU, 32 logical and 32 physical cores
Frequency=2243495 Hz, Resolution=445.7331 ns, Timer=TSC
.NET SDK=7.0.101
  [Host]     : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2


```
|           Method |     Mean |    Error |   StdDev |   Gen0 | Allocated |
|----------------- |---------:|---------:|---------:|-------:|----------:|
|  SerializeStride | 538.9 ns | 10.59 ns | 15.86 ns | 0.0744 |    1560 B |
| SerializeMemPack | 184.1 ns |  3.61 ns |  4.69 ns | 0.0026 |      56 B |
