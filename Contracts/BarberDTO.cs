namespace Barbershop.Contracts;

public class BarberDto
{
    public int Id { get; set; }
    public int HairSaloonId { get; set; }
    public int UserId { get; set; } 
    public List<int> ServicesProvidedIds { get; set; } = new List<int>(); 
}