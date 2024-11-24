using System.ComponentModel.DataAnnotations;

namespace Home_app.Models.Health;

public class HealthRecord
{
    [Key] public Guid Id { get; init; }
    public DateOnly Date { get; init; } = DateOnly.FromDateTime(DateTime.Now);
    [Required] public double BodyWeight { get; init; }
    public virtual ICollection<Measurement>? Measurements { get; set; }
    public virtual ICollection<Lift>? Lifts { get; set; }
}