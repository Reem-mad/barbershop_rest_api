using Barbershop.Contracts;
using Barbershop.Data;
using Barbershop.Models;
using Microsoft.EntityFrameworkCore;

namespace Barbershop.Repository;

public interface IUserRepository{
    public Task<bool> CreateUser(CreateUserDto user);
    public Task<bool> DeleteUser(int userId);
    public Task<bool> UpdateUser(int userId, User user);
    public Task<ICollection<Appointment>> GetAppointments(int page = 0, int counterPerPage = 10);
    public Task<User?> GetUser(int userId);
    public Task<ICollection<User>> GetUsers(int page = 0, int counterPerPage = 10);
}

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context){
        _context = context;
    }

    public async Task<bool> CreateUser(CreateUserDto user)
    {
        var dbUser = new User
        {
            Name = user.Name,
            Email = user.Email,
            IsVisible = true
        };

        await _context.Users.AddAsync(dbUser);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteUser(int userId)
    {
        var dbUser =await GetUser(userId);
        if (dbUser == null) return false;
        dbUser.IsVisible = false;
        await _context.SaveChangesAsync();
        return true;
    }

    public Task<ICollection<Appointment>> GetAppointments(int page = 0, int counterPerPage = 10)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetUser(int userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    public async Task<ICollection<User>> GetUsers(int page = 0, int counterPerPage = 10)
    {
        return await _context.Users
            .Where(u => u.IsVisible)
            .Skip((page-1)* counterPerPage)
            .Take(counterPerPage)
            .ToListAsync();
    }

    public Task<bool> UpdateUser(int userId, User user)
    {
        throw new NotImplementedException();
    }
}