namespace Barbershop.Models;

public class Barber{
    public int Id {get; set; }
    public int HairSaloonId {get; set; } // foreign key for the saloon the barber belongs to
    public required HairSaloon Saloon {get; set; }
    public required User User {get; set;}
    public required ICollection<Service> ServicesProvided {get; set;} 
    public  List<BarberAvailability> Availabilities {get; } = new List<BarberAvailability>();
    public bool IsVisible {get; set;} = true;
}