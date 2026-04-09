using HealthSync.Application.Commands.Appointments;
using HealthSync.Domain.Interfaces;
using HealthSync.Infrastructure.Data;
using HealthSync.Infrastructure.Messaging;
using HealthSync.Infrastructure.Repositories;
using HealthSync.Infrastructure.BackgroundServices; // Adicionado
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Banco de Dados
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HealthSyncDbContext>(options =>
    options.UseNpgsql(connectionString));

// 2. CORS (Libera o acesso para o Swagger não reclamar)
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// 3. Injeção de Dependência
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IMessageBus, RabbitMqService>();
builder.Services.AddScoped<CreateAppointmentHandler>();
builder.Services.AddHostedService<AppointmentNotificationConsumer>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4. Middleware
app.UseCors("AllowAll"); // Ativa o CORS

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run(); // ÚNICO comando para rodar. SEM app.Start()!