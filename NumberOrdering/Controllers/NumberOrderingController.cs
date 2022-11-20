using Microsoft.AspNetCore.Mvc;
using NumberOrdering.Abstractions;

namespace NumberOrdering.Controllers;

[ApiController]
[Route("[controller]")]
public class NumberOrderingController : ControllerBase
{
    private readonly ISortService _sortService;
    private readonly IFileService _fileService;

    public NumberOrderingController(ISortService sortService, IFileService fileService)
    {
        _sortService = sortService;
        _fileService = fileService;
    }

    [HttpPost]
    public async Task<string> PostANumberLineToBeOrderedAsync([FromBody] string numberLine)
    {
        var numbers = numberLine.Split(" ").Select(Int32.Parse);
        var sortedNumbers = _sortService.SortNumbers(numbers);
        var output = string.Join(" ", sortedNumbers) ?? "Error occured numbering lines.";

        await _fileService.WriteOutputToFile(output);
        return output;
    }

    [HttpGet]
    public Task<string> GetLatestContent() => _fileService.GetLatestFileOutput();
}
