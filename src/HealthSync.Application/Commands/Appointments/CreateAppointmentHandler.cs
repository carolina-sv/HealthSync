using HealthSync.Domain.Entities;
using HealthSync.Domain.Events;
using HealthSync.Domain.Interfaces;
using System.Threading.Tasks;

namespace HealthSync.Application.Commands.Appointments;

public class CreateAppointmentHandler
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMessageBus _messageBus; // 1. Declaramos o Bus aqui

    // 2. Adicionamos o IMessageBus no construtor
    public CreateAppointmentHandler(
        IAppointmentRepository appointmentRepository,
        IMessageBus messageBus)
    {
        _appointmentRepository = appointmentRepository;
        _messageBus = messageBus;
    }

    public async Task Handle(CreateAppointmentCommand command)
    {
        // 1. Criar a entidade
        var appointment = new Appointment(
            command.PatientId,
            command.DoctorName,
            command.ScheduledDateTime
        );

        // 2. Salva no banco (Postgres)
        await _appointmentRepository.AddAsync(appointment);

        // 3. Dispara o evento (RabbitMQ)
        var @event = new AppointmentCreatedEvent(
            appointment.Id,
            appointment.PatientId,
            appointment.DoctorName,
            appointment.ScheduledDateTime
        );

        _messageBus.Publish(@event);
    }
}