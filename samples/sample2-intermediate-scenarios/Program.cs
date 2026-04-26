using BenchmarkDotNet.Running;

Console.WriteLine("Welcome to Intermediate Level Scenarios!");

if (args.Length == 0)
    args = ["--filter", "*", "--job", "dry", "--launchCount", "1"];

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
