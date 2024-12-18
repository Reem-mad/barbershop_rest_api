using Barbershop.Models;

namespace Barbershop.Contracts;

public class ServiceDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Duration { get; set; }
    public double Price { get; set; }
    public ServiceTarget ServiceTarget { get; set; } 
}

public class CreateServiceDto{
    public required string Name { get; set; }
    public int Duration { get; set; }
    public double Price { get; set; }
    public ServiceTarget ServiceTarget { get; set; } 
}
