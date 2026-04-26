using BenchmarkDotNet.Attributes;

[ShortRunJob]
[MemoryDiagnoser]
public class MyBenchmarkDemo6
{
    private byte[] _buffer = null!;

    // C# 14: 'field' keyword — semi-auto property with custom logic and no backing field declaration.
    private int IterationCount
    {
        get => field;
        set => field = value < int.MaxValue ? value : int.MaxValue;
    }

    [Params(1024, 8192)]
    public int BufferSize { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _buffer = new byte[BufferSize];
        Random.Shared.NextBytes(_buffer);
        IterationCount = 0;
        Console.WriteLine($"// [GlobalSetup] buffer allocated: {BufferSize} bytes");
    }

    [IterationSetup]
    public void IterationSetup()
    {
        IterationCount++;
        Console.WriteLine($"// [IterationSetup] iteration #{IterationCount}");
    }

    [IterationCleanup]
    public void IterationCleanup()
    {
        Console.WriteLine($"// [IterationCleanup] after iteration #{IterationCount}");
    }

    [GlobalCleanup]
    public void GlobalCleanup()
    {
        Console.WriteLine($"// [GlobalCleanup] total iterations: {IterationCount}");
        _buffer = null!;
    }

    [Benchmark(Baseline = true)]
    public int SumScalar()
    {
        int sum = 0;
        for (int i = 0; i < _buffer.Length; i++)
            sum += _buffer[i];
        return sum;
    }

    [Benchmark]
    public int SumSpan()
    {
        int sum = 0;
        foreach (byte b in _buffer.AsSpan())
            sum += b;
        return sum;
    }

    [Benchmark]
    public int SumLinq() => _buffer.Sum(b => (int)b);
}
