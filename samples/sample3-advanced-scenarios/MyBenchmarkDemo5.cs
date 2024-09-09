using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Mathematics;
using BenchmarkDotNet.Order;
[ShortRunJob]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn(NumeralSystem.Arabic)]
[RankColumn(NumeralSystem.Roman)]
[RankColumn(NumeralSystem.Stars)]
public class MyBenchmarkDemo5
{
    [Params(1, 2)]
    public int Factor;

    [Benchmark]
    public void Foo() => Thread.Sleep(Factor * 100);

    [Benchmark]
    public void Bar() => Thread.Sleep(Factor * 200);
}