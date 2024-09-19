using System.ComponentModel.DataAnnotations;
using Home_app.Models.Calendar.Enums;

namespace Home_app.Models.Calendar.Dto;

public class EventUpdateDto
{
    [Required] [MaxLength(50)] public string Name { get; set; } = null!;
    [Required] [MaxLength(200)] public string Description { get; set; } = null!;
    [Required] public DateTime DateTime{ get; set; }
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    public Frequency Frequency { get; set; }
    public bool Finished { get; set; }
    public bool Archived { get; set; }
}