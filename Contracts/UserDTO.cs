using Barbershop.Models;

namespace Barbershop.Contracts;

public class UserDto
{
    public int Id { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public CreateLocationDto? Location { get; set; } 
}

public class CreateUserDto{
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public CreateLocationDto? Location { get; set; } 
}