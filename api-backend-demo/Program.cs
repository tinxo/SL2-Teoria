var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/about", () =>
{
    return "Hello World!";
});

app.MapGet("/about/{name}", (string name) =>
{
    return $"Hello {name}!";
});

// La llamada a ejecución de la aplicación (no borrar)
app.Run();
