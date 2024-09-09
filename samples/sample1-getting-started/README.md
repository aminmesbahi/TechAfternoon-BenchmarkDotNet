# Sample 1, Getting Started

1. `dotnet add package BenchmarkDotNet`
2. `dotnet run -c Release`


## MyBenchmarkDemo1
- Get to know the basics of BenchmarkDotNet
- [Benchmark]
- [Benchmark(Description = "Thread.Sleep(15)")]
- [Benchmark(Baseline = true, Description = "Thread.Sleep(10)")]: Baseline benchmarks are used to compare the performance of other benchmarks.

## MyBenchmarkDemo2
- Get to know the benchmark categories
- [DryJob]: Performs a quick run with minimal iterations for faster results, useful for testing benchmark setups.
- [CategoriesColumn]: Adds a column to the benchmark results that displays the categories assigned to each benchmark method.
- [BenchmarkCategory("Awesome")]: Assigns a category to a benchmark method.
- [AnyCategoriesFilter("A", "1")]: Filters benchmarks that have any of the specified categories.

## MyBenchmarkDemo3
- Get to know the benchmark grouping
- [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]: Groups benchmarks by category.
- [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]: Groups benchmarks by parameter values.
- [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]: Groups benchmarks by method name.
- [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByJob)]: Groups benchmarks by job.

## MyBenchmarkDemo4
- Get to know the benchmark custom category discovery
- [CustomCategoryDiscoverer]: A custom category discoverer that assigns a category to a benchmark method based on the method name.

## MyBenchmarkDemo5
- Get to know the benchmark RunStrategy
- [SimpleJob(BenchmarkDotNet.Engines.RunStrategy.ColdStart, iterationCount: 5)]: ColdStart means that the benchmark is run in a cold environment, which is useful for testing the performance of the first run of a method.
- [MinColumn, MaxColumn, MeanColumn, MedianColumn]: Adds columns to the benchmark results that display the minimum, maximum, mean, and median values of the benchmark results.