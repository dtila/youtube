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
    public void Record_Equals()
    {
        var x = valueRecord1.Equals(valueRecord2);
    }

    [BenchmarkCategory("Equals"), Benchmark]
    [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    public void ValueObject_Equals()
    {
        var x = valueObject1.Equals(valueObject2);
    }

    [BenchmarkCategory("Equals"), Benchmark]
    [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    public void ValueObjectWithStruct_Equals()
    {
        var x = gpsValueObject1.Equals(gpsValueObject2);
    }



    [BenchmarkCategory("GetHashCode"), Benchmark(Baseline = true)]
    [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    public void Record_GetHashCode()
    {
        valueRecord1.GetHashCode();
        valueRecord2.GetHashCode();
    }

    [BenchmarkCategory("GetHashCode"), Benchmark]
    [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    public void ValueObject_GetHashCode()
    {
        valueObject1.GetHashCode();
        valueObject2.GetHashCode();
    }

    [BenchmarkCategory("GetHashCode"), Benchmark]
    [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
    public void ValueObjectWithStruct_GetHashCode()
    {
        gpsValueObject1.GetHashCode();
        gpsValueObject2.GetHashCode();
    }
}
