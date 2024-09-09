using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using System.Runtime.CompilerServices; //Provides advanced attributes such as [MethodImpl] used to control how methods are handled by the runtime (e.g., preventing inlining).

/*
Native memory refers to memory that is allocated outside of the .NET managed environment
Unlike managed memory, native memory is not controlled by the .NET runtime's garbage collector (GC) and requires explicit management, usually with malloc and free in C/C++ or Marshal.AllocHGlobal in C#
--
Event Tracing for Windows (ETW) is a high-performance tracing facility provided by the Windows operating system.
--
A memory leak occurs when a program allocates memory but fails to release it back to the operating system or runtime environment when it is no longer needed.
*/
[Config(typeof(Config))]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser]
public class MyBenchmarkDemo1
{
    private class Config : ManualConfig
    {
        public Config()
        {
            AddJob(Job.MediumRun.WithGcServer(true).WithGcForce(true).WithId("ServerForce"));
            AddJob(Job.MediumRun.WithGcServer(true).WithGcForce(false).WithId("Server"));
            AddJob(Job.MediumRun.WithGcServer(false).WithGcForce(true).WithId("Workstation"));
            AddJob(Job.MediumRun.WithGcServer(false).WithGcForce(false).WithId("WorkstationForce"));
        }
    }

    [Benchmark(Description = "new byte[10kB]")]
    public byte[] Allocate()
    {
        // new for heap allocation
        return new byte[10000];
    }

    [Benchmark(Description = "stackalloc byte[10kB]")]
    public unsafe void AllocateWithStackalloc()
    {
        // stackalloc for stack allocation
        var array = stackalloc byte[10000];
        Consume(array);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static unsafe void Consume(byte* input)
    {
    }
}