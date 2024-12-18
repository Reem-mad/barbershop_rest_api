namespace Barbershop.Contracts;

public class BarberAvailabilityDto
{
    public int Id { get; set; }
    public int BarberId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsAvailable { get; set; } = true;
    public string? Reason { get; set; } 
}

public class CreateBarberAvailabilityDto{
    public int BarberId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsAvailable { get; set; } = true;
    public string? Reason { get; set; } 
}