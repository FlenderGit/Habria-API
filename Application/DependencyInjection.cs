using System.Reflection;
using Application.Common;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {    
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            

            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
