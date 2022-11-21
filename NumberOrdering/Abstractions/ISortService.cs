using System;

namespace NumberOrdering.Abstractions
{
    public interface ISortService
    {
        List<int> SortNumbers(List<int> numbers);
    }
}
