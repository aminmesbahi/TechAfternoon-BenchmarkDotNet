using BenchmarkDotNet.Attributes;

//  Group the benchmarks into categories and filter them by categories
[DryJob]
[CategoriesColumn]
[BenchmarkCategory("Awesome")]
[AnyCategoriesFilter("A", "1")]
public class MyBenchmarkDemo2
{
    [Benchmark]
    [BenchmarkCategory("A", "1")]
    public void A1() => Thread.Sleep(10); // Will be benchmarked

    [Benchmark]
    [BenchmarkCategory("A", "2")]
    public void A2() => Thread.Sleep(10); // Will be benchmarked

    [Benchmark]
    [BenchmarkCategory("B", "1")]
    public void B1() => Thread.Sleep(10); // Will be benchmarked

    [Benchmark]
    [BenchmarkCategory("B", "2")]
    public void B2() => Thread.Sleep(10); // Why? Because it's not in the filter "1" OR "A"
}

/* Exmaple of a benchmark class with a global setup method
[MemoryDiagnoser]
//[SimpleJob(launchCount: 1, warmupCount: 3)]
[SimpleJob(BenchmarkDotNet.Engines.RunStrategy.ColdStart, launchCount:3)]
public class MyBenchmarkDemo2
{
    [GlobalSetup]
    public void GlobalSetup()
    {
        //Write your initialization code here
    }

    [Benchmark]
    public void MyFirstBenchmarkMethod()
    {
        //Write your code here   
    }
    [Benchmark]
    public void MySecondBenchmarkMethod()
    {
        //Write your code here
    }
}
*/