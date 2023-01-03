using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<EnumToStringVsNameOf>();

[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
public class EnumToStringVsNameOf
{
    public enum MyEnum
    {
        One,
        Two,
        Three
    }

    [Benchmark]
    public string EnumToString()
    {
        return MyEnum.One.ToString();
    }

    [Benchmark]
    public string NameOf()
    {
        return nameof(MyEnum.One);
    }
}