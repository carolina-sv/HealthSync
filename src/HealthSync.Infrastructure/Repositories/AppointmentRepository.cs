using HealthSync.Domain.Entities;
using HealthSync.Domain.Enums;
using HealthSync.Domain.Interfaces;
using HealthSync.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthSync.Infrastructure.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly HealthSyncDbContext _context;

    public AppointmentRepository(HealthSyncDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Appointment appointment)
    {
        await _context.Appointments.AddAsync(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task<Appointment?> GetByIdAsync(Guid id)
    {
        return await _context.Appointments.FindAsync(id);
    }

    public async Task<IEnumerable<Appointment>> GetPendingAppointmentsAsync()
    {
        return await _context.Appointments
            .Where(a => a.Status == AppointmentStatus.Pending)
            .ToListAsync();
    }

    public async Task UpdateAsync(Appointment appointment)
    {
        _context.Appointments.Update(appointment);
        await _context.SaveChangesAsync();
    }
}