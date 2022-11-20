using System;
using NumberOrdering.Abstractions;

namespace NumberOrdering.Services
{
    public class BubbleSortService : ISortService
    {
        public IEnumerable<int> SortNumbers(IEnumerable<int> numbers)
        {
            var numbersList = numbers.ToList();

            // TODO: implement bubble sort
            numbersList.Sort();

            return numbersList;
        }
    }
}
