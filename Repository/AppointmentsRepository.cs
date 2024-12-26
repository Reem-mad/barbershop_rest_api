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
   

    public AppointmentsRepository(AppDbContext context){
        _context = context;
    }

    public async Task<bool> CreateAppointment(CreateAppointmentDto appointment)
    {
        Barber? barber = await _context.Barbers.FindAsync(appointment.BarberId);
        Service? service = await _context.Services.FindAsync(appointment.ServiceId);
        User? customer = await _context.Users.FindAsync(appointment.CustomerId);
        
        if (barber == null || service == null || customer == null) {return false; }
        var availability =  await _context.BarberAvailabilities.Where(
            x => x.BarberId == appointment.BarberId && !x.IsAvailable &&
            ((x.StartDate <= appointment.StartsOn && appointment.StartsOn <= x.EndDate) ||
            (appointment.StartsOn <= x.StartDate && x.StartDate <= appointment.EndsOn))
            ).FirstOrDefaultAsync();
        if (availability != null) { return false; }
        Appointment dbAppointment = new Appointment
        {
            Barber = barber,
            Service = service,
            Customer = customer,
            StartsOn = appointment.StartsOn,
            EndsOn = appointment.EndsOn,
            IsVisible = true
        };
        await _context.Appointments.AddAsync(dbAppointment);
        _context.BarberAvailabilities.Add(new BarberAvailability
        {
            Barber = barber,
            StartDate = appointment.StartsOn,
            EndDate = appointment.EndsOn,
            IsAvailable = false
        });
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAppointment(int appointmentId)
    {
        var dbAppointment = await _context.Appointments.FindAsync(appointmentId);
        if (dbAppointment == null) return false;
        dbAppointment.IsVisible = false;
        // await _availabilityRespository.OpenBarberAvailability(dbAppointment.Barber.Id, dbAppointment.StartsOn, dbAppointment.EndsOn);
        var availability = await _context.BarberAvailabilities.FirstOrDefaultAsync(x => x.BarberId == dbAppointment.Barber.Id && x.StartDate == dbAppointment.StartsOn && x.EndDate == dbAppointment.EndsOn);
        if (availability == null) return false;
        availability.IsAvailable = true;
        await _context.SaveChangesAsync();
        await Task.Delay(0);
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

