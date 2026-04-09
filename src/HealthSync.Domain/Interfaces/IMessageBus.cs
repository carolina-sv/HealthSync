namespace HealthSync.Domain.Interfaces;

public interface IMessageBus { void Publish<T>(T message); }