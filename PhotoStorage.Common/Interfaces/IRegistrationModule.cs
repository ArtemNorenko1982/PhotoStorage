using Microsoft.Extensions.DependencyInjection;

namespace PhotoStorage.Common.Interfaces
{
    public interface IRegistrationModule
    {
        void Register(IServiceCollection services);
    }
}
