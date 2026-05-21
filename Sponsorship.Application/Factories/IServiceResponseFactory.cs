using Sponsorship.Application.Wrappers;

namespace Sponsorship.Application.Factories;

public interface IServiceResponseFactory
{
    ServiceResponse<T> Create<T>(
        bool success,
        string? message = null,
        T? data = default
    );
}