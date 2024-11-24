using System.ComponentModel.DataAnnotations;

namespace Home_app.Models.Health;

public class Measurement
{
    [Key] public Guid Id { get; init; }
    [Required] public UInt16 BodyPart  { get; init; }
    [Required] public double Diameter { get; init; }
}