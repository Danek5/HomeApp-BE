using System.ComponentModel.DataAnnotations;

namespace Home_app.Models.Health.Dto;

public class MeasurementCreateDto
{
    [Required] public UInt16 BodyPart { get; init; }
    [Required] public double Diameter { get; init; }
}