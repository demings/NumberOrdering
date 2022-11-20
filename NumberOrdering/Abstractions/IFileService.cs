using System;

namespace NumberOrdering.Abstractions
{
    public interface IFileService
    {
        Task WriteOutputToFile(string output);
        Task<string> GetLatestFileOutput();
    }
}
