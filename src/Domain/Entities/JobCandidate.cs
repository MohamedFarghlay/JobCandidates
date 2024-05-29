using Domain.ValueObjects;

namespace Domain.Entities;
public record JobCandidate
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public required string Email { get; set; }
    public TimeInterval? CallTimeInterval { get; set; }
    public string? LinkedInProfile { get; set; }
    public string? GitHubProfile { get; set; }
    public required string Comment { get; set; }
}
