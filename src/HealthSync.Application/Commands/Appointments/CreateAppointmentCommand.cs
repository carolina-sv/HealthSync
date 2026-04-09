namespace HealthSync.Application.Commands.Appointments;

public record CreateAppointmentCommand(
    Guid PatientId,
    string DoctorName,
    DateTime ScheduledDateTime
);