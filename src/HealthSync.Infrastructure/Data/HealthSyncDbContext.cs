using HealthSync.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthSync.Infrastructure.Data;

public class HealthSyncDbContext : DbContext
{
    public HealthSyncDbContext(DbContextOptions<HealthSyncDbContext> options) : base(options) { }

    
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Patient> Patients { get; set; }
}