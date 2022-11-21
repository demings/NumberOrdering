using System;
using NumberOrdering.Abstractions;

namespace NumberOrdering.Services
{
    public class SystemSortService : ISortService
    {
        public List<int> SortNumbers(List<int> numbers)
        {
            numbers.Sort();
            return numbers;
        }
    }
}
