using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System.Runtime.CompilerServices;

namespace ValueObjectImplementation;


[MemoryDiagnoser]
[MarkdownExporterAttribute.GitHub]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class ValueObjectsBenchmark
{
    private readonly AddressRecord valueRecord1 = new ("street", "city", "state", "country", "zipCode");
    private readonly AddressRecord valueRecord2 = new("street", "city", "state", "country", "zipCode");

    private readonly AddressValueObject valueObject1 = new ("street", "city", "state", "country", "zipCode");
    private readonly AddressValueObject valueObject2 = new("street", "city", "state", "country", "zipCode");
    
    private readonly GpsLocatedAddress gpsValueObject1 = new("street", "city", "state", "country", "zipCode", 45, 34);
    private readonly GpsLocatedAddress gpsValueObject2 = new("street", "city", "state", "country", "zipCode", 45, 34);


    [BenchmarkCategory("Equals"), Benchmark(Baseline = true)]
    [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    public void RecordClass_Equals()
    {
        var x = valueRecord1.Equals(valueRecord2);
    }

    [BenchmarkCategory("Equals"), Benchmark]
    [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    public void ValueObjectClass_Equals()
    {
        var x = valueObject1.Equals(valueObject2);
    }

    [BenchmarkCategory("Equals"), Benchmark]
    [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    public void ValueObjectClassWithBoxing_Equals()
    {
        var x = gpsValueObject1.Equals(gpsValueObject2);
    }



    [BenchmarkCategory("GetHashCode"), Benchmark(Baseline = true)]
    [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    public void RecordClass_GetHashCode()
    {
        var x = valueRecord1.GetHashCode();
        var y = valueRecord2.GetHashCode();
    }

    [BenchmarkCategory("GetHashCode"), Benchmark]
    [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    public void ValueObjectClass_GetHashCode()
    {
        var x = valueObject1.GetHashCode();
        var y = valueObject2.GetHashCode();
    }

    [BenchmarkCategory("GetHashCode"), Benchmark]
    [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    public void ValueObjectClassWithSBoxing_GetHashCode()
    {
        var x = gpsValueObject1.GetHashCode();
        var y = gpsValueObject2.GetHashCode();
    }
}
