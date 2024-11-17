using Barbershop.Models;
using Microsoft.EntityFrameworkCore;

namespace Barbershop.Data;

public class AppDbContext: DbContext{
    public DbSet<User> Users {get; set; }
    public DbSet<Barber> Barbers {get; set; }
    public DbSet<HairSaloon> HairSaloons {get; set; }
    public DbSet<Location> Locations {get; set ;}
    public DbSet<Contact> Contacts {get; set; }
    public DbSet<Service> Services {get; set; }
    public DbSet<Appointment> Appointments {get; set; }
    public DbSet<BarberAvailability> BarberAvailabilities{get; set; }


    public AppDbContext(DbContextOptions<AppDbContext> options): base(options){
        Users = Set<User>();
        Barbers = Set<Barber>();
        HairSaloons = Set<HairSaloon>();
        Locations = Set<Location>();
        Contacts = Set<Contact>();
        Services = Set<Service>();
        Appointments = Set<Appointment>();
        BarberAvailabilities = Set<BarberAvailability>();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured){
            optionsBuilder.UseSqlite("Data Source=db.sqlite3");
        }
    }
}