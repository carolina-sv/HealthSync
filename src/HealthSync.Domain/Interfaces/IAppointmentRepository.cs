using HealthSync.Domain.Entities;

namespace HealthSync.Domain.Interfaces;

public interface IAppointmentRepository
{
    Task<Appointment?> GetByIdAsync(Guid id);
    Task<IEnumerable<Appointment>> GetPendingAppointmentsAsync();
    Task AddAsync(Appointment appointment);
    Task UpdateAsync(Appointment appointment);
}