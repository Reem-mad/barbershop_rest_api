using Barbershop.Data;
using Barbershop.Models;

namespace Barbershop.Repository;

public interface IBarberRepository{
    public Task<bool> CreateBarber(Barber barber);
    public Task<Barber?> GetBarber(int barberId);
    public Task<ICollection<Barber>> GetBarbers(int page = 0, int countPerPage = 10);
    public Task<bool> UpdateBarber(int barberId, Barber barber);
    public Task<bool> DeleteBarber(int barberId);
    public Task<bool> AddService(int barberId, Service service);
    public Task<bool> RemoveService(int barberId, int serviceId);
    public Task<bool> AddAvailability(int barberId, BarberAvailability availability);
}


public class BarberRepository : IBarberRepository
{
    private readonly AppDbContext _context;
    
    public BarberRepository(AppDbContext context){
        _context = context;
    }

    public Task<bool> AddAvailability(int barberId, BarberAvailability availability)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddService(int barberId, Service service)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateBarber(Barber barber)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteBarber(int barberId)
    {
        throw new NotImplementedException();
    }

    public Task<Barber?> GetBarber(int barberId)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Barber>> GetBarbers(int page = 0, int countPerPage = 10)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveService(int barberId, int serviceId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateBarber(int barberId, Barber barber)
    {
        throw new NotImplementedException();
    }
}