using BenchmarkDotNet.Attributes;
public class MyBenchmarkDemo4
{
    [Params(100, 200)]
    public int A { get; set; }

    [Params(10, 20)]
    public int B { get; set; }

    [Benchmark]
    public void Benchmark() => Thread.Sleep(A + B + 5);
}

public class MyBenchmarkDemo5
{
    [Params(100)]
    public int A { get; set; }

    [Params(10, Priority = -100)]
    public int B { get; set; }

    [Benchmark]
    public void Benchmark() => Thread.Sleep(A + B + 5);
}

public class MyBenchmarkDemo6
{
    [Params(true, false)] // Arguments can be combined with Params
    public bool AddExtra5Milliseconds;

    [Benchmark]
    [Arguments(100, 10)]
    [Arguments(100, 20)]
    [Arguments(200, 10)]
    [Arguments(200, 20)]
    public void Benchmark(int a, int b)
    {
        if (AddExtra5Milliseconds)
            Thread.Sleep(a + b + 5);
        else
            Thread.Sleep(a + b);
    }
}


public class MyBenchmarkDemo7
{
    [Params(100, Priority = 0)] // Argument priority can be combined with Params priority
    public int A { get; set; }

    [Arguments(5, Priority = -10)] // Define priority just once for multiple argument attributes
    [Arguments(10)]
    [Arguments(20)]
    [Benchmark]
    public void Benchmark(int b) => Thread.Sleep(A + b);

    [Benchmark]
    [ArgumentsSource(nameof(Numbers), Priority = 10)]
    public void ManyArguments(int c, int d) => Thread.Sleep(A + c + d);

    public IEnumerable<object[]> Numbers()
    {
        yield return new object[] { 1, 2 };
    }
}