using BenchmarkDotNet.Attributes;

[DryJob]
[MemoryDiagnoser]
public class MyBenchmarkDemo10
{
    [Params(10, 100)]
    public int DelayMs { get; set; }

    [Benchmark(Baseline = true)]
    public async Task AsyncDelay() => await Task.Delay(DelayMs);

    [Benchmark]
    public async Task<int> AsyncComputation()
    {
        return await Task.Run(() =>
        {
            int sum = 0;
            for (int i = 0; i < DelayMs * 1000; i++) sum += i;
            return sum;
        });
    }

    [Benchmark]
    public async ValueTask<string> ValueTaskResult()
    {
        await Task.Yield(); // force at least one async continuation
        return string.Concat(Enumerable.Range(1, DelayMs).Select(i => i.ToString()));
    }

    [Benchmark]
    public async Task WhenAllDelays()
    {
        await Task.WhenAll(
            Task.Delay(DelayMs / 2),
            Task.Delay(DelayMs / 2));
    }
}
