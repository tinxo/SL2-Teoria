var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// modificamos desde acá
string path = Path.Combine(AppContext.BaseDirectory, "pasajeros.txt");
builder.Services.AddScoped<IPasajeroRepository>(provider => new PasajeroRepositoryArchivo(path));
builder.Services.AddScoped<PasajeroService>();
builder.Services.AddScoped<CheckInService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
