# Sample 2, Intermediate Scenarios

1. `dotnet add package BenchmarkDotNet`
2. `dotnet run -c Release`


## MyBenchmarkDemo1
- Get to know Monitoring strategy
- SimpleJob: Is a job that runs the benchmark with the specified run strategy and iteration count.
- BenchmarkDotNet.Engines.RunStrategy.Monitoring: Monitoring means that the benchmark is run in a warm environment, which is useful for testing the performance of a method after it has been run multiple times.
- iterationCount: Is the number of times the benchmark is run.
- id: Is the identifier of the job appearing in the benchmark results.

## MyBenchmarkDemo2
- Get to know the benchmark output summary
- [ShortRunJob]: A quick benchmark job with fewer iterations, optimized for speed over accuracy.
- [MediumRunJob]: A balanced benchmark job with a moderate number of iterations, providing a trade-off between accuracy and runtime.
- [KeepBenchmarkFiles]: Keeps the benchmark files after the benchmark run.
- [AsciiDocExporter]: Exports the benchmark results in AsciiDoc format.
- [CsvExporter]: Exports the benchmark results in CSV format.
	- [CsvMeasurementsExporter]: Exports the benchmark results in CSV format with measurements.
- [HtmlExporter]: Exports the benchmark results in HTML format.
- [PlainExporter]: Exports the benchmark results in plain text format.
- [RPlotExporter]: Exports the benchmark results in RPlot format. RPlot is a file format used by the R programming language.
- [JsonExporterAttribute.Brief]: Exports the benchmark results in JSON format with brief information.
- [JsonExporterAttribute.BriefCompressed]: Exports the benchmark results in JSON format with brief information and compression.
- [JsonExporterAttribute.Full]: Exports the benchmark results in JSON format with full information.
- [JsonExporterAttribute.FullCompressed]: Exports the benchmark results in JSON format with full information and compression.
- [MarkdownExporterAttribute.Default]: Exports the benchmark results in Markdown format with default settings.
- [MarkdownExporterAttribute.GitHub]: Exports the benchmark results in Markdown format with GitHub settings.
- [MarkdownExporterAttribute.StackOverflow]: Exports the benchmark results in Markdown format with Stack Overflow settings.
- [MarkdownExporterAttribute.Atlassian]: Exports the benchmark results in Markdown format with Atlassian settings.
- [XmlExporterAttribute.Brief]: Exports the benchmark results in XML format with brief information.
- [XmlExporterAttribute.BriefCompressed]: Exports the benchmark results in XML format with brief information and compression.
- [XmlExporterAttribute.Full]: Exports the benchmark results in XML format with full information.
- [XmlExporterAttribute.FullCompressed]: Exports the benchmark results in XML format with full information and compression.

## MyBenchmarkDemo3
- Get to know the benchmark configuration & Power Plans
- [Config(typeof(Config))]: Specifies the configuration class for the benchmark.
- WithPowerPlan: Specifies the power plan to use for the benchmark.

## MyBenchmarkDemo4-7
- Get to know the benchmark parameters and arguments
- [Params(100, 200)]: Specifies the parameters for the benchmark.
- [Params(10, Priority = -100)]: Priority means that the parameter is run first. lower values are run first.
- [Arguments(200, 20)]: Specifies the arguments for the benchmark.
- [Arguments(10, Priority = -100)]: Priority means that the argument is run first. lower values are run first.

## MyBenchmarkDemo8
- Get to know the benchmark parameters sources and arguments sources
- [ArgumentsSource(nameof(Numbers), Priority = 10)]: argument source is a method that returns an IEnumerable of arguments.
- [ParamsSource(nameof(Numbers), Priority = 10)]: parameter source is a method that returns an IEnumerable of parameters.
