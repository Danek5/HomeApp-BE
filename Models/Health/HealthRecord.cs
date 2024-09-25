using System.ComponentModel.DataAnnotations;

namespace Home_app.Models.Health;

public class HealthRecord
{
    [Key] public Guid Id { get; init; }
    public DateTime DateTime { get; init; } = DateTime.UtcNow;
    [Required] public double BodyWeight { get; init; }
    public ICollection<Measurement>? Measurements { get; set; }
    public ICollection<Lift>? Lifts { get; set; }
}