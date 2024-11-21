using Barbershop.Data;
using Barbershop.Models;

namespace Barbershop.Repository;

public interface IHairSaloonRepository{
    public Task<bool> CreateSaloon(HairSaloon saloon);
    public Task<bool> UpdateSaloon(int saloonId, HairSaloon saloon);
    public Task<bool> DeleteSaloon(int saloonId, int barberId);
    public Task<bool> AddBarberToSaloon(int saloonId, Barber barber);
    public Task<bool> RemoveBarberFromSaloon(int saloonId, Barber barber);
}


public class HairSaloonRepository : IHairSaloonRepository
{
    private readonly AppDbContext _context;

    public HairSaloonRepository(AppDbContext context){
        _context = context;
    }
    
    public Task<bool> AddBarberToSaloon(int saloonId, Barber barber)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateSaloon(HairSaloon saloon)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteSaloon(int saloonId, int barberId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveBarberFromSaloon(int saloonId, Barber barber)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateSaloon(int saloonId, HairSaloon saloon)
    {
        throw new NotImplementedException();
    }
}
