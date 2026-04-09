using HealthSync.Application.Commands.Appointments;
using Microsoft.AspNetCore.Mvc;

namespace HealthSync.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly CreateAppointmentHandler _handler;

    public AppointmentsController(CreateAppointmentHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAppointmentCommand command)
    {
        try
        {
            await _handler.Handle(command);
            return Ok(new { message = "Agendamento criado com sucesso!" });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}