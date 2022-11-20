using System;
using NumberOrdering.Abstractions;

namespace NumberOrdering.Services
{
    public class FileService : IFileService
    {
        public Task<string> GetLatestFileOutput() =>
            File.ReadAllTextAsync(
                new DirectoryInfo(".")
                    .GetFiles()
                    .OrderByDescending(f => f.LastWriteTime)
                    .First()
                    .FullName
            );

        public Task WriteOutputToFile(string output) =>
            File.WriteAllTextAsync(Guid.NewGuid().ToString() + ".txt", output);
    }
}
