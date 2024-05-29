using System.ComponentModel.DataAnnotations;

namespace Application.Dtos;
public record TimeIntervalDto : IValidatableObject
{
    [DataType(DataType.DateTime)]
    public DateTime? From { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime? To { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (From.HasValue && To.HasValue && From.Value > To.Value)
        {
            yield return new ValidationResult("The 'To' date must be greater than the 'From' date.", [nameof(To)]);
        }
    }
}
