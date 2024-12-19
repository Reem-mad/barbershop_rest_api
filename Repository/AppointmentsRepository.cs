using Barbershop.Contracts;
using Barbershop.Data;
using Barbershop.Models;
using Microsoft.EntityFrameworkCore;

namespace Barbershop.Repository;

public interface IAppointmentsRepository{
    public Task<Appointment?> GetAppointment(int appointmentId);
    public Task<ICollection<Appointment>> GetClientsAppointments(int userId, int page = 0, int countPerPage = 10);
    public Task<ICollection<Appointment>> GetBarberAppointments(int barberId, int page = 0, int countPerPage = 10);
    public Task<bool> UpdateAppointment(int appointmentId, CreateAppointmentDto appointment);
    public Task<bool> CreateAppointment(CreateAppointmentDto appointment);
    public Task<bool> DeleteAppointment(int appointmentId);
}

public class AppointmentsRepository: IAppointmentsRepository{
    private readonly AppDbContext _context;
    private readonly BarberAvailabilityRespository _availabilityRespository;
    private readonly BarberRepository _barberRepo;
    private readonly ServiceRepository _serviceRepo;
    private readonly UserRepository _userRepo;

    public AppointmentsRepository(AppDbContext context, BarberAvailabilityRespository availabilityRespository, BarberRepository barberRepository, ServiceRepository serviceRepository, UserRepository userRepository){
        _context = context;
        _availabilityRespository = availabilityRespository;
        _barberRepo = barberRepository;
        _serviceRepo = serviceRepository;
        _userRepo = userRepository;
    }

    public async Task<bool> CreateAppointment(CreateAppointmentDto appointment)
    {
        Barber? barber = await _barberRepo.GetBarber(appointment.BarberId);
        Service? service = await _serviceRepo.GetService(appointment.ServiceId);
        User? customer = await _userRepo.GetUser(appointment.CustomerId);
        
        if (barber == null || service == null || customer == null) {return false; }
        bool isBarberAvailable = await _availabilityRespository.CheckBarberAvailability(appointment.BarberId, appointment.StartsOn, appointment.EndsOn);
        if (!isBarberAvailable){
            return false;
        }
        BarberAvailability? barberAvailabilityRes = await _availabilityRespository.CloseBarberAvailability(appointment.BarberId, appointment.StartsOn, appointment.EndsOn);
        if (barberAvailabilityRes == null){ return false; }
        await _barberRepo.AddAvailability(appointment.BarberId, barberAvailabilityRes);
        await _context.Appointments.AddAsync(new Appointment { Barber = barber,  Service = service, Customer = customer, EndsOn = appointment.EndsOn, StartsOn = appointment.StartsOn});
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAppointment(int appointmentId)
    {
        var dbAppointment = await _context.Appointments.FindAsync(appointmentId);
        if (dbAppointment == null) return false;
        dbAppointment.IsVisible = false;
        await _availabilityRespository.OpenBarberAvailability(dbAppointment.Barber.Id, dbAppointment.StartsOn, dbAppointment.EndsOn);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Appointment?> GetAppointment(int appointmentId)
    {
        var dbAppointment = await _context.Appointments.FindAsync(appointmentId);
        return dbAppointment;
    }

    public async Task<ICollection<Appointment>> GetBarberAppointments(int barberId, int page, int countPerPage)
    {
        var appointments = await _context.Appointments
            .Where( item => item.IsVisible && item.Barber.Id == barberId)
            .Skip((page -1) * countPerPage)
            .Take(countPerPage)
            .ToListAsync();
        return appointments;
    }

    public async Task<ICollection<Appointment>> GetClientsAppointments(int userId, int page, int countPerPage)
    {
        var appointments = await _context.Appointments
            .Where( item => item.IsVisible && item.Customer.Id == userId)
            .Skip((page -1) * countPerPage)
            .Take(countPerPage)
            .ToListAsync();
        return appointments;
    }

    public async Task<bool> UpdateAppointment(int appointmentId, CreateAppointmentDto appointment)
    {
        var dbAppointment = await DeleteAppointment(appointmentId);
        if (!dbAppointment ) return false;
        return await CreateAppointment(appointment);
    }
}

