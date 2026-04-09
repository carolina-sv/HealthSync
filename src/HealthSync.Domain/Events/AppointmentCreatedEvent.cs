namespace HealthSync.Domain.Events;

public record AppointmentCreatedEvent(
    Guid AppointmentId,
    Guid PatientId,
    string DoctorName,
    DateTime ScheduledDateTime
);