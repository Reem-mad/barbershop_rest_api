namespace Barbershop.Models;

public class Location{
    public int Id {get; set; }
    public required string Province {get; set; }
    public required string City {get; set; }
    public string? Street {get;  set; }
    public required string Address {get;  set; }
}