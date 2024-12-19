using Barbershop.Data;
using Barbershop.Models;

namespace Barbershop.Repository;

public interface IUserRepository{
    public Task<bool> CreateUser(User user);
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

    public Task<bool> CreateUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUser(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Appointment>> GetAppointments(int page = 0, int counterPerPage = 10)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetUser(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<User>> GetUsers(int page = 0, int counterPerPage = 10)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateUser(int userId, User user)
    {
        throw new NotImplementedException();
    }
}