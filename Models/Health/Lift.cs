using System.ComponentModel.DataAnnotations;

namespace Home_app.Models.Health;

public class Lift
{
    [Key] public Guid Id { get; init; }
    [Required] public UInt16 Exercise { get; init; }
    [Required] public double Weight { get; init; }
    [Required] public uint Repetitions { get; set; }
}