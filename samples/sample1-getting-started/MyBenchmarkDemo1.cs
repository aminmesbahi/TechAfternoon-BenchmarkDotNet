using BenchmarkDotNet.Attributes;

// 1: Just create a class
public class MyBenchmarkDemo1
{
    // 2: Decorate a method with the [Benchmark] attribute
    [Benchmark]
    public void Sleep() => Thread.Sleep(5);

    // You can write a description for your method.
    [Benchmark(Description = "Thread.Sleep(15)")]
    public void SleepWithDescription() => Thread.Sleep(15);

    // This will add additional "Ratio" column in the summary table
    // This column contains the mean value of the ratio distribution.

    [Benchmark(Baseline = true, Description = "Thread.Sleep(10)")]
    public void Time10() => Thread.Sleep(10);
}