using BenchmarkDotNet.Attributes;

// [AnyCategoriesFilter] keeps only benchmarks that belong to at least one of the listed categories.
// B2 is excluded because it doesn't belong to "A" or "1" — even though it has a numeric category.
[DryJob]
[CategoriesColumn]
[BenchmarkCategory("Awesome")]
[AnyCategoriesFilter("A", "1")]
public class MyBenchmarkDemo2
{
    [Benchmark]
    [BenchmarkCategory("A", "1")]
    public void A1() => Thread.Sleep(10);

    [Benchmark]
    [BenchmarkCategory("A", "2")]
    public void A2() => Thread.Sleep(10);

    [Benchmark]
    [BenchmarkCategory("B", "1")]
    public void B1() => Thread.Sleep(10);

    [Benchmark]
    [BenchmarkCategory("B", "2")]
    public void B2() => Thread.Sleep(10); // skipped — matches neither "A" nor "1"
}