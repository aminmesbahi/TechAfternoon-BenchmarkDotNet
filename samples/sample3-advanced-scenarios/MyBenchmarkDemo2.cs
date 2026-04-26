using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Order;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser]
public class MyBenchmarkDemo2
{
    [ShortRunJob]
    [EventPipeProfiler(EventPipeProfile.CpuSampling)]
    public class IntroEventPipeProfiler
    {
        [Benchmark]
        public void Sleep() => Thread.Sleep(2000);
    }
}