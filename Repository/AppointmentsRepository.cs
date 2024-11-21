using Barbershop.Data;
using Barbershop.Models;

namespace Barbershop.Repository;

public interface IAppointmentsRepository{
    public Task<Appointment> GetAppointment(int appointmentId);
    public Task<ICollection<Appointment>> GetClientsAppointments(int userId, int page = 0, int countPerPage = 10);
    public Task<ICollection<Appointment>> GetBarberAppointments(int barberId, int page = 0, int countPerPage = 10);
    public Task<bool> UpdateAppointment(int appointmentId, Appointment appointment);
    public Task<bool> CreateAppointment(Appointment appointment);
    public Task<bool> DeleteAppoint(int appointmentId);
}

public class AppointmentsRepository: IAppointmentsRepository{
    private readonly AppDbContext _context;
    private readonly BarberAvailabilityRespository _availabilityRespository;

    public AppointmentsRepository(AppDbContext context, BarberAvailabilityRespository availabilityRespository){
        _context = context;
        _availabilityRespository = availabilityRespository;
    }

    public async Task<bool> CreateAppointment(Appointment appointment)
    {
        bool isBarberAvailable = await _availabilityRespository.CheckBarberAvailability(appointment.Barber.Id, appointment.StartsOn, appointment.EndsOn);
        if (!isBarberAvailable){
            return false;
        }
        bool res = await _availabilityRespository.CloseBarberAvailability(appointment.Barber.Id, appointment.StartsOn, appointment.EndsOn);
        await _context.Appointments.AddAsync(appointment);
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAppoint(int appointmentId)
    {
        throw new NotImplementedException();
    }

    public Task<Appointment> GetAppointment(int appointmentId)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Appointment>> GetBarberAppointments(int barberId, int page, int countPerPage)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Appointment>> GetClientsAppointments(int userId, int page, int countPerPage)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAppointment(int appointmentId, Appointment appointment)
    {
        throw new NotImplementedException();
    }
}

