using BenchmarkDotNet.Attributes;

// Strategies: ColdStart, Throughput, Monitoring
[SimpleJob(BenchmarkDotNet.Engines.RunStrategy.ColdStart, iterationCount: 5)]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class MyBenchmarkDemo5
{
    private bool firstCall;

    [Benchmark]
    public void Foo()
    {
        if (firstCall == false)
        {
            firstCall = true;
            Console.WriteLine("// First call");
            Thread.Sleep(1000);
        }
        else
            Thread.Sleep(10);
    }
}