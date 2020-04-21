using Microsoft.Extensions.DependencyInjection;
using PhotoStorage.Common.Interfaces;
using PhotoStorage.Services.Interfaces;
using PhotoStorage.Services.Services;

namespace PhotoStorage.Application.Container.Registration
{
    public class ServicesRegistration : IRegistrationModule
    {
        public void Register(IServiceCollection services)
        {
            services.AddTransient<IApiService, ApiService>();
            services.AddTransient<IConnectionService, ConnectionService>();
            services.AddTransient<IImageService, ImageService>();
        }
    }
}
