using System.ComponentModel.DataAnnotations;

namespace Home_app.Models.Health.Dto;

public class LiftCreateDto
{
    [Required] public UInt16 Exercise { get; init; }
    [Required] public double Weight { get; init; }
    [Required] public uint Repetitions { get; set; }

}