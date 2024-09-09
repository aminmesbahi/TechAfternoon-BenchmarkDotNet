using BenchmarkDotNet.Attributes;

public class MyBenchmarkDemo8
{
    [Benchmark]
    [ArgumentsSource(nameof(Numbers))]
    public double ManyArguments(double x, double y) => Math.Pow(x, y);

    public IEnumerable<object[]> Numbers() // for multiple arguments it's an IEnumerable of array of objects (object[])
    {
        yield return new object[] { 1.0, 1.0 };
        yield return new object[] { 2.0, 2.0 };
        yield return new object[] { 4.0, 4.0 };
        yield return new object[] { 10.0, 10.0 };
    }

    [Benchmark]
    [ArgumentsSource(nameof(TimeSpans))] //specify the name of public method/property which is going to provide the values (something that implements IEnumerable)
    public void SingleArgument(TimeSpan time) => Thread.Sleep(time);

    public IEnumerable<object> TimeSpans() // for single argument it's an IEnumerable of objects (object)
    {
        yield return TimeSpan.FromMilliseconds(10);
        yield return TimeSpan.FromMilliseconds(100);
    }
}


public class MyBenchmarkDemo9
{
    // property with public setter
    [ParamsSource(nameof(ValuesForA))]
    public int A { get; set; }

    // public field
    [ParamsSource(nameof(ValuesForB))]
    public int B;

    // public property
    public IEnumerable<int> ValuesForA => new[] { 100, 200 };

    // public static method
    public static IEnumerable<int> ValuesForB() => new[] { 10, 20 };

    [Benchmark]
    public void Benchmark() => Thread.Sleep(A + B + 5);
}