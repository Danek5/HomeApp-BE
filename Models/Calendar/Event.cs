using System.ComponentModel.DataAnnotations;
using Home_app.Models.Calendar.Enums;

namespace Home_app.Models.Calendar;

public class Event
{
    [Key] public Guid Id { get; init; }
    [Required] [MaxLength(50)] public string Name { get; set; } = null!;
    [Required] [MaxLength(200)] public string Description { get; set; } = null!;
    public IEnumerable<Tag>? Tags { get; set; }
    public Frequency Frequency { get; set; }
    public bool Finished { get; set; }
    public bool Archived { get; set; }
}
