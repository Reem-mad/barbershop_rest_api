namespace Barbershop.Contracts;

public class CreateAppointmentDto 
{
    public int CustomerId { get; set; } 
    public int BarberId { get; set; }
    public DateTime StartsOn { get; set; }
    public DateTime EndsOn { get; set; }
    public int ServiceId { get; set; } 
}