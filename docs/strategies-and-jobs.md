# Benchmark Jabs & Strategies

BenchmarkDotNet provides several **jobs** and **strategies** to control how benchmarks are executed.

A **job** in BenchmarkDotNet defines a configuration for running benchmarks, including settings like the runtime environment, platform, JIT compiler, and the number of iterations.

A **strategy** specifies how BenchmarkDotNet measures and collects data to ensure accurate and reliable results.

## Jobs

### 1. [SimpleJob]

- **Purpose**: Provides a simple and customizable job for running benchmarks.
- **Usage**: Used for quickly configuring benchmarks with custom parameters such as runtime, warmup c

### 2. [MediumRunJob]

- **Purpose**: A predefined job optimized for balanced benchmarking. It provides a moderate number of iterations to achieve reliable results without taking too much time.
- **Usage**: Suitable for most general-purpose benchmarks.
- **Explanation**: The MediumRunJob runs **15 warmup** iterations and **100 target iterations** by default.

### 3. [DryJob]

- **Purpose**: A job that runs the benchmark code **only once without any warmup or iteration**. This is useful for quick testing or debugging the benchmark itself.
- **Usage**: Not intended for actual benchmarking since it does not provide statistically significant results.
- **Explanation**: Runs a single iteration with no warmup to verify that the benchmark can be executed without errors.

### 4. [ShortRunJob]

- **Purpose**: A predefined job that provides a quick and less accurate benchmark run. It is useful when you need results fast.
- *###*Usage**: Suitable for scenarios where speed is more critical than accuracy.
- **Explanation**: Runs 3 warmup iterations and 10 target iterations by default.

### 5. [CoreJob] / [ClrJob] / [MonoJob]

- **Purpose**: Defines jobs for specific
- **runtimes**:
  - **CoreJob**: Targets .NET Core.
  - **ClrJob**: Targets the .NET Framework.
  - **MonoJob**: Targets the Mono runtime.
- **Usage**: Use these jobs to compare performance across different runtimes.

```csharp
[CoreJob, ClrJob, MonoJob]
public class MyBenchmarkClass
{
    [Benchmark]
    public void MyMethod()
    {
        // Code to be benchmarked
    }
}
```

---

## Strategies

BenchmarkDotNet uses different strategies to measure and collect benchmarking data to ensure accuracy and reliability:

### 1. Throughput

- **Purpose**: Measures the total time taken to execute a certain number of operations and calculates the throughput.
- **Usage**: Used by default in most cases. It measures the **time** taken to execute multiple iterations and calculates the average throughput (operations per second).
- **Explanation**: This strategy is suitable for scenarios where you want to measure the overall speed of the code, such as in I/O-bound or long-running CPU tasks.

### 2. ColdStart

- **Purpose**: Focuses on measuring the cold start time of code, which is the time it takes for the first execution.
- **Usage**: Suitable for scenarios where the initial execution time is critical, such as in startup performance or initialization routines.
- **Explanation**: This strategy runs the benchmark multiple times, discarding subsequent runs to focus on the cold start time.

### 3. Monitoring

- **Purpose**: Provides continuous monitoring of benchmarks for a long period to observe performance trends over time.
- **Usage**: Suitable for long-running benchmarks or for detecting performance regressions and changes over extended periods.
- **Explanation**: This strategy is less commonly used and is more focused on continuous performance monitoring rather than quick benchmarking.
