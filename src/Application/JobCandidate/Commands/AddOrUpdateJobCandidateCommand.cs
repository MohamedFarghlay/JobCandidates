using Application.Dtos;
using MediatR;

namespace Application.JobCandidate.Commands;
public sealed record AddOrUpdateJobCandidateCommand(JobCandidateDto CandidateDTO) : IRequest<Unit>;