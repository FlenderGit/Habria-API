using Application.Common.Interfaces;
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Infrastructure.Services.Generation.Excel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {

        services.AddDbContext<IDataContext, DataContext>((sp, options) => options.UseSqlServer(connectionString));

        services.AddScoped<IExcelService, ExcelReportBuildingService>();

        services.AddScoped<IBuildingRepository, BuildingRepository>();
        services.AddScoped<IObservationRepository, ObservationRepository>();


        services.AddScoped<IMapService, MapService>();

        return services;
    }
}
