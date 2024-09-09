# BenchmarkDotNet Resources

### Overview
- GitHub Repo: [dotnet/BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet)
- nuget Home: [nuget BenchmarkDotNet](https://www.nuget.org/packages/BenchmarkDotNet)
- License: MIT

- Sub packages:
   - BenchmarkDotNet | [nuget](https://www.nuget.org/packages/BenchmarkDotNet)
   - BenchmarkDotNet.Annotations | [nuget](https://www.nuget.org/packages/BenchmarkDotNet.Annotations)
   - BenchmarkDotNet.Diagnostics.Windows | [nuget](https://www.nuget.org/packages/BenchmarkDotNet.Diagnostics.Windows)
   - BenchmarkDotNet.Diagnostics.dotTrace | [nuget](https://www.nuget.org/packages/BenchmarkDotNet.Diagnostics.dotTrace)
   - BenchmarkDotNet.Templates | [nuget](https://www.nuget.org/packages/BenchmarkDotNet.Templates)
   - BenchmarkDotNet.TestAdapter | [nuget](https://www.nuget.org/packages/BenchmarkDotNet.TestAdapter)
   - BenchmarkDotNet.Diagnostics.dotMemory | [nuget](https://www.nuget.org/packages/BenchmarkDotNet.Diagnostics.dotMemory)
   - BenchmarkDotNet.Exporters.Plotting | [nuget](https://www.nuget.org/packages/BenchmarkDotNet.Exporters.Plotting)
---
- ### Side projects:
   - [BenchmarkDotNet.Analyser](https://github.com/NewDayTechnology/benchmarkdotnet.analyser) | [nuget BDNA](https://www.nuget.org/packages/bdna)
   ```
   A .NET CLI tool for analysing BenchmarkDotNet results.
   BDNA aggregates and analyses BenchmarkDotNet results for performance degredations.
   If you want to ensure your critical code has acceptable performance in your CI pipelines BDNA may help you.
   ```
   - [BenchmarkDotNetVisualizer](https://github.com/mjebrahimi/BenchmarkDotNetVisualizer) | [nuget](https://www.nuget.org/packages/BenchmarkDotNetVisualizer)
   ```
   Visualizes your BenchmarkDotNet benchmarks to Colorful images and Feature-rich HTML (and maybe powerful charts in the future!)
   ```
   - [ChartsForBenchmarkDotNet](https://github.com/yv989c/ChartsForBenchmarkDotNet)
   ```
   This web app (https://chartbenchmark.net/) allows you to create a visual representation of your BenchmarkDotNet console results. You can conveniently copy the generated chart to your clipboard, save it as a PNG image, or share it through a URL.
   
   It currently understands standard results like the one shown below. Any columns between Method/Runtime and Mean are considered categories in the chart across the x-axis. These columns are typically created via properties decorated with the Params attribute in your benchmark.
   ```
   - [benchly](https://github.com/bitfaster/benchly)
   ```
   Use Benchly to automatically export graphical BenchmarkDotNet results without installing additional tools such as R. Benchly runs seamlessly as part of benchmark execution and is compatible with GitHub actions. Benchly produces high quality charts using Plotly.NET.
   ```
   - [ProtoBenchmarkHelpers](https://github.com/timcassell/ProtoBenchmarkHelpers)
   ```
   Useful for benchmarking actions ran on multiple threads concurrently more accurately than other solutions.
   
   It can be the same action ran multiple times in parallel, like incrementing a counter. Or it can be different actions ran at the same time in parallel, like reading from and writing to a concurrent collection.
   ```
   - [Microsoft VisualStudio DiagnosticsHub BenchmarkDotNetDiagnosers](https://learn.microsoft.com/en-us/visualstudio/profiling/?view=vs-2022) | [nuget](https://www.nuget.org/packages/Microsoft.VisualStudio.DiagnosticsHub.BenchmarkDotNetDiagnosers)
   ```
   This package provides Diagnosers for BenchmarkDotNet that allow you to profile your benchmark runs using the performance profiling tools in Visual Studio.
   ```
   - [BenchmarkCmp](https://github.com/yakivyusin/BenchmarkCmp) | [nuget](https://www.nuget.org/packages/BenchmarkCmp)
   ```
   Inspired by go-benchcmp, dotnet-benchmarkcmp displays performance changes between benchmarks.
   benchmarkcmp parses the output of two BenchmarkDotNet benchmark runs, correlates the results per benchmark (based on name), and displays the deltas.
   ```
   - [jswerdfeger.BenchmarkDotNet.Assert](https://github.com/jswerdfeger/jswerdfeger.BenchmarkDotNet.Assert) | [nuget](https://www.nuget.org/packages/jswerdfeger.BenchmarkDotNet.Assert)
   ```
    For use with BenchmarkDotNet, this library adds the capability to assert that your benchmarks are operating correctly, as you intend. Nothing is worse than writing a bunch of benchmarks, running them, coming to a conclusion, then finding out later that your benchmarking code wasn't even working correctly! 
   ```
   - [Elastic.CommonSchema.BenchmarkDotNetExporter ](https://github.com/elastic/ecs-dotnet) | [nuget](https://www.nuget.org/packages/Elastic.CommonSchema.BenchmarkDotNetExporter)
   ```
   An exporter for BenchmarkDotnet that can index benchmarking result output directly into Elasticsearch.
   ```
   - [Mawosoft.Extensions.BenchmarkDotNet](https://github.com/mawosoft/Mawosoft.Extensions.BenchmarkDotNet) | [nuget](https://www.nuget.org/packages/Mawosoft.Extensions.BenchmarkDotNet)
   ```
   An extensions library for BenchmarkDotNet
   ```
---
- ### Useful Repos:   
   - [BeyondSimpleBenchmarks](https://github.com/danielmarbach/BeyondSimpleBenchmarks)
   ```
   A practical guide to optimizing code with BenchmarkDotNet
   ```
   - [Doug-Murphy/Benchmarks](https://github.com/Doug-Murphy/Benchmarks)
   ```
   A repository of various BenchmarkDotNet tests.
   ```
   - [Practical.BenchmarkDotNet](https://github.com/phongnguyend/Practical.BenchmarkDotNet)
   ```
   Benchmarks for some Performance Best Practices
   ```
   - [Insight.Database.Benchmark](https://github.com/Jaxelr/Insight.Database.Benchmark)
   ```
   Benchmarks for the Micro-ORM Insight.Database using BenchmarkDotNet
   ```
   - [DotNet7-BenchmarkDotNet-Tests-InputData-SqlServer-Dapper-EFCore](https://github.com/renatogroffe/DotNet7-BenchmarkDotNet-Tests-InputData-SqlServer-Dapper-EFCore)
   ```
   Example of an implementation in .NET 7 (Console App) for benchmarking with tests comparing the performance of Dapper and Entity Framework Core in data insertions into SQL Server, involving a one-to-many relationship (Company and Contacts). The comparisons were generated using the BenchmarkDotNet package.
   ```
   - [PerfBenchmarks](https://github.com/NickCraver/PerfBenchmarks)
   ```
   Benchmarks for various things using BenchmarkDotNet
   ```
   - [DotNetTips Spargine Benchmarking](https://www.nuget.org/packages/DotNetTips.Spargine.8.Benchmarking)
   ```
   Abstract base class featuring common benchmarking methods, supplemented with default attributes.
   ```