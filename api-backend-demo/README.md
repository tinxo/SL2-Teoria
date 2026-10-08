# API Backend Demo

## Clase 1 - 23/09/2026

En esta primera etapa se creó un proyecto de backend en ASP.NET Core usando el modelo de aplicación minimal API. La idea principal fue dejar una base funcional para empezar a trabajar con endpoints HTTP y aprender cómo se estructura una API simple en .NET.

> [!NOTE]
> El proyecto fue inicializado como una aplicación web de ASP.NET Core y luego adaptado para probar rutas básicas con respuesta textual.

## Idea principal

Se buscó crear una aplicación mínima que pudiera responder peticiones HTTP desde el navegador o desde herramientas como Postman/curl, y que permitiera ver el flujo típico de una API:

- crear el proyecto
- configurar la aplicación
- definir rutas con `MapGet`
- responder con texto o JSON
- ejecutar la API localmente

## Qué se trabajó en esta clase

### 1. Creación del proyecto

Se generó una app con la estructura base de ASP.NET Core.

Dentro de `Program.cs` se dejó la configuración inicial de la aplicación, incluyendo:

- `WebApplication.CreateBuilder(args)`
- `builder.Services.AddOpenApi()`
- `app.UseHttpsRedirection()`
- `app.Run()`

### 2. Endpoints básicos iniciales

Además de la configuración por defecto, se agregaron dos rutas simples para comprobar que la API funcionaba:

```csharp
app.MapGet("/about", () =>
{
    return "Hello World!";
});

app.MapGet("/about/{name}", (string name) =>
{
    return $"Hello {name}!";
});
```

Con esto se pudo ver cómo una API responde a peticiones con rutas y parámetros.

### 3. Comprensión de la estructura mínima

La aplicación quedó como una base muy simple, pero con la lógica necesaria para entender:

- cómo arranca una app web en .NET
- cómo definir endpoints
- cómo devolver respuestas HTTP básicas
- cómo usar `MapGet` para rutas simples

## Objetivo de la clase

Dejar listo el proyecto base para luego continuar con la parte más importante: construir un CRUD completo de una entidad.

## Estado de esta etapa

- [x] Crear el proyecto ASP.NET Core
- [x] Configurar la app web
- [x] Probar rutas básicas con `MapGet`
- [x] Verificar que la API responde correctamente
- [ ] Agregar persistencia real
- [ ] Separar lógica en capas

---

## Clase 2 - 30/09/2026

En esta segunda parte se avanzó con la lógica de negocio de una clase `Persona` y se implementaron los endpoints básicos de un CRUD en memoria.

> [!IMPORTANT]
> La idea fue dejar una API funcional que permitiera listar, buscar, crear, actualizar y eliminar personas sin necesidad de base de datos todavía.

## Idea principal

Se creó una entidad `Persona` con sus propiedades básicas y luego se armó un pequeño listado en memoria para poder realizar operaciones CRUD desde la API.

## Modelo `Persona`

La clase quedó definida así:

```csharp
class Persona
{
    public Persona(int id, string nombre, string apellido, string nroDocumento)
    {
        Id = id;
        Nombre = nombre;
        Apellido = apellido;
        NroDocumento = nroDocumento;
    }

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string NroDocumento { get; set; }
}
```

Con esto se representó la entidad principal del proyecto: una persona con identificador, nombre, apellido y documento.

## Datos iniciales

Se creó una lista en memoria con varias personas de prueba:

```csharp
List<Persona> personas = new List<Persona>();
Persona persona1 = new Persona(1, "Juan", "Perez", "12345678");
personas.Add(persona1);

Persona persona2 = new Persona(2, "María", "Gómez", "87654321");
personas.Add(persona2);

Persona persona3 = new Persona(3, "Pedro", "López", "11223344");
personas.Add(persona3);
```

Esto permitió probar todas las operaciones sin depender aún de una base de datos o archivo.

## Endpoints implementados

### 1. Obtener todas las personas

```csharp
app.MapGet("/personas", () =>
{
    return Results.Ok(personas);
});
```

Permite listar el contenido completo de la colección.

### 2. Obtener una persona por id

```csharp
app.MapGet("/personas/{id}", (int id) =>
{
    var persona = personas.FirstOrDefault(p => p.Id == id);
    if (persona == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(persona);
});
```

Si la persona no existe, responde con `404 Not Found`.

### 3. Crear una persona

```csharp
app.MapPost("personas", (Persona unaPersona) =>
{
    if (personas.Any(p => p.Id == unaPersona.Id))
    {
        return Results.Conflict($"Ya existe una persona con el id {unaPersona.Id}");
    }

    personas.Add(unaPersona);
    return Results.Created($"/personas/{unaPersona.Id}", unaPersona);
});
```

Se valida que no exista un id repetido y luego se agrega la nueva persona.

### 4. Actualizar una persona

```csharp
app.MapPut("/personas/{id}", (int id, Persona unaPersona) =>
{
    var personaExistente = personas.FirstOrDefault(p => p.Id == id);
    if (personaExistente == null)
    {
        return Results.NotFound();
    }

    personaExistente.Nombre = unaPersona.Nombre;
    personaExistente.Apellido = unaPersona.Apellido;
    personaExistente.NroDocumento = unaPersona.NroDocumento;
    return Results.Ok(personaExistente);
});
```

Se busca la persona por id y se actualizan sus datos.

### 5. Eliminar una persona

```csharp
app.MapDelete("/personas/{id}", (int id) =>
{
    var personaExistente = personas.FirstOrDefault(p => p.Id == id);
    if (personaExistente == null)
    {
        return Results.NotFound();
    }

    personas.Remove(personaExistente);
    return Results.NoContent();
});
```

Si la persona existe, se elimina; si no, se devuelve un `404`.

## Flujo de la API

1. La app inicia con la lista de personas cargada en memoria.
2. El cliente hace una petición GET, POST, PUT o DELETE a la API.
3. La ruta correspondiente responde según el caso.
4. La colección de personas se modifica en memoria durante la ejecución.
5. La aplicación queda lista para seguir ampliándose con persistencia y validaciones.

## Qué aprendimos en esta clase

- cómo crear un pequeño CRUD en una API REST
- cómo usar `MapGet`, `MapPost`, `MapPut` y `MapDelete`
- cómo manejar respuestas `200`, `201`, `204`, `404` y `409`
- cómo trabajar con listas en memoria para simular una base de datos temporal
- cómo estructurar endpoints para una entidad específica

## Estado final de la demo

> [!SUCCESS]
> La API quedó funcionando como una base sólida para seguir aprendiendo backend con ASP.NET Core y CRUD sobre entidades.

- [x] Crear proyecto base de ASP.NET Core
- [x] Definir la entidad `Persona`
- [x] Agregar lista en memoria
- [x] Implementar `GetAll` de personas
- [x] Implementar `GetById`
- [x] Implementar `Create`
- [x] Implementar `Update`
- [x] Implementar `Delete`
- [ ] Persistir datos en base de datos o archivo
- [ ] Agregar validaciones más completas
- [ ] Separar la lógica en servicios y controladores

## Conclusión

Este proyecto representa el primer avance real de una API backend en .NET donde se pasó desde la creación del proyecto hasta la construcción de un CRUD básico para la clase `Persona`. Queda como una base clara para continuar con una segunda etapa donde se agreguen capas de negocio, acceso a datos y una persistencia más robusta.
