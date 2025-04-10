using DB;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("SolFacturacionConecion");
//Console.WriteLine($"Connection String: {connectionString}"); // Verifica si la cadena de conexión se imprime correctamente
builder.Services.AddDbContext<SolFacturacionContext>(options =>
{
    options.UseNpgsql(connectionString);
});

//Repository
builder.Services.AddScoped<ClienteRepository>();

//Service
builder.Services.AddScoped<ClienteService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SolFacturacionContext>();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
