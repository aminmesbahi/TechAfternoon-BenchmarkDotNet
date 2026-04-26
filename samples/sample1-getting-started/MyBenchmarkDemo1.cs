using BenchmarkDotNet.Attributes;

public class MyBenchmarkDemo1
{
    [Benchmark]
    public void Sleep() => Thread.Sleep(5);

    [Benchmark(Description = "Thread.Sleep(15)")]
    public void SleepWithDescription() => Thread.Sleep(15);

    [Benchmark(Baseline = true, Description = "Thread.Sleep(10)")]
    public void Time10() => Thread.Sleep(10);
}