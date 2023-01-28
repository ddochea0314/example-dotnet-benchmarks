// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using System.Diagnostics;

BenchmarkRunner.Run<BetterStopwatchCreate>();


[MemoryDiagnoser]
[SimpleJob(runtimeMoniker: RuntimeMoniker.Net60)]
[SimpleJob(runtimeMoniker: RuntimeMoniker.Net70)]
public class BetterStopwatchCreate
{
    public async ValueTask<long> CreateStopWatch_UsingNewKeywoard()
    {
        var watch = new Stopwatch();
        watch.Start();
        await Task.Delay(100);
        watch.Stop();
        return watch.ElapsedMilliseconds;
    }

    [Benchmark]
    public async Task Use_NewKeywoard()
    {
        foreach (var _ in Enumerable.Range(0, 10))
        {
            await CreateStopWatch_UsingNewKeywoard();
        }
    }
    
    public async ValueTask<long> CreateStopWatch_StartNew()
    {
        var watch = Stopwatch.StartNew();
        await Task.Delay(100);
        watch.Stop();
        return watch.ElapsedMilliseconds;
    }

    [Benchmark]
    public async Task Use_StartNew()
    {
        foreach (var _ in Enumerable.Range(0, 10))
        {
            await CreateStopWatch_StartNew();
        }
    }

}