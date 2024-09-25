using System.ComponentModel.DataAnnotations;
using Home_app.Models.Health.Enums;

namespace Home_app.Models.Health;

public class Lift
{
    [Key] public Guid Id { get; init; }
    [Required] public Exercise Exercise { get; init; }
    [Required] public double Weight { get; init; }
}