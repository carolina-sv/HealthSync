using HealthSync.Infrastructure.Data;
using HealthSync.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthSync.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly HealthSyncDbContext _context;
    public PatientsController(HealthSyncDbContext context) => _context = context;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Patient patient)
    {
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
        return Ok(patient);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _context.Patients.ToListAsync());
}