using CleanArch.Infra.Data.Context;
using CleanArch.WebApi.Rest.Configuration;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

// ConfigureServices

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddApiConfig(builder.Configuration);

builder.Services.AddSwaggerConfig();

builder.Services.AddLoggingConfig(builder.Configuration);

builder.Services.ResolveDependencies();


var app = builder.Build();


// Configure

app.UseApiConfig(app.Environment);

app.UseSwaggerConfig();

app.UseLoggingConfiguration();

app.Run();
