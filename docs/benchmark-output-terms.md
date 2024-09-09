# Benchmark's output terminology:

### 1. **OverheadJitting**
- **Description**: Measures the overhead caused by the JIT (Just-In-Time) compilation of the benchmarking infrastructure itself.
- **Purpose**: Before running the actual benchmarks, `BenchmarkDotNet` measures the time taken for the .NET runtime to compile the code related to its own benchmarking logic (excluding the code you want to benchmark). This helps separate the benchmark framework's overhead from the actual code under test.
- **Explanation**: This step is important to understand the base overhead that is not related to the user's code. It allows `BenchmarkDotNet` to ensure that the infrastructure's JIT overhead does not affect the benchmark results.

### 2. **WorkloadJitting**
- **Description**: Measures the time taken for the JIT compilation of the actual workload (the code you want to benchmark).
- **Purpose**: The code that is being benchmarked is also subject to JIT compilation. This step measures how long it takes for the JIT compiler to compile the code under test.
- **Explanation**: This step provides insight into the JIT compilation cost of your benchmarked methods. It is useful to know if your code has a high JIT overhead or if it can be improved.

### 3. **WorkloadPilot**
- **Description**: Performs an initial "pilot" run of the workload to determine the optimal number of iterations and repetitions.
- **Purpose**: To get a rough estimate of how much time the workload takes. `BenchmarkDotNet` uses this information to adjust the number of iterations, repetitions, and warmups needed for reliable measurement.
- **Explanation**: This step allows `BenchmarkDotNet` to determine a good strategy for running the actual benchmarks. By understanding the approximate time a single execution takes, the tool can decide how many times to run it to gather statistically significant data.

### 4. **OverheadWarmup**
- **Description**: Warms up the benchmarking infrastructure by executing the overhead multiple times.
- **Purpose**: To ensure that the benchmarking environment (including the BenchmarkDotNet harness itself) is in a "steady state" and any JIT or initialization costs related to the framework itself are stabilized.
- **Explanation**: This step helps to make sure that any initialization or JIT compilation costs of the benchmark harness are not mistakenly included in the measurement of the actual benchmarked code.

### 5. **OverheadActual**
- **Description**: Measures the actual overhead time of the benchmarking infrastructure without executing the workload.
- **Purpose**: To quantify the precise amount of time spent by the benchmarking harness itself during the actual benchmarking process.
- **Explanation**: This step confirms the amount of time consumed by the `BenchmarkDotNet` framework, which is then subtracted from the total time to ensure that only the workload time is reported in the final results.

### 6. **WorkloadWarmup**
- **Description**: Executes the benchmarked workload multiple times to warm up the code and prepare it for accurate measurement.
- **Purpose**: To ensure that the JIT compilation of the benchmarked code is completed and that any caching, memory allocation, or other runtime effects are stabilized before actual measurements are taken.
- **Explanation**: This step aims to simulate a "real-world" steady state. The first few runs of a method can be slower due to JIT compilation, initial cache misses, or other runtime factors. Warmup iterations are excluded from the final measurement to avoid skewing the results.

### 7. **WorkloadActual**
- **Description**: Performs the actual benchmark measurement after the warmup phase.
- **Purpose**: To accurately measure the time taken by the workload (the code being benchmarked) in a stabilized environment, without any JIT or initialization costs affecting the results.
- **Explanation**: This is the most critical phase where the real benchmarking occurs. `BenchmarkDotNet` executes the workload multiple times, collects data, and uses statistical methods to determine the mean, median, standard deviation, and other metrics to present the benchmark results accurately.

### 8. **WorkloadResult**
- **Description**: Summarizes the results of the benchmark.
- **Purpose**: To present the final statistics of the workload execution, such as the mean execution time, error margins, standard deviation, and other relevant performance metrics.
- **Explanation**: This step provides a comprehensive view of the benchmark results, allowing you to understand how your code performs in terms of execution time, stability, and predictability. It includes the final adjusted results after removing any measured overhead and applying statistical analysis to ensure reliability.

### Summary of the Benchmark Steps

- **OverheadJitting** and **OverheadActual** steps measure the performance costs related to the benchmarking tool itself.
- **WorkloadJitting**, **WorkloadPilot**, **WorkloadWarmup**, **WorkloadActual**, and **WorkloadResult** steps are focused on accurately measuring and reporting the performance of the code you want to benchmark.