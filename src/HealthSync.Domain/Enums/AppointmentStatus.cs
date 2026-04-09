namespace HealthSync.Domain.Enums;

public enum AppointmentStatus
{
    Pending = 0,    // Pendente
    Confirmed = 1,  // Confirmado
    Cancelled = 2,  // Cancelado
    Completed = 3,  // Concluído
    NoShow = 4      // Não compareceu
}