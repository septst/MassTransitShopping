using MassTransit;
using Microsoft.AspNetCore.Builder;
using ProcessingService.Consumers;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog(
    (ctx, cfg) =>
        cfg.ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddMassTransit(
    busRegistrationConfigurator =>
    {
        // busRegistrationConfigurator.AddBus(_ => Bus.Factory.CreateUsingRabbitMq());
        busRegistrationConfigurator.AddConsumersFromNamespaceContaining<CheckOrderConsumer>();
        busRegistrationConfigurator.UsingRabbitMq(
            (ctx, cfg) =>
                cfg.ConfigureEndpoints(ctx));
    });

var app = builder.Build();

await app.RunAsync();