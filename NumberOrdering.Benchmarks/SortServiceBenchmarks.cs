using NumberOrdering.Services;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;

namespace NumberOrdering.Benchmarks;

public class SortServiceBenchmarks
{
    private readonly BubbleSortService _bubbleSortService;
    private readonly SystemSortService _systemSortService;
    private readonly List<int> _randomNumbers;

    const int NUMBER_COUNT = 10000;

    public SortServiceBenchmarks()
    {
        _bubbleSortService = new BubbleSortService();
        _systemSortService = new SystemSortService();
        _randomNumbers = Enumerable
            .Range(0, NUMBER_COUNT)
            .Select(i => new Tuple<int, int>(new Random().Next(NUMBER_COUNT), i))
            .OrderBy(i => i.Item1)
            .Select(i => i.Item2)
            .ToList();
    }

    [Benchmark]
    public void BubbleSortServiceBenchmark()
    {
        _bubbleSortService.SortNumbers(_randomNumbers);
    }

    [Benchmark]
    public void SystemSortServiceBenchmark()
    {
        _systemSortService.SortNumbers(_randomNumbers);
    }
}
