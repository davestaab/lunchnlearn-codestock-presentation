// Program.cs (OrdersApi)
// Packages: OpenTelemetry.Extensions.Hosting, OpenTelemetry.Instrumentation.AspNetCore,
//           OpenTelemetry.Instrumentation.Http, OpenTelemetry.Exporter.OpenTelemetryProtocol
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenTelemetry()
    .ConfigureResource(resource => resource.AddService("OrdersApi"))
    .WithTracing(tracing => tracing
        .AddAspNetCoreInstrumentation()   // a span for every incoming request
        .AddHttpClientInstrumentation()   // a child span for every outgoing call
        .AddSource("OrdersApi")           // our own custom spans
        .AddOtlpExporter());              // send to localhost:4317 by default

var app = builder.Build();
