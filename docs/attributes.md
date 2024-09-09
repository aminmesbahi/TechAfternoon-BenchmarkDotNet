# BenchmarkDotNet Attributes:

### 1. `[Benchmark]`
- **Purpose**: Marks a method that should be benchmarked.
- **Usage**: Apply this attribute to methods that contain the code you want to measure. These methods will be executed multiple times to gather reliable performance data.
  
```csharp
[Benchmark]
public void MyMethod()
{
    // Code to be benchmarked
}
```

### 2. `[MemoryDiagnoser]`
- **Purpose**: Adds memory diagnostics to the benchmark results, such as GC (Garbage Collector) counts, allocated memory size, and so on.
- **Usage**: Apply this attribute to a benchmark class to include memory usage data for all benchmarks within that class.
  
```csharp
[MemoryDiagnoser]
public class MyBenchmarkClass
{
    [Benchmark]
    public void MyMethod()
    {
        // Code to be benchmarked
    }
}
```

### 3. `[IterationSetup]` and `[IterationCleanup]`
- **Purpose**: Defines methods to be executed before and after each benchmark iteration.
- **Usage**: Apply these attributes to methods that should run before (`IterationSetup`) and after (`IterationCleanup`) each benchmark iteration. This is useful for preparing a consistent environment for each run.
  
```csharp
[IterationSetup]
public void Setup()
{
    // Code to run before each iteration
}

[IterationCleanup]
public void Cleanup()
{
    // Code to run after each iteration
}
```

### 4. `[GlobalSetup]` and `[GlobalCleanup]`
- **Purpose**: Defines methods to be executed once before and after all benchmark iterations.
- **Usage**: Use these attributes for global setup or teardown logic that runs only once per benchmarked method or class. This is useful for resource allocation/deallocation that needs to occur outside of the benchmark runs.
  
```csharp
[GlobalSetup]
public void Setup()
{
    // Code to run once before all iterations
}

[GlobalCleanup]
public void Cleanup()
{
    // Code to run once after all iterations
}
```

### 5. `[Params]` and `[ParamsSource]`
- **Purpose**: Specifies a set of parameter values for benchmarking methods that accept parameters.
- **Usage**: Apply `[Params]` to fields or properties to run benchmarks with different values. Use `[ParamsSource]` to provide a custom source for parameter values.

```csharp
[Params(10, 100, 1000)]
public int N;

[Benchmark]
public void MyParameterizedMethod()
{
    // Benchmark code that uses the parameter N
}
```

### 6. `[BenchmarkCategory]`
- **Purpose**: Categorizes benchmarks for filtering purposes.
- **Usage**: Use this attribute to assign benchmarks to categories, which allows you to run or analyze specific groups of benchmarks.

```csharp
[BenchmarkCategory("CategoryA", "CategoryB")]
[Benchmark]
public void MyMethod()
{
    // Code to be benchmarked
}
```

### 7. `[MinIterationCount]` and `[MaxIterationCount]`
- **Purpose**: Sets the minimum and maximum number of iterations to be used for a benchmark.
- **Usage**: Use these attributes to control the number of iterations for more precise benchmarking results.
   - [MinIterationCount] ensures that the benchmark runs a minimum number of times to collect meaningful data.
   - [MaxIterationCount] prevents the benchmark from running too long, setting an upper limit.

```csharp
[MinIterationCount(10)]
[MaxIterationCount(100)]
[Benchmark]
public void MyMethod()
{
    // Code to be benchmarked
}
```

### 8. `[Orderer]`
- **Purpose**: Specifies the order in which benchmarks are executed.
- **Usage**: Apply this attribute to change the default order in which benchmarks are run. This can help manage dependencies between benchmarks or optimize the execution order.

```csharp
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class MyBenchmarkClass
{
    [Benchmark]
    public void MyMethod()
    {
        // Code to be benchmarked
    }
}
```

### 9. `[InliningDiagnoser]`
- **Purpose**: Provides diagnostics for method inlining by the Just-In-Time (JIT) compiler.
- **Usage**: Apply this attribute to a benchmark class to analyze whether methods are being inlined by the JIT compiler and how inlining affects performance.
Inlining is a performance optimization where the JIT compiler replaces a method call with the method’s body to eliminate the overhead of the call. However, excessive inlining can increase the code size, leading to a negative impact on performance due to cache misses or other issues.

```csharp
[InliningDiagnoser]
public class MyBenchmarkClass
{
    [Benchmark]
    public void MyMethod()
    {
        // Code to be benchmarked
    }
}
```

### 10. `[SimpleJob]`, `[MediumRunJob]`, `[LongRunJob]`, and Custom Jobs
- **Purpose**: Configures the job that controls how benchmarks are executed, including runtime characteristics, the number of warmups, iterations, etc.
- **Usage**: Apply these attributes to customize the benchmark execution model. `SimpleJob`, `MediumRunJob`, and `LongRunJob` provide predefined configurations, while you can define custom jobs using `[SimpleJob]` with parameters.

```csharp
[SimpleJob(runtimeMoniker: RuntimeMoniker.Net50, launchCount: 1, warmupCount: 3, targetCount: 5)]
public class MyBenchmarkClass
{
    [Benchmark]
    public void MyMethod()
    {
        // Code to be benchmarked
    }
}
```

### 11. `[ThreadingDiagnoser]`
- **Purpose**: Provides threading diagnostics, such as thread count and contention time.
- **Usage**: Use this attribute to analyze the impact of multi-threading in your benchmarks.

```csharp
[ThreadingDiagnoser]
public class MyBenchmarkClass
{
    [Benchmark]
    public void MyMethod()
    {
        // Code to be benchmarked
    }
}
```

### 12. `[Config]`
- **Purpose**: Applies a configuration to the benchmark, which can control various aspects like the type of exporter, logging options, etc.
- **Usage**: Use this attribute with a configuration class that implements the `IConfig` interface to customize the benchmark behavior.

```csharp
[Config(typeof(MyConfigClass))]
public class MyBenchmarkClass
{
    [Benchmark]
    public void MyMethod()
    {
        // Code to be benchmarked
    }
}

public class MyConfigClass : ManualConfig
{
    public MyConfigClass()
    {
        AddDiagnoser(MemoryDiagnoser.Default);
    }
}
```
### 13. `[HardwareCounters]`
- **Purpose**: Captures hardware performance counter data, such as cache misses, branch mispredictions, and more.
- **Usage**: Apply this attribute to a benchmark class or method to gather low-level performance data from specific hardware counters. It can be useful to diagnose performance issues at the hardware level.

```csharp
[HardwareCounters(HardwareCounter.CacheMisses, HardwareCounter.BranchMispredictions)]
public class MyBenchmarkClass
{
    [Benchmark]
    public void MyMethod()
    {
        // Code to be benchmarked
    }
}
```

### 14. `[GarbageCollector]`
- **Purpose**: Configures the behavior of the garbage collector (GC) during benchmarks, such as forcing a specific GC mode or setting GC latency level.
- **Usage**: Apply this attribute to control garbage collection settings for the duration of the benchmarks. This is useful when you want to test how different GC settings affect your code's performance.

```csharp
[GarbageCollector(allowVeryLargeObjects: true, server: true, concurrent: true)]
public class MyBenchmarkClass
{
    [Benchmark]
    public void MyMethod()
    {
        // Code to be benchmarked
    }
}
```

### 15. `[Arguments]`
- **Purpose**: Specifies arguments for parameterized benchmark methods, allowing you to define different input scenarios.
- **Usage**: Use this attribute to provide multiple sets of arguments to a method marked with `[Benchmark]`. This is useful for testing the performance of a method with different inputs.

```csharp
[Benchmark]
[Arguments(10, "example1")]
[Arguments(20, "example2")]
public void MyParameterizedMethod(int value, string name)
{
    // Code to be benchmarked
}
```

### 16. `[OperationsPerInvoke]`
- **Purpose**: Specifies the number of operations performed in a single invocation of the benchmark method.
- **Usage**: Apply this attribute when your benchmark method performs multiple operations that should be considered a single iteration. This helps normalize the results by indicating that each benchmark iteration consists of a certain number of operations.

```csharp
[OperationsPerInvoke(1000)]
[Benchmark]
public void MyMethod()
{
    // Code that performs 1000 operations
}
```

### 17. `[RankColumn]`
- **Purpose**: Adds a rank column to the benchmark output, showing the relative ranking of each benchmark in terms of performance.
- **Usage**: Use this attribute to include a rank column in the benchmark results, providing an easy way to compare the performance of different benchmarks.

```csharp
[RankColumn]
public class MyBenchmarkClass
{
    [Benchmark]
    public void MyMethod()
    {
        // Code to be benchmarked
    }
}
```

### 18. `[ValidationError]`
- **Purpose**: Represents custom validation errors; used with [ValidationMethod]
- **Usage**: This attribute is used internally by `BenchmarkDotNet` to represent a validation error. You typically do not use it directly in your benchmarks; instead, use `[ValidationMethod]` to define custom validation logic.

### 19. `[ValidationMethod]`
- **Purpose**: Marks a method that performs custom validation before running benchmarks.
- **Usage**: Apply this attribute to a method that checks certain conditions or requirements before running the benchmarks. If the method returns a `ValidationError`, the benchmark is not executed. This is useful for ensuring that benchmarks are only run under specific conditions.

```csharp
[ValidationMethod]
public static IEnumerable<ValidationError> Validate(BenchmarkCase benchmarkCase)
{
    if (benchmarkCase.Descriptor.WorkloadMethod.Name.Contains("Invalid"))
        yield return new ValidationError(true, "This benchmark method name should not contain 'Invalid'.");
}
```