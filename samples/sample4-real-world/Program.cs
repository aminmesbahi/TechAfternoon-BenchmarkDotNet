using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;


var config = DefaultConfig.Instance
            .AddJob(Job.Dry.WithRuntime(CoreRuntime.Core80).WithId(".NET 8").WithIterationCount(2))
            .AddJob(Job.Dry.WithRuntime(CoreRuntime.Core90).WithId(".NET 9").WithIterationCount(2));

//BenchmarkRunner.Run<SQLiteBenchmark>(config);
BenchmarkRunner.Run<CollectionBenchmark>(config);
