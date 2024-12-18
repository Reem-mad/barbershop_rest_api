namespace Barbershop.Contracts;


public class HairSaloonDto
{
    public int Id { get; set; }
    public required string ShopName { get; set; } 
    public required CreateLocationDto SaloonLocation { get; set; } 
    public required CreateContactDto Contact { get; set; } 
}