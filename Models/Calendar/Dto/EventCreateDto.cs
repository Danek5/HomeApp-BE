using System.ComponentModel.DataAnnotations;

namespace Home_app.Models.Dto;

public class EventCreateDto
{
    [Required] [MaxLength(50)] public string Name { get; init; } = null!;
    [Required] [MaxLength(200)] public string Description { get; init; } = null!;
}