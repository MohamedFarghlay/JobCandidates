using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;

namespace UnitTests;

public class CandidatesControllerTests
{

    private readonly Mock<IMediator> _mockMediator;
    private readonly JobCandidatesController _controller;
    public CandidatesControllerTests()
    {
        _mockMediator = new Mock<IMediator>();
        _controller = new JobCandidatesController(_mockMediator.Object);

    }
    [Fact]
    public async Task AddOrUpdateCandidate_ReturnsOkResult()
    {
        // Arrange
        var candidateDTO = new JobCandidateDto
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            Comment = "Sample comment"
        };

        // Act
        var result = await _controller.AddOrUpdateCandidate(candidateDTO);
        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task AddOrUpdateCandidate_ReturnsBadRequest_WhenModelStateIsInvalid()
    {
        // Arrange
        var candidateDTO = new JobCandidateDto
        {
            FirstName = "",
            LastName = "",
            Email = "",
            Comment = ""
        };
        _controller.ModelState.AddModelError("FirstName", "Required");
        _controller.ModelState.AddModelError("LastName", "Required");
        _controller.ModelState.AddModelError("Email", "Required");
        _controller.ModelState.AddModelError("Comment", "Required");

        // Act
        var result = await _controller.AddOrUpdateCandidate(candidateDTO);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        var errors = Assert.IsType<SerializableError>(badRequestResult.Value);
        Assert.Equal(4, errors.Count);
    }
}