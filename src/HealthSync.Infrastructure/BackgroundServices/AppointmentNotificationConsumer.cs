using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HealthSync.Infrastructure.BackgroundServices;

public class AppointmentNotificationConsumer : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "appointment_notifications", durable: false, exclusive: false, autoDelete: false, arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            System.Console.WriteLine($" [NOTIFICAÇÃO] Mensagem recebida: {message}");
        };

        channel.BasicConsume(queue: "appointment_notifications", autoAck: true, consumer: consumer);
        return Task.CompletedTask;
    }
}