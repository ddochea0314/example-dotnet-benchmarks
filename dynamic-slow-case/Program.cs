using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<DynamicSlowCase>();

[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
public class DynamicSlowCase
{
    public string ReturnStringValue() => "Hello World";
    public dynamic ReturnDynamicValue() => "Hello World";

    [Benchmark]
    public string ReturnStringValueCall()
    {
        return ReturnStringValue();
    }

    [Benchmark]
    public string ReturnDynamicValueCall()
    {
        return ReturnDynamicValue();
    }

    [Benchmark]
    public string ReturnDynamicValueCallWithCast()
    {
        return (string)ReturnDynamicValue();
    }

    [Benchmark]
    public string ReturnDynamicValueCallWithCastAndIs()
    {
        var value = ReturnDynamicValue();
        if (value is string str)
        {
            return str;
        }

        return null;
    }

    [Benchmark]
    public string ReturnDynamicValueCallWithCastAndAs()
    {
        var value = ReturnDynamicValue();
        return value as string;
    }
}