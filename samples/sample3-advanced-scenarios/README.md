# Sample 3 — Advanced Scenarios

```bash
dotnet run -c Release
```

Covers the deeper features you reach for when you need full control: GC configuration, EventPipe profiling, custom JIT selection, and result ordering. All benchmarks are wired through `BenchmarkSwitcher`, so you can pick exactly what to run from the command line.

```bash
# Run a specific class
dotnet run -c Release -- --filter "*Algo_Md5*"
# List all available benchmarks
dotnet run -c Release -- --list flat
```

## Demo 1 — GC modes and memory allocation

Server GC and Workstation GC behave very differently under allocation pressure. This demo runs the same heap (`new byte[10kB]`) and stack (`stackalloc byte[10kB]`) allocation scenarios across four GC job combinations so the difference shows up clearly in the results.

## Demo 2 — EventPipe profiling

EventPipe is .NET's built-in, cross-platform tracing mechanism. Attaching `[EventPipeProfiler]` to a benchmark class tells BenchmarkDotNet to capture a `.nettrace` file for each run. Available profiles include `CpuSampling`, `GcVerbose`, `GcCollect`, and `Jit`.

## Demo 3 — MD5 vs SHA256 (fluent config)

A classic real-world comparison: which hashing algorithm is faster for a fixed payload? The `IntroFluentConfigBuilder` class shows how to chain job and validator configuration using the fluent API instead of attributes.

## Demo 4 — Custom JIT configuration

`IConfigSource` lets you define an attribute that bakes a custom `IConfig` into a benchmark class. This demo creates jobs for specific JIT compilers via attribute parameters. Note: on .NET 5+ the only available JIT is RyuJIT; `LegacyJit` is a .NET Framework concept.

## Demo 5 — Ranking columns

`[RankColumn]` adds a column that shows each benchmark's relative rank. BenchmarkDotNet supports three numeral systems: Arabic (1, 2, 3), Roman (I, II, III), and Stars (*, **, ***).
