using System.ComponentModel.DataAnnotations;
using Home_app.Models.Health.Enums;

namespace Home_app.Models.Health.Dto;

public class MeasurementCreateDto
{
    [Required] public BodyPart BodyPart { get; init; }
    [Required] public double Diameter { get; init; }
}