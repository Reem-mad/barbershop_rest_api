using Barbershop.Models;
using Barbershop.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace Barbershop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController: ControllerBase{
    private readonly IAppointmentsRepository _appointmentRepository;
    public AppointmentsController(IAppointmentsRepository appointmentRepository){
        _appointmentRepository = appointmentRepository;
    }

    [HttpGet("{appointmentId}")]
    public async Task<IActionResult> GetAppointment(int appointmentId){
        var appointment = await _appointmentRepository.GetAppointment(appointmentId);
        if (appointment == null) 
            return NotFound();
        return Ok(appointment);
    }

}