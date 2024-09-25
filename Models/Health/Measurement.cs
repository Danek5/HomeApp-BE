using System.ComponentModel.DataAnnotations;
using Home_app.Models.Health.Enums;

namespace Home_app.Models.Health;

public class Measurement
{
    [Key] public Guid Id { get; init; }
    [Required] public BodyPart BodyPart { get; init; }
    [Required] public double Diameter { get; init; }
}