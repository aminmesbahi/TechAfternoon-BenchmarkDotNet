using BenchmarkDotNet.Attributes;
// If a benchmark method takes at least 100ms, you can also use the Monitoring strategy. 
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