# Sample 2 — Intermediate Scenarios

```bash
dotnet run -c Release
```

Builds on the basics with more realistic configurations: choosing the right run strategy for your workload, exporting results in multiple formats, tuning power plans, feeding data via params and argument sources, and benchmarking async code.

## Demo 1 — Monitoring strategy

`RunStrategy.Monitoring` is designed for longer-running methods (100 ms+). Unlike `Throughput`, it doesn't try to pack multiple invocations into a single measurement window — it just times each call directly. The `id` parameter gives the job a name that shows up in the results table.

## Demo 2 — Exporters

BenchmarkDotNet can export results in almost any format you need — CSV, JSON, XML, Markdown (GitHub/StackOverflow/Atlassian flavours), HTML, AsciiDoc, and R plot data. This demo stacks every available exporter so you can see what each one produces in the `BenchmarkDotNet.Artifacts` folder.

## Demo 3 — Power plans

Windows power plans have a measurable effect on CPU-bound benchmarks. This demo runs the same workload under every built-in power plan (from `PowerSaver` to `UltimatePerformance`) so you can see exactly how much difference they make.

## Demo 4–7 — Params and Arguments

These four demos cover the different ways to feed input values into benchmarks:
- `[Params]` injects values into a property — BenchmarkDotNet creates a separate run for each combination.
- `Priority` controls the order columns appear in the results table (lower value = leftmost).
- `[Arguments]` passes values directly to benchmark method parameters.
- `[ArgumentsSource]` reads values from a method or property, useful when you need dynamic or complex inputs.

## Demo 8–9 — ArgumentsSource and ParamsSource

When inline `[Arguments]` isn't enough, point `[ArgumentsSource]` at an `IEnumerable<object[]>` for multiple parameters, or `IEnumerable<object>` for a single parameter. `[ParamsSource]` does the same for class-level properties and fields.

## Demo 10 — Async benchmarks

BenchmarkDotNet understands `async Task`, `async Task<T>`, and `async ValueTask<T>` natively — the runner awaits the returned task automatically. This demo compares four async patterns: a plain `Task.Delay`, `Task.Run` for CPU work on the thread pool, `ValueTask` to avoid heap allocation, and `Task.WhenAll` for concurrent fan-out.

