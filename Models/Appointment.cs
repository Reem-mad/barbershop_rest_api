namespace Barbershop.Models;

public enum AppointmentStatus{
    Completed,
    Cancelled,
    Booked
}

public class Appointment{
    public int Id {get; set; }
    public required User Customer {get; set; }
    public required Barber Barber {get; set; }
    public DateTime StartsOn {get; set; }
    public DateTime EndsOn {get; set; }
    public AppointmentStatus Status {get; set;} = AppointmentStatus.Booked;
    public required Service Service {get; set; }
}