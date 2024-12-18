namespace Barbershop.Contracts;
public class CreateLocationDto
{
    public required string Province { get; set; }
    public required string City { get; set; }
    public string? Street {get;  set; }
    public required string Address {get;  set; }
}