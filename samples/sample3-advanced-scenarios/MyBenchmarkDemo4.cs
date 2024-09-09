using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;

public class MyBenchmarkDemo4
{
    /// <summary>
    /// Dry-x64 jobs for specific jits
    /// </summary>
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

    [MyConfigSource(Jit.RyuJit, Jit.LegacyJit)]
    [Benchmark]
    public void Foo()
    {
        Thread.Sleep(10);
    }
}