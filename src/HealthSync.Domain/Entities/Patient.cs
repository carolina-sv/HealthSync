using System;

namespace HealthSync.Domain.Entities;

public class Patient
{
  public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string Phone { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; }
    // Construtor vazio exigido pelo EF Core futuramente
    protected Patient() { }

    public Patient(string name, string email, string phone)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Phone = phone;
        CreatedAt = DateTime.UtcNow;
    }
}