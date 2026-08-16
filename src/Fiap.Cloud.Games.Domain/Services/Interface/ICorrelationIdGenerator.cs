namespace Fiap.Cloud.Games.Domain.Services.Interface;

public interface ICorrelationIdGenerator
{
    string Get();
    void Set(string correlationId);
}
