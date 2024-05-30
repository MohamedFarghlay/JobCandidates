using Application.Dtos;
using Application.JobCandidate.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class JobCandidatesController(IMediator _mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddOrUpdateCandidate([FromBody] JobCandidateDto candidateDTO, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new AddOrUpdateJobCandidateCommand(candidateDTO);

        return Ok(await _mediator.Send(command, cancellationToken));
    }
}
