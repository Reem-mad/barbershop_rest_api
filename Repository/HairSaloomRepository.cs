using Barbershop.Contracts;
using Barbershop.Data;
using Barbershop.Models;

namespace Barbershop.Repository;

public interface IHairSaloonRepository{
    public Task<bool> CreateSaloon(CreateSaloonDto saloon);
    public Task<bool> UpdateSaloon(int saloonId, HairSaloon saloon);
    public Task<bool> DeleteSaloon(int saloonId, int barberId);
    public Task<bool> AddBarberToSaloon(int saloonId, int barberId);
    public Task<bool> RemoveBarberFromSaloon(int saloonId, int barberId);
}


public class HairSaloonRepository : IHairSaloonRepository
{
    private readonly AppDbContext _context;

    public HairSaloonRepository(AppDbContext context){
        _context = context;
    }
    
    public async Task<bool> AddBarberToSaloon(int saloonId, int barberId)
    {
        var dbBarber = await _context.Barbers.FindAsync(barberId);
        if (dbBarber == null) return false;
        var dbSaloon = await _context.HairSaloons.FindAsync(saloonId);
        if (dbSaloon == null) return false;
        dbSaloon.Barbers.Add(dbBarber);
        await _context.SaveChangesAsync();
        return true;
    }
   

    public async Task<bool> CreateSaloon(CreateSaloonDto saloon)
    {
        HairSaloon dbSaloon = new HairSaloon
        {
            ShopName = saloon.ShopName,
            Contact = new Contact
            {
                Email = saloon.Contact.Email,
                
            },
            SaloonLocation = new Location
            {
                City = saloon.SaloonLocation.City,
                Province = saloon.SaloonLocation.Province,
                Street = saloon.SaloonLocation.Street,
                Address = saloon.SaloonLocation.Address
            }
        };
        await _context.HairSaloons.AddAsync(dbSaloon);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteSaloon(int saloonId, int barberId)
    {
        var dbSaloon = await _context.HairSaloons.FindAsync(saloonId);
        if (dbSaloon == null) return false;
        if (dbSaloon.Barbers.Any(b => b.Id == barberId))
        {
            dbSaloon.IsVisible = false;
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> RemoveBarberFromSaloon(int saloonId, int barberId)
    {
        var dbBarber = await _context.Barbers.FindAsync(barberId);
        if (dbBarber == null) return false;
        var dbSaloon = await _context.HairSaloons.FindAsync(saloonId);
        if (dbSaloon == null) return false;
        dbSaloon.Barbers.Remove(dbBarber);
        await _context.SaveChangesAsync();
        return true;
    }
   
    public Task<bool> UpdateSaloon(int saloonId, HairSaloon saloon)
    {
        throw new NotImplementedException();
    }
}
