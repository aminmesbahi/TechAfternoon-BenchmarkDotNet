using BenchmarkDotNet.Attributes;

[SimpleJob(BenchmarkDotNet.Engines.RunStrategy.Monitoring, iterationCount: 10, id: "MonitoringJob")]
[MinColumn, Q1Column, Q3Column, MaxColumn]
public class MyBenchmarkDemo1
{
    private Random random = new Random(42);

    [Benchmark]
    public void Foo()
    {
        Thread.Sleep(random.Next(10) * 10);
    }
}