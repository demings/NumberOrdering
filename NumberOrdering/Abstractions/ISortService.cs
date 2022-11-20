using System;

namespace NumberOrdering.Abstractions
{
    public interface ISortService
    {
        IEnumerable<int> SortNumbers(IEnumerable<int> numbers);
    }
}
