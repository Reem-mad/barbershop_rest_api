using Barbershop.Data;
using Barbershop.Models;
using Microsoft.EntityFrameworkCore;

namespace Barbershop.Repository;

public interface IBarberAvailabilityRepository{
    public Task<bool> CheckBarberAvailability(int barberId, DateTime start, DateTime end);
    public Task<BarberAvailability?> CloseBarberAvailability(int barberId, DateTime start, DateTime end);
    public Task<bool> OpenBarberAvailability(int barberId, DateTime start, DateTime end);
}


public class BarberAvailabilityRespository : IBarberAvailabilityRepository
{
    private readonly AppDbContext _context;
    public BarberAvailabilityRespository(AppDbContext context){
        _context = context;
    }

    public async Task<bool> CheckBarberAvailability(int barberId, DateTime start, DateTime end)
    {
        var availability = await _context.BarberAvailabilities.FirstOrDefaultAsync(x => x.BarberId == barberId && x.StartDate == start && x.EndDate == end);
        return availability == null || availability.IsAvailable;
    }

    public async Task<BarberAvailability?> CloseBarberAvailability(int barberId, DateTime start, DateTime end)
    {
        var availability = await _context.BarberAvailabilities.FirstOrDefaultAsync(x => x.BarberId == barberId && x.StartDate == start && x.EndDate == end);
        if (availability == null) return null;
        availability.IsAvailable = false;
        await _context.SaveChangesAsync();
        return availability;
    }

    public async Task<bool> OpenBarberAvailability(int barberId, DateTime start, DateTime end)
    {
        var availability = await _context.BarberAvailabilities.FirstOrDefaultAsync(x => x.BarberId == barberId && x.StartDate == start && x.EndDate == end);
        if (availability == null) return false;
        availability.IsAvailable = true;
        await _context.SaveChangesAsync();
        return true;
    }
}