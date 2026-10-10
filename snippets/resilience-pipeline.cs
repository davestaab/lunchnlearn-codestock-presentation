// Program.cs (OrdersApi)
// Package: Microsoft.Extensions.Http.Resilience (built on Polly)
builder.Services
    .AddHttpClient<InventoryClient>(client =>
        client.BaseAddress = new("https://inventory-service"))
    .AddStandardResilienceHandler();

// One line gives you, outermost to innermost:
//   rate limiter → total timeout (30s) → retry (3x, exponential + jitter)
//   → circuit breaker → attempt timeout (10s)
