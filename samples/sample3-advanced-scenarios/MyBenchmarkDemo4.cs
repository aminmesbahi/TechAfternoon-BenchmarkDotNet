using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;

public class MyBenchmarkDemo4
{
    private class MyConfigSourceAttribute : Attribute, IConfigSource
    {
        public IConfig Config { get; }

        public MyConfigSourceAttribute(params Jit[] jits)
        {
            var jobs = jits
                .Select(jit => new Job(Job.Dry) { Environment = { Jit = jit, Platform = Platform.X64 } })
                .ToArray();
            Config = ManualConfig.CreateEmpty().AddJob(jobs);
        }
    }

    // NOTE: Jit.LegacyJit is only available on .NET Framework (Windows). On .NET Core/.NET 5+, RyuJIT is always used.
    [MyConfigSource(Jit.RyuJit)]
    [Benchmark]
    public void Foo()
    {
        Thread.Sleep(10);
    }
}