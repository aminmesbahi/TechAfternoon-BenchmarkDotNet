# Sample 1 — Getting Started

```bash
dotnet run -c Release
```

This sample walks through the fundamentals of BenchmarkDotNet. By the end you'll know how to write your first benchmark, add a baseline for comparison, group methods into categories, and hook into the benchmark lifecycle.

## Demo 1 — The basics

Just decorate any method with `[Benchmark]` and BenchmarkDotNet takes care of the rest. Marking one method as `Baseline = true` tells the runner to compute a ratio for every other method relative to it. You can also set a `Description` to give a benchmark a friendlier name in the results table.

## Demo 2 — Categories and filters

`[BenchmarkCategory]` lets you tag individual methods, and `[AnyCategoriesFilter]` keeps only the methods that match at least one of the listed tags. In this example `B2` is skipped because it doesn't belong to either "A" or "1" — a good way to understand how the filter logic works.

## Demo 3 — Grouping benchmarks

`[GroupBenchmarksBy(ByCategory)]` splits the results table into separate groups per category, and each group gets its own baseline. That makes it easy to compare "Fast" methods against each other and "Slow" methods against each other without the two groups distorting each other's ratios.

## Demo 4 — Custom category discoverer

If the built-in category attributes aren't flexible enough, you can implement `ICategoryDiscoverer` yourself. This demo adds every method's first letter as a category automatically — no per-method attribute needed.

## Demo 5 — Run strategies

`ColdStart` measures performance on the very first call, including JIT warm-up cost. This is useful when you care about startup latency rather than steady-state throughput. The extra statistics columns (`MinColumn`, `MaxColumn`, etc.) help you see the spread across iterations.

## Demo 6 — Benchmark lifecycle

Shows the four lifecycle hooks in order:
- `[GlobalSetup]` — runs once before any iterations start; allocate or load shared state here.
- `[IterationSetup]` — runs before every individual iteration; reset mutable state here.
- `[IterationCleanup]` — runs after every iteration.
- `[GlobalCleanup]` — runs once after all iterations are done; release resources here.

The benchmark itself compares three ways to sum a byte array: a plain scalar loop, `Span<T>`, and LINQ. It also shows the C# 14 `field` keyword on a private semi-auto property.
