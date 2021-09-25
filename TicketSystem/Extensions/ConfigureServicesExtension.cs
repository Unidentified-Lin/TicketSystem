using System;
using TicketSystem.Services;
using TicketSystem.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace TicketSystem.Extensions
{
    public static class ConfigureServicesExtension
    {

        public static void AddService(this IServiceCollection services)
        {
            //add more services
            services.AddScoped<ITicketService, TicketService>();
        }
    }
}
