using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using System.Security.Cryptography;
public class Algo_Md5VsSha256
{
    private const int N = 10000;
    private readonly byte[] data;

    private readonly MD5 md5 = MD5.Create();
    private readonly SHA256 sha256 = SHA256.Create();

    public Algo_Md5VsSha256()
    {
        data = new byte[N];
        new Random(42).NextBytes(data);
    }

    [Benchmark(Baseline = true)]
    public byte[] Md5() => md5.ComputeHash(data);

    [Benchmark]
    public byte[] Sha256() => sha256.ComputeHash(data);
}

public class IntroFluentConfigBuilder
{
    public static void Run()
    {
        // NOTE: ClrRuntime.Net48 requires .NET Framework 4.8 on Windows — omitted for cross-platform compatibility.
        BenchmarkRunner
            .Run<Algo_Md5VsSha256>(
                DefaultConfig.Instance
                    .AddJob(Job.Default.WithRuntime(CoreRuntime.CreateForNewVersion("10.0", ".NET 10.0")))
                    .AddValidator(ExecutionValidator.FailOnError));
    }
}