// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

Console.WriteLine("Hello, World!");

BenchmarkRunner.Run<CountVsAny>();


[MemoryDiagnoser]
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
    public bool IsItem100ExistsCount()
	{
        return items.Count(x => x == 100) != 0;
    }

    [Benchmark]
	public bool IsItem100ExistsAny()
	{
        return items.Any(x => x == 100);
    }
}