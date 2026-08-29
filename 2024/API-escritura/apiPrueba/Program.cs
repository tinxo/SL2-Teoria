using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data Source=app.db");
});

// Agrega la política de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:5202")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

// Aplica la política de CORS
app.UseCors("AllowBlazorApp");

app.MapControllers();

// este endpoint va a responder peticiones de tipo GET
// Estructura: app.MapGet("ruta", () => "respuesta");
app.MapGet("/", () => 
{    
    return $"Hola mundo!";
});

app.MapGet("/{username}", (string username) => 
{    
    return $"Hola, {username}!";
});

app.MapPost("/productos", async (AppDbContext db, Producto producto) => 
{    
    db.Productos.Add(producto);
    await db.SaveChangesAsync();
    return $"Producto {producto.Nombre} creado con éxito!";
});

app.MapGet("/productos", async (AppDbContext db) => 
{    
    var productos = await db.Productos.ToListAsync();
    return productos;
});

app.MapGet("/productos/{id}", async (AppDbContext db, int id) =>
{
    var producto = await db.Productos.FindAsync(id);
    if (producto == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(producto);
});

app.MapDelete("/productos/{id}", async (AppDbContext db, int id) =>
{
    var producto = await db.Productos.FindAsync(id);
    if (producto == null)
    {
        return Results.NotFound();
    }
    db.Productos.Remove(producto);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapPut("/productos/{id}", async (AppDbContext db, int id, Producto producto) =>
{
    var productoActual = await db.Productos.FindAsync(id);
    if (productoActual == null)
    {
        return Results.NotFound();
    }
    productoActual.Nombre = producto.Nombre;
    productoActual.Precio = producto.Precio;
    await db.SaveChangesAsync();
    return Results.Ok($"Producto {productoActual.Nombre} actualizado con éxito!");
});

app.Run();

