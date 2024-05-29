using Application.Mappings;
using Domain.Interfaces;
using MediatR;

namespace Application.JobCandidate.Commands;
public sealed class AddOrUpdateJobCandidateHandler(IJobCandidateRepository _repository) : IRequestHandler<AddOrUpdateJobCandidateCommand, Unit>
{
    public async Task<Unit> Handle(AddOrUpdateJobCandidateCommand request, CancellationToken cancellationToken)
    {
        var candidateDTO = request.CandidateDTO;

        var candidate = await _repository.GetByEmailAsync(candidateDTO.Email, cancellationToken);

        if (candidate == null)
        {
            candidate = JobCandidateMapper.MapToEntity(candidateDTO);
            await _repository.AddAsync(candidate, cancellationToken);
        }
        else
        {
            JobCandidateMapper.MapToEntity(candidateDTO, candidate);
            await _repository.UpdateAsync(candidate, cancellationToken);
        }
        return Unit.Value;
    }
}

