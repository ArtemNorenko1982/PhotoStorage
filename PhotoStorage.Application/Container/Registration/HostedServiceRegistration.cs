using Microsoft.Extensions.DependencyInjection;
using PhotoStorage.Application.Container.HastedServices;
using PhotoStorage.Common.Interfaces;

namespace PhotoStorage.Application.Container.Registration
{
    public class HostedServiceRegistration : IRegistrationModule
    {
        public void Register(IServiceCollection services)
        {
            services.AddHostedService<FetchServerDataService>();
        }
    }
}
