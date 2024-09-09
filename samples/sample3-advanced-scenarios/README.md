# Sample 3, Advanced Scenarios

1. `dotnet add package BenchmarkDotNet`
2. `dotnet run -c Release`

## BenchmarkSwitcher
- BenchmarkSwitcher is a tool that allows you to run benchmarks from the command line.


## MyBenchmarkDemo1
- Get to know the Native memory and unsafe code
- WithGcServer: Means the GC is server mode,Servers are usually used in scenarios where the application is long-lived and the workload is consistent.
- [Orderer(SummaryOrderPolicy.FastestToSlowest)]: Means the order of the benchmark results is from fastest to slowest.

## MyBenchmarkDemo2
- Get to know EventPipeProfiler
- EventPipeProfiler: EventPipe is a new low-level tracing API that enables capturing diagnostics events from .NET applications. 
  It is a high-performance, low-impact mechanism for capturing traces that can be used for diagnosing a wide range of issues.


## MyBenchmarkDemo3: Algo_Md5VsSha256
- Compare the performance of MD5 and SHA256 algorithms
- Fluent Config Builder: Use the fluent config builder to configure the benchmark

## MyBenchmarkDemo4:
- Custom Config: Use the custom config to configure the benchmark
- IConfigSource: Is a source of IConfig instances, which can be used to provide custom configurations for the benchmarks.
- Jit.RyuJit: RyuJit is the new 64-bit JIT compiler for .NET. It is the default JIT compiler for .NET Core on x64 and x86 architectures.
- Jit.LegacyJit: LegacyJit is the 64-bit JIT compiler for .NET Framework on x64 and x86 architectures.

## MyBenchmarkDemo5:
- RankingColumn: The column to display in the summary table.
- [RankColumn(NumeralSystem.Arabic)]: NumeralSystem.Arabic is the default numeral system.
- [RankColumn(NumeralSystem.Roman)]: NumeralSystem.Roman is the Roman numeral system.
- [RankColumn(NumeralSystem.Stars)]: NumeralSystem.Stars is the star-based system.