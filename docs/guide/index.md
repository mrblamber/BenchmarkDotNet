#Welcome to the BenchmarkDotNet documentation

**BenchmarkDotNet** is a powerful .NET library for benchmarking. 

Source-code is available at: [@fa-github Github](https://github.com/PerfDotNet/BenchmarkDotNet)  
Pre-built packages are available at: [NuGet](https://www.nuget.org/packages/BenchmarkDotNet/)

[Breif Overview](Overview.htm)

[![NuGet](https://img.shields.io/nuget/v/BenchmarkDotNet.svg)](https://www.nuget.org/packages/BenchmarkDotNet/) [![Gitter](https://img.shields.io/gitter/room/PerfDotNet/BenchmarkDotNet.svg)](https://gitter.im/PerfDotNet/BenchmarkDotNet) [![Build status](https://img.shields.io/appveyor/ci/perfdotnet/benchmarkdotnet/master.svg?label=appveyor)](https://ci.appveyor.com/project/PerfDotNet/benchmarkdotnet/branch/master) [![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE.md) [![Documentation](https://img.shields.io/badge/docs-Documentation-green.svg?style=flat)](https://perfdotnet.github.io/BenchmarkDotNet/) [![ChangeLog](https://img.shields.io/badge/docs-ChangeLog-green.svg?style=flat)](https://github.com/PerfDotNet/BenchmarkDotNet/wiki/ChangeLog)

## Summary

* Standard benchmarking routine: generating an isolated project per each benchmark method; auto-selection of iteration amount; warmup; overhead evaluation; statistics calculation; and so on.
* Easy way to compare different environments (`x86` vs `x64`, `LegacyJit` vs `RyuJit`, and so on; see: [Jobs](Configuration/Jobs.htm))
* Reports: markdown (default, github, stackoverflow), csv, html, plain text; png plots.
* Advanced features: [Baseline](Advanced/baseline.htm), [Setup](Advanced/setup.htm), [Params](Advanced/params.htm), [Percentiles](Advanced/percentiles.htm)
* Powerful diagnostics based on ETW events (see [BenchmarkDotNet.Diagnostics.Windows](https://www.nuget.org/packages/BenchmarkDotNet.Diagnostics.Windows/))
* Supported runtimes: Full .NET Framework, .NET Core (RTM), Mono
* Supported languages: C#, F# (also on [.NET Core](https://github.com/PerfDotNet/BenchmarkDotNet/issues/135)) and Visual Basic