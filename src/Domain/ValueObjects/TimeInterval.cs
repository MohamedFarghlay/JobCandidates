namespace Domain.ValueObjects;
public record TimeInterval
{
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
}