using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<CountVsAny>();

[MemoryDiagnoser]
[SimpleJob(runtimeMoniker: RuntimeMoniker.Net60)]
[SimpleJob(runtimeMoniker: RuntimeMoniker.Net70)]
public class CountVsAny
{
	public int[] items;
	public CountVsAny()
	{
        items = Enumerable.Range(0, 1000).ToArray();
    }

    [Benchmark]
    public bool IsExistsUseCount()
	{
		return items.Count() != 0;
    }

    [Benchmark]
    public bool IsExistsUseAny()
	{
        return items.Any();
    }

    [Benchmark]
    public bool IsItem100ExistsCount1()
	{
        return items.Count(x => x == 100) != 0;
    }

    [Benchmark]
    public bool IsItem100ExistsCount2()
    {
        return items.Where(x => x == 100).Count() != 0;
    }

    [Benchmark]
	public bool IsItem100ExistsAny1()
	{
        return items.Any(x => x == 100);
    }

    [Benchmark]
    public bool IsItem100ExistsAny2()
    {
        return items.Where(x => x == 100).Any();
    }
}