using System.ComponentModel.DataAnnotations;
using Home_app.Models.Calendar.Enums;

namespace Home_app.Models.Calendar;

public class Event
{
    [Key] public Guid Id { get; init; }
    [Required] [MaxLength(50)] public string Name { get; init; } = null!;
    [Required] [MaxLength(200)] public string Description { get; init; } = null!;
    [Range(1, 10)] public int Priority { get; init; }
    public Frequency Frequency { get; init; }
    public bool Finished { get; init; }
    public bool Archived { get; init; }
}
