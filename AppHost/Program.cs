using System.Reflection;
using Application;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Presentation;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("DB");

builder.Services.AddApplication()
    .AddInfrastructure(connectionString)
    .AddPresentation();

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

WebApplication app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseCors(x => x
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true)
        .WithOrigins("https://localhost:5173"));
        //.AllowCredentials()); // allow credentials

    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
