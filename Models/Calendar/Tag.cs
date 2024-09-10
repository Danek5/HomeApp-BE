using System.ComponentModel.DataAnnotations;

namespace Home_app.Models.Calendar;

public class Tag
{
    [Key]
    public Guid Id { get; init; }
    [Required] [MaxLength(20)] public string Name { get; set; } = null!;
    [Required]
    [Range(1,10)]
    public int Priority { get; set; }
}
