using System.ComponentModel.DataAnnotations;
using Home_app.Models.Health.Enums;

namespace Home_app.Models.Health.Dto;

public class LiftCreateDto
{
    [Required] public Exercise Exercise { get; init; }
    [Required] public double Weight { get; init; }
}