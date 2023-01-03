``` ini

BenchmarkDotNet=v0.13.3, OS=Windows 10 (10.0.19044.2251/21H2/November2021Update)
Intel Core i5-8265U CPU 1.60GHz (Whiskey Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.100
  [Host] : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2

Job=MediumRun  Toolchain=InProcessNoEmitToolchain  IterationCount=15  
LaunchCount=2  WarmupCount=10  

```
|           Method |     Mean |     Error |    StdDev |
|----------------- |---------:|----------:|----------:|
|  SerializeStride | 413.7 ns | 108.31 ns | 162.12 ns |
| SerializeMemPack | 153.6 ns |   6.95 ns |  10.19 ns |
