using BenchmarkDotNet.Running;

//Console.WriteLine("Hello, World!");
//BenchmarkRunner.Run<MyBenchmarkDemo6>();
class Program
{
    static void Main(string[] args)
        => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
}