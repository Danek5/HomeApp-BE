using System.ComponentModel.DataAnnotations;

namespace Home_app.Models.Health.Dto;

public class RecordCreateDto
{
    [Required] public double BodyWeight { get; init; }
}