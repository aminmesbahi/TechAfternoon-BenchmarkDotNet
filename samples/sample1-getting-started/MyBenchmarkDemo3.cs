using BenchmarkDotNet.Attributes;

[GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class MyBenchmarkDemo3
{
    [BenchmarkCategory("Fast"), Benchmark(Baseline = true)]
    public void Time50() => Thread.Sleep(50);

    [BenchmarkCategory("Fast"), Benchmark]
    public void Time100() => Thread.Sleep(100);

    [BenchmarkCategory("Slow"), Benchmark(Baseline = true)]
    public void Time550() => Thread.Sleep(550);

    [BenchmarkCategory("Slow"), Benchmark]
    public void Time600() => Thread.Sleep(600);
}