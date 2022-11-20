using NumberOrdering.Controllers;
using NumberOrdering.Services;
using Shouldly;

namespace NumberOrdering.Tests;

public class NumberOrderingControllerTests
{
    private readonly NumberOrderingController _controller;
    private readonly FileService _fileService;

    public NumberOrderingControllerTests()
    {
        _fileService = new FileService();
        _controller = new NumberOrderingController(new BubbleSortService(), _fileService);
    }

    [Fact]
    public async Task PostANumberLineToBeOrdered_ShouldCreateAFileWithOrderedNumbers()
    {
        // Act
        await _controller.PostANumberLineToBeOrderedAsync("5 2 8 10 1");

        // Assert
        (await _fileService.GetLatestFileOutput()).ShouldBe("1 2 5 8 10");
    }

    [Fact]
    public async Task GetLatestContent_ShouldReturnLatestFileContent()
    {
        // Arrange
        await _controller.PostANumberLineToBeOrderedAsync("5 2 8 10 1");
        await _controller.PostANumberLineToBeOrderedAsync("5 2 8 10 2");

        // Act
        var output = await _controller.GetLatestContent();

        // Assert
        output.ShouldBe("2 2 5 8 10");
    }
}
