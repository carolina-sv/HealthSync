using System;
using HealthSync.Domain.Enums; // Necessário para encontrar o AppointmentStatus

namespace HealthSync.Domain.Entities;

public class Appointment
{
    public Guid Id { get; private set; }
    public Guid PatientId { get; private set; }
    public string DoctorName { get; private set; } = null!;
    public DateTime ScheduledDateTime { get; private set; }
    public AppointmentStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }

    // Propriedade de navegação (Opcional, mas ajuda o Entity Framework)
    public Patient Patient { get; private set; } = null!;

    // Construtor vazio para o EF Core
    protected Appointment() { }

    public Appointment(Guid patientId, string doctorName, DateTime scheduledDateTime)
    {
        Id = Guid.NewGuid();
        PatientId = patientId;
        DoctorName = doctorName;
        ScheduledDateTime = scheduledDateTime;
        Status = AppointmentStatus.Pending;
        CreatedAt = DateTime.UtcNow;
    }
}