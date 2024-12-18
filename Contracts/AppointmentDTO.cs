using Barbershop.Models;

namespace Barbershop.Contracts;

public class AppointmentDto 
{
    public int Id { get; set; }
    public int CustomerId { get; set; } 
    public int BarberId { get; set; }
    public DateTime StartsOn { get; set; }
    public DateTime EndsOn { get; set; }
    public AppointmentStatus Status { get; set; }
    public int ServiceId { get; set; } 
}
