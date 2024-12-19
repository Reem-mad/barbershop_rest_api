namespace Barbershop.Models;

public enum Gender{
    Male,
    Female
}

public class User{
    public int Id {get; set;}
    public int Age {set; get; }
    public Gender Gender {get; set; } = Gender.Male;
    public required string Name {get; set; }
    public required string Email {get; set; }
    public Location? Location {get;  set; }
    public bool IsVisible {get; set;} = false;
}