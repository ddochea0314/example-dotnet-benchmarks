using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

BenchmarkRunner.Run<BetterDictionaryUpdate>();

[MemoryDiagnoser]
[SimpleJob(runtimeMoniker: RuntimeMoniker.Net60)]
[SimpleJob(runtimeMoniker: RuntimeMoniker.Net70)]
public class BetterDictionaryUpdate
{
    public readonly Guid _id;
    public readonly Dictionary<Guid, UserClass> _clsUser;
    public readonly Dictionary<Guid, UserStruct> _structUser;

    public BetterDictionaryUpdate()
    {
        _id = Guid.NewGuid();
        _clsUser = new()
        {
            { _id, new UserClass() { ID = _id, Age = 10, Name = "John" } }
        };
        _structUser = new()
        {
            { _id, new UserStruct() { ID = _id, Age = 10, Name = "John" } }
        };
    }

    [Benchmark]
    public UserClass UpdateUserClass()
    {
        if(_clsUser.TryGetValue(_id, out var user))
        {
            user.Name = "Tom";
            return user;
        }
        return default!;
    }

    [Benchmark]
    public UserClass UpdateUserClass_Unsafe()
    {
        ref var user = ref CollectionsMarshal.GetValueRefOrNullRef(_clsUser, _id);

        if(!Unsafe.IsNullRef(ref user))
        {
            user.Name = "Tom";
            return user;
        }
        return default!;
    }

    [Benchmark]
    public UserStruct UpdateUserStruct()
    {
        if (_structUser.TryGetValue(_id, out var user))
        {
            user.Name = "Tom";
            _structUser[_id] = user; // struct는 값 형식이므로 재 대입해야 한다.
            return user;
        }
        return default;
    }

    [Benchmark]
    public UserStruct UpdateUserStruct_Unsafe()
    {
        ref var user = ref CollectionsMarshal.GetValueRefOrNullRef(_structUser, _id);
        if(!Unsafe.IsNullRef(ref user))
        {
            user.Name = "Tom";
            return user;
        }
        return default;
    }
}
public class UserClass
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}


public struct UserStruct
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}