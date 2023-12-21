using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushTickets.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddCustomValdiatorConfigure(this IServiceCollection services)
        {
            services.AddScoped<IValidator<TicketDto>, AddTicketValidator>();
            services.AddControllersWithViews().AddFluentValidation();

        }
    }
}