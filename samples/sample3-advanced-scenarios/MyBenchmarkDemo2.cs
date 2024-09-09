using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Order;


/*
The EventPipeProfiler attribute takes the following profiles:

    - CpuSampling - Useful for tracking CPU usage and general .NET runtime information. This is the default option.
    - GcVerbose - Tracks GC collections and samples object allocations.
    - GcCollect - Tracks GC collections only at very low overhead.
    - Jit - Logging when Just in time (JIT) compilation occurs. Logging of the internal workings of the Just In Time compiler. This is fairly verbose. It details decisions about interesting optimization (like inlining and tail call)
 */
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