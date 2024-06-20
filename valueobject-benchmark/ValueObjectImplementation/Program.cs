using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using ValueObjectImplementation;

var config = new ManualConfig();
config.AddColumnProvider(DefaultConfig.Instance.GetColumnProviders().ToArray());
config.UnionRule = ConfigUnionRule.AlwaysUseGlobal;

var summary = BenchmarkRunner.Run<ValueObjectsBenchmark>();

var logger = ConsoleLogger.Default;
MarkdownExporter.Console.ExportToLog(summary, logger);




