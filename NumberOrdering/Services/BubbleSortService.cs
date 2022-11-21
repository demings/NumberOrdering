using System;
using NumberOrdering.Abstractions;

namespace NumberOrdering.Services
{
    public class BubbleSortService : ISortService
    {
        public List<int> SortNumbers(List<int> numbers)
        {
            for (int j = 0; j <= numbers.Count - 2; j++)
            {
                for (int i = 0; i <= numbers.Count - 2; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        var temp = numbers[i + 1];
                        numbers[i + 1] = numbers[i];
                        numbers[i] = temp;
                    }
                }
            }

            return numbers;
        }
    }
}
