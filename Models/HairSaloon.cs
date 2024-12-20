namespace Barbershop.Models;

public class HairSaloon{
    public int Id {get; set; }
    public required string ShopName {get; set; }
    public required Location SaloonLocation {get; set; }
    public required Contact Contact {get; set; }
    public List<Barber> Barbers {get;} = new List<Barber>();
    public bool IsVisible {get; set;} = true;
}