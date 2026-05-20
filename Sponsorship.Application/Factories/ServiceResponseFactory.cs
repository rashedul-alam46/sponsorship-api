using Sponsorship.Application.Wrappers;

namespace Sponsorship.Application.Factories;

public class ServiceResponseFactory : IServiceResponseFactory
{
    public ServiceResponse<T> Create<T>(bool success, string? message, T? data)
    {
        return new ServiceResponse<T>
        {
            Success = success,
            Message = message,
            Data = data
        };
    }
}