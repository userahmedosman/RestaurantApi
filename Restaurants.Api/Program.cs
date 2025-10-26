using Restaurants.Application.Extensions;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seed;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .WriteTo.File("logs/Restaurant-Api-.log.txt", rollingInterval: Serilog.RollingInterval.Day, rollOnFileSizeLimit: true)
    .ReadFrom.Configuration(ctx.Configuration));
var app = builder.Build();

app.UseSerilogRequestLogging();
var scope = app.Services.CreateScope();
var restaturantSeed = scope.ServiceProvider.GetRequiredService<IRestaturantSeed>();
await restaturantSeed.Seed();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
