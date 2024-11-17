namespace Barbershop.Models;

public class BarberAvailability{
    public int Id {get; set;}
    public required Barber Barber {get; set; }
    public int BarberId {get; set; }
    public DateTime StartDate {get; set; }
    public DateTime EndDate {get; set; }
    public bool IsAvailable {get; set; } = true;
    public string? Reason {get; set; } // for when barber is not around
    public List<Appointment> Appointments {get;} = new List<Appointment>();
}