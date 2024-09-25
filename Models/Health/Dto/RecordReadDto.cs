using System.ComponentModel.DataAnnotations;

namespace Home_app.Models.Health.Dto;

public class RecordReadDto
{
    public DateTime DateTime { get; init; }
    [Required] public double BodyWeight { get; init; }
    public ICollection<Measurement>? Measurements { get; set; }
    public ICollection<Lift>? Lifts { get; set; }
}