using Barbershop.Contracts;
using Barbershop.Data;
using Barbershop.Models;
using Microsoft.EntityFrameworkCore;

namespace Barbershop.Repository;

public interface IServiceRepository{
    public Task<Service?> CreateService(CreateServiceDto service, int barberId);
    public Task<ICollection<Service>> GetBarberServices(int barberId, int page = 0, int countPerPage = 10);
    public Task<bool> UpdateService(int serviceId, int barberId, Service service);
    public Task<bool> DeleteService(int serviceId, int barberId);
    public Task<Service?> GetService(int serviceId);
}

public class ServiceRepository : IServiceRepository
{
    private readonly AppDbContext _context;
    
    public ServiceRepository(AppDbContext context){
        _context = context;
    }

    public async Task<Service?> CreateService(CreateServiceDto service, int barberId)
    {
        Service dbService = new Service
        {
            Name = service.Name,
            Duration = service.Duration,
            Price = service.Price,
            ServiceTarget = service.ServiceTarget
        };
        var barber = await _context.Barbers.FindAsync(barberId);
        if (barber == null) return null;
        barber.ServicesProvided.Add(dbService);
        await _context.SaveChangesAsync();
        return dbService;
    }

    public async Task<bool> DeleteService(int serviceId, int barberId)
    {
        var dbService = await _context.Services.FirstOrDefaultAsync(s => s.Id == serviceId && s.BarberId == barberId);
        if (dbService == null) return false;
        dbService.IsVisible = false;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<ICollection<Service>> GetBarberServices(int barberId, int page = 0, int countPerPage = 10)
    {
        var services = await _context.Services.Where(s => s.BarberId == barberId).Skip(page * countPerPage).Take(countPerPage).ToListAsync();
        return services;
    }

    public Task<bool> UpdateService(int serviceId, int barberId, Service service)
    {
        throw new NotImplementedException();
    }

    public async Task<Service?> GetService(int serviceId){
        return await _context.Services.FindAsync(serviceId);
    }
}