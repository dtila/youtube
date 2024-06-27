# ValueObject performance comparison

Benchmark with 2 different implementations of the ValueObject pattern from DDD:
1. ValueObject base class
2. Use *record* keyword from C# 9

I see 5 reasons why you should not use the ValueObject base class and I explain in this video:
[![View on YouTube](https://img.youtube.com/vi/xXpGJHCfY6o/0.jpg)](https://youtu.be/xXpGJHCfY6o)


In the benchmark there are 3 scenarios:
1. The record class			
2. The *ValueObject* instance with all the properties reference types
3. The *ValueObject* instance with some properties value types (to ilustrate boxing)

## Results

```
BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3737/23H2/2023Update/SunValley3)
13th Gen Intel Core i7-13700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.300
  [Host]     : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2


| Method                            | Categories  | Mean       | Error     | StdDev     | Median     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------------- |------------ |-----------:|----------:|-----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| Record_Equals                     | Equals      |   2.592 ns | 0.0722 ns |  0.0675 ns |   2.598 ns |  1.00 |    0.00 |      - |         - |          NA |
| ValueObject_Equals                | Equals      |  80.179 ns | 1.0937 ns |  1.0230 ns |  80.374 ns | 30.95 |    0.77 | 0.0063 |      80 B |          NA |
| ValueObjectWithStruct_Equals      | Equals      | 181.632 ns | 1.1271 ns |  1.0543 ns | 181.974 ns | 70.13 |    2.03 | 0.0215 |     272 B |          NA |
|                                   |             |            |           |            |            |       |         |        |           |             |
| Record_GetHashCode                | GetHashCode |  39.245 ns | 0.6341 ns |  0.5931 ns |  39.301 ns |  1.00 |    0.00 |      - |         - |          NA |
| ValueObject_GetHashCode           | GetHashCode | 102.876 ns | 1.3440 ns |  1.2572 ns | 102.620 ns |  2.62 |    0.05 | 0.0063 |      80 B |          NA |
| ValueObjectWithStruct_GetHashCode | GetHashCode | 217.895 ns | 4.3581 ns | 11.2496 ns | 214.026 ns |  5.76 |    0.29 | 0.0215 |     272 B |          NA |

```


# Conclusion

Using *ValueObject* base class is alocating more memory and it's actually slower between 2x - 70x than using the record keyword. The record keyword is the best option for ValueObject pattern in C#.
