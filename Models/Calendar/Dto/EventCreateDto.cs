using System.ComponentModel.DataAnnotations;
using Home_app.Models.Calendar.Enums;

namespace Home_app.Models.Calendar.Dto;

public class EventCreateDto
{
    [Required] [MaxLength(50)] public string Name { get; set; } = null!;
    [Required] [MaxLength(200)] public string Description { get; set; } = null!;
    [Required] public DateOnly Date{ get; set; }}