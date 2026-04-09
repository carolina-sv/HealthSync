using HealthSync.Domain.Entities;

namespace HealthSync.Domain.Interfaces;

public interface IPatientRepository
{
    Task<Patient?> GetByIdAsync(Guid id);
    Task<Patient?> GetByEmailAsync(string email);
    Task AddAsync(Patient patient);
}