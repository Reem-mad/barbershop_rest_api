using Barbershop.Contracts;
using Barbershop.Data;
using Barbershop.Models;
using Microsoft.EntityFrameworkCore;

namespace Barbershop.Repository;

public interface IBarberRepository{
    public Task<bool> CreateBarber(BarberDto barber);
    public Task<Barber?> GetBarber(int barberId);
    public Task<ICollection<Barber>> GetBarbers(int page = 0, int countPerPage = 10);
    public Task<bool> UpdateBarber(int barberId, BarberDto barber);
    public Task<bool> DeleteBarber(int barberId);
    public Task<bool> AddService(int barberId, CreateServiceDto service);
    public Task<bool> RemoveService(int barberId, int serviceId);
    public Task<bool> AddAvailability(int barberId, BarberAvailability availability);
}


public class BarberRepository : IBarberRepository
{
    private readonly AppDbContext _context;
    
    public BarberRepository(AppDbContext context){
        _context = context;
    }

    public async Task<bool> AddAvailability(int barberId, BarberAvailability availability)
    {
        var barber = await GetBarber(barberId);
        if (barber == null) return false;
        barber.Availabilities.Add(availability);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AddService(int barberId, CreateServiceDto service)
    {
        var barber = await GetBarber(barberId);
        if (barber == null) return false;
        barber.ServicesProvided.Add(new Service { Name = service.Name, Price = service.Price });
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> CreateBarber(BarberDto barber)
    {
        var dbUser = await _context.Users.FindAsync(barber.UserId);
        var dbSaloon = await _context.HairSaloons.FindAsync(barber.HairSaloonId);
        if (dbUser == null || dbSaloon == null) return false;

        var dbBarber = new Barber
        {
            User = dbUser,
            HairSaloonId = barber.HairSaloonId,
            Saloon = dbSaloon,
            ServicesProvided = new List<Service>()
        };
        await _context.Barbers.AddAsync(dbBarber);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteBarber(int barberId)
    {
        var dbBarber = await GetBarber(barberId);
        if (dbBarber == null) return false;
        dbBarber.IsVisible = false;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Barber?> GetBarber(int barberId)
    {
        var dbBarber = await _context.Barbers.FirstOrDefaultAsync(barber => barber.Id == barberId && barber.IsVisible);
        return dbBarber;
    }

    public async Task<ICollection<Barber>> GetBarbers(int page = 0, int countPerPage = 10)
    {
        var dbBarbars = await _context.Barbers
            .Where(barber => barber.IsVisible)
            .Skip((page-1)* countPerPage)
            .Take(countPerPage)
            .ToListAsync();
        return dbBarbars;
    }

    public Task<bool> RemoveService(int barberId, int serviceId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateBarber(int barberId, BarberDto barber)
    {
        throw new NotImplementedException();
    }
}