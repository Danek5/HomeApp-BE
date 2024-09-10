using System.ComponentModel.DataAnnotations;
using Home_app.Models.Health.Enums;

namespace Home_app.Models.Health;

public class Result
{
    public Guid Id;
    [Required] public Exercise Exercise { get; init; }
    [Required] public double Weight { get; init; }
}