using Barbershop.Data;
using Barbershop.Models;

namespace Barbershop.Repository;

public interface IServiceRepository{
    public Task<bool> CreateService(Service service, int barberId);
    public Task<ICollection<Service>> GetBarberServices(int barberId, int page = 0, int countPerPage = 10);
    public Task<bool> UpdateService(int serviceId, int barberId, Service service);
    public Task<bool> DeleteService(int serviceId, int barberId);
}

public class ServiceRepository : IServiceRepository
{
    private readonly AppDbContext _context;
    
    public ServiceRepository(AppDbContext context){
        _context = context;
    }

    public Task<bool> CreateService(Service service, int barberId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteService(int serviceId, int barberId)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Service>> GetBarberServices(int barberId, int page = 0, int countPerPage = 10)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateService(int serviceId, int barberId, Service service)
    {
        throw new NotImplementedException();
    }
}