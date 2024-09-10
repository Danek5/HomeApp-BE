using System.ComponentModel.DataAnnotations;


namespace Home_app.Models.Health;

public class Health
{
    [Key] public Guid Id { get; init; }
    [Required] public double BodyWeight { get; init; }
    public IEnumerable<BodyDiameter>? BodyDiameters { get; set; }
    public IEnumerable<Result>? Results { get; set; }
}