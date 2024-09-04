using System.ComponentModel.DataAnnotations;


namespace Home_app.Models.Health;

public class Health
{
    [Key] public Guid Id { get; init; }
    [Required] public double BodyWeight { get; init; }
    public List<BodyDiameter>? BodyDiameters { get; set; } = new List<BodyDiameter>();
    public List<Result>? Results { get; set; } = new List<Result>();
}