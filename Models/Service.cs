namespace Barbershop.Models;

public enum ServiceTarget{
    Female,
    Male,
    Both
}

public class Service{
    public int Id {get; set; }
    public required string Name {get; set; }
    public int Duration { get; set; }
    public double Price {get; set; }
    public ServiceTarget ServiceTarget {get; set; } = ServiceTarget.Male;
}