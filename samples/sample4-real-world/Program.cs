using BenchmarkDotNet.Running;

if (args.Length == 0)
    args = ["--filter", "*", "--launchCount", "1", "--warmupCount", "3", "--iterationCount", "5"];

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
