﻿using System;
using System.Linq;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using Xunit;
using Xunit.Abstractions;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Characteristics;

namespace BenchmarkDotNet.IntegrationTests
{
    public class CustomEngineTests : BenchmarkTestExecutor
    {
        private const string SetupMessage = "// Setup got called";
        private const string EngineRunMessage = "// EngineRun got called";
        private const string CleanupMessage = "// Cleanup got called";

        public CustomEngineTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void CustomEnginesAreSupported()
        {
            var config = ManualConfig.CreateEmpty()
                .With(new Job(Job.Dry) { Infrastructure = { EngineFactory = new CustomFactory() } });

            var summary = CanExecute<SimpleBenchmark>(config, fullValidation: false);

            AssertMessageGotDisplayed(summary, SetupMessage);
            AssertMessageGotDisplayed(summary, EngineRunMessage);
            AssertMessageGotDisplayed(summary, CleanupMessage);
        }

        private static void AssertMessageGotDisplayed(Summary summary, string message)
        {
            Assert.True(summary.Reports.Any(report => report.ExecuteResults.Any(executeResult => executeResult.ExtraOutput.Any(line => line == message))), $"{message} should have been printed by custom Engine");
        }

        public class SimpleBenchmark
        {
            [Setup]
            public void Setup() => Console.WriteLine(SetupMessage);

            [Cleanup]
            public void Cleanup() => Console.WriteLine(CleanupMessage);

            [Benchmark]
            public void Empty() { }
        }

        public class CustomFactory : IEngineFactory
        {
            public IEngine Create(EngineParameters engineParameters) 
                => new CustomEngine
                {
                    CleanupAction = engineParameters.CleanupAction,
                    SetupAction = engineParameters.SetupAction
                };
        }

        public class CustomEngine : IEngine
        {
            public RunResults Run()
            {
                Console.WriteLine(EngineRunMessage);

                return new RunResults(
                    new List<Measurement>() { default(Measurement) }, 
                    new List<Measurement>() { default(Measurement) },
                    false,
                    default(GcStats));
            }

            public IHost Host { get; }
            public bool IsDiagnoserAttached { get; }
            public void WriteLine() { }
            public void WriteLine(string line) { }
            public Job TargetJob { get; }
            public long OperationsPerInvoke { get; }
            public Action SetupAction { get; set; }
            public Action CleanupAction { get; set; }
            public Action<long> MainAction { get; }
            public Action<long> IdleAction { get; }
            public IResolver Resolver { get; }

            public Measurement RunIteration(IterationData data) { throw new NotImplementedException(); }
            public void PreAllocate() { }
            public void Jitting() { }
        }
    }
}