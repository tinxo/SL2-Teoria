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

// -----------------------------------------------------------

// Lista en memoria de personas
List<Persona> personas = new List<Persona>();
Persona persona1 = new Persona(1, "Juan", "Perez", "12345678");
personas.Add(persona1);
Persona persona2 = new Persona(2, "María", "Gómez", "87654321");
personas.Add(persona2);
Persona persona3 = new Persona(3, "Pedro", "López", "11223344");
personas.Add(persona3);

// -----------------------------------------------------------

app.MapGet("/about", () =>
{
    return "Hello World!";
});

app.MapGet("/about/{name}", (string name) =>
{
    return $"Hello {name}!";
});

// PERSONAS

// READ, obtener la lista de personas
app.MapGet("/personas", () =>
{
    // codigo de la funcionalidad
    return Results.Ok(personas);
}).WithName("GetPersonas");

// READ, obtener una persona por id
app.MapGet("/personas/{id}", (int id) =>
{
    var persona = personas.FirstOrDefault(p => p.Id == id);
    if (persona == null)
    {
        return Results.NotFound(); //404
    }
    return Results.Ok(persona); // 200
}).WithName("GetPersonaById");

// CREATE, agregar una persona
app.MapPost("personas", (Persona unaPersona) =>
{
    // Validamos que el id no sea repetido
    if (personas.Any(p => p.Id == unaPersona.Id))
    {
        return Results.Conflict($"Ya existe una persona con el id {unaPersona.Id}"); // 409
    }
    personas.Add(unaPersona);
    return Results.Created($"/personas/{unaPersona.Id}", unaPersona); // 201
}).WithName("CreatePersona");

// UPDATE, actualizar una persona
app.MapPut("/personas/{id}", (int id, Persona unaPersona) =>
{
    var personaExistente = personas.FirstOrDefault(p => p.Id == id);
    if (personaExistente == null)
    {
        return Results.NotFound(); // 404
    }
    // Actualizamos los datos de la persona existente
    personaExistente.Nombre = unaPersona.Nombre;
    personaExistente.Apellido = unaPersona.Apellido;
    personaExistente.NroDocumento = unaPersona.NroDocumento;
    return Results.Ok(personaExistente); // 200
}).WithName("UpdatePersona");

// DELETE, eliminar una persona
app.MapDelete("/personas/{id}", (int id) =>
{
    var personaExistente = personas.FirstOrDefault(p => p.Id == id);
    if (personaExistente == null)
    {
        return Results.NotFound(); // 404
    }
    personas.Remove(personaExistente);
    return Results.NoContent(); // 204
    // return Results.Ok(personaExistente); // 200
}).WithName("DeletePersona");

// La llamada a ejecución de la aplicación (no borrar)
app.Run();
