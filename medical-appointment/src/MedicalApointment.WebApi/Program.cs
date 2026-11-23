using MedicalApointment.Application.Plugins;
using MedicalApointment.Application.UseCases;
using MedicalApointment.Application.UseCases.Medicos;
using MedicalApointment.Domain.Repositories;
using MedicalApointment.Infrastructure.Data;
using MedicalApointment.Infrastructure.Data.Repositories;
using MedicalApointment.Shared;
using MedicalApointment.WebApi.Config;
using MedicalApointment.WebApi.Endpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.SemanticKernel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSingleton<IAppConfig>(service => new AppConfig(builder.Configuration));
builder.Services.AddDbContext<AppDbContext>((service, options) =>
{
    var appConfig = service.GetRequiredService<IAppConfig>();
    options.UseNpgsql(appConfig.ConnectionString, b => b.MigrationsAssembly("MedicalApointment.WebApi"));
});

builder.Services.AddScoped<MedicoPlugin>();
builder.Services.AddScoped<IMedicoQueryRepository, MedicoQueryRepository>();
builder.Services.AddScoped<IAgendamentoMedicoQueryRepository, AgendamentoMedicoQueryRepository>();
builder.Services.AddScoped<ListarMedicosUseCase>();
builder.Services.AddScoped<ListarMedicosEspecialidadesUseCase>();
builder.Services.AddScoped<ListarMedicosAgendamentoUseCase>();

using var serviceProvider = builder.Services.BuildServiceProvider();
var appConfig = serviceProvider.GetRequiredService<IAppConfig>();


builder.Services.AddKernel();
builder.Services.AddOpenAIChatCompletion(
    modelId: appConfig.AIModel,
    endpoint: new Uri(appConfig.UrlApi),
    apiKey: appConfig.ApiKey
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapApi().MapMedicoEndpoint();
app.MapApi().MapChatEndpoint();

app.Run();
