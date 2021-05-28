
using AutoMapper;
using Login.Application.Interfaces;
using Login.Application.Services;
using Login.Domain.Interfaces;
using Login.Infrastructure.Context;
using Login.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Login.Crosscutting
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IClientServices, ClientServices>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ClientContext>();
        }
    }
}