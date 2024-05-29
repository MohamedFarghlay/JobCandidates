using Application.Dtos;

namespace Application.Mappings;
public static class JobCandidateMapper
{
    public static Domain.Entities.JobCandidate MapToEntity(JobCandidateDto dto)
    {
        return new Domain.Entities.JobCandidate
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            CallTimeInterval = new Domain.ValueObjects.TimeInterval()
            {
                From = dto.CallTimeInterval?.From,
                To = dto.CallTimeInterval?.To,
            },
            LinkedInProfile = dto.LinkedInProfile,
            GitHubProfile = dto.GitHubProfile,
            Comment = dto.Comment
        };
    }

    public static void MapToEntity(JobCandidateDto dto, Domain.Entities.JobCandidate candidate)
    {
        candidate.FirstName = dto.FirstName;
        candidate.LastName = dto.LastName;
        candidate.PhoneNumber = dto.PhoneNumber;
        candidate.Email = dto.Email;
        candidate.CallTimeInterval = new Domain.ValueObjects.TimeInterval()
        {
            From = dto.CallTimeInterval?.From,
            To = dto.CallTimeInterval?.To,
        };
        candidate.LinkedInProfile = dto.LinkedInProfile;
        candidate.GitHubProfile = dto.GitHubProfile;
        candidate.Comment = dto.Comment;
    }
}
