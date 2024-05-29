using System.ComponentModel.DataAnnotations;

namespace Application.Dtos;
public record JobCandidateDto
{
    [Required]
    public required string FirstName { get; set; }
    [Required]
    public required string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    public TimeIntervalDto? CallTimeInterval { get; set; }
    public string? LinkedInProfile { get; set; }
    public string? GitHubProfile { get; set; }
    [Required]
    public required string Comment { get; set; }
}
