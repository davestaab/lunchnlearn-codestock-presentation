using System.Net;
using Polly.Simmy;

var inventory = builder.Services
    .AddHttpClient<InventoryClient>(client =>
        client.BaseAddress = new("https://inventory-service"));

inventory.AddStandardResilienceHandler();   // 1. resilience first (outer)

if (builder.Environment.IsDevelopment())
{
    // 2. chaos after it (inner): 5% of calls come back as a 500
    inventory.AddResilienceHandler("chaos", pipeline => pipeline
        .AddChaosOutcome(0.05, () =>
            new HttpResponseMessage(HttpStatusCode.InternalServerError)));
}
