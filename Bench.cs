using MemoryPack;
using Stride.Core;
using Stride.Core;
using Stride.Core.Annotations;
using Stride.Core.Reflection;
using Stride.Core.Serialization;
using Stride.Core.Serialization.Contents;
using Stride.Core.Serialization.Serializers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;

namespace Bench.Serialization;


[DataContract, ReferenceSerializer, DataSerializerGlobal(typeof(ReferenceSerializer<Person>), Profile = "Content")]
[MemoryPackable]
public partial class Person
{
    [MemoryPackInclude]
    public string FirstName { get; set; }
    [MemoryPackInclude]
    public string LastName { get; set; }
    [MemoryPackInclude]
    public int Age { get; set; }

    [MemoryPackConstructor]
    public Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
}


public class PersonSerializer : DataSerializer<Person>
{
    StringSerializer stringSer = new();
    Int32Serializer intSer = new();
    public override void Serialize(ref Person obj, ArchiveMode mode, [NotNull] SerializationStream stream)
    {
        if (mode == ArchiveMode.Serialize)
        {
            stringSer.Serialize(obj.FirstName, stream);
            stringSer.Serialize(obj.LastName, stream);
            intSer.Serialize(obj.Age, stream);
        }
        else
        {
            
        }
    }
}


public class AntiVirusFriendlyConfig : ManualConfig
{
    public AntiVirusFriendlyConfig()
    {
        AddJob(Job.MediumRun
            .WithToolchain(InProcessNoEmitToolchain.Instance));
    }
}

[MemoryDiagnoser]
// [Config(typeof(AntiVirusFriendlyConfig))]
public class SeriBench
{
    Person p = new Person("John", "Doe", 35);
    PersonSerializer ps = new();
    
    [Benchmark]
    public void SerializeStride(){
        BinarySerializationWriter stream = new(new MemoryStream());
        ps.Serialize(ref p,ArchiveMode.Serialize,stream);
    }
    [Benchmark]
    public void SerializeMemPack() => MemoryPackSerializer.Serialize(p);

}