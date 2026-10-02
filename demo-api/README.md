# Demo de consumo de API con async/await

## Clase 1 - 23/09/2026

En esta clase se trabajó con una aplicación de consola en C# para consumir una API pública, en este caso la API de Pokémon, usando `HttpClient` y el patrón `async`/`await`.

La idea principal fue entender cómo hacer una petición HTTP sin bloquear la ejecución del programa, y cómo leer la respuesta JSON para obtener un dato concreto del cuerpo de la respuesta.

> [!NOTE]
> El proyecto inicializado es un ejemplo de consola de .NET y se convirtió en una pequeña práctica de consumo de APIs REST.

## Idea principal

El programa envia tres peticiones a la API de Pokémon para consultar distintos personajes y luego extrae el valor de `base_experience` desde el JSON devuelto.

Se busca mostrar de forma práctica lo siguiente:

- cómo crear una petición HTTP con `HttpClient`
- cómo usar `GetAsync` para consultar una URL
- cómo esperar la respuesta con `await`
- cómo verificar si la petición fue exitosa
- cómo leer el contenido en formato JSON y extraer un valor

## Conceptos trabajados

### 1. `async` y `await`

La clase se enfocó en la idea de que, cuando una aplicación espera la respuesta de una API, no conviene quedar bloqueada en ese momento. En lugar de eso, se usa `await` para indicar: "dejá esta operación en pausa y seguí cuando la respuesta llegue".

Esto permite que el hilo de ejecución quede libre para seguir funcionando mientras la red responde.

### 2. `Task` y `Task<T>`

`GetAsync` no devuelve directamente el contenido final; devuelve un `Task`, que representa una operación en curso que terminará en algún momento.

En el ejemplo, eso se ve así:

```csharp
HttpResponseMessage response = await cliente.GetAsync(url);
```

La palabra `await` hace que el método espere la finalización de esa tarea sin bloquear el hilo completo.

### 3. `HttpClient`

`HttpClient` es la clase que se usa para enviar peticiones HTTP. En este caso se usa para consultar URLs como:

- `https://pokeapi.co/api/v2/pokemon/ditto`
- `https://pokeapi.co/api/v2/pokemon/charmander`
- `https://pokeapi.co/api/v2/pokemon/pikhu`

Cada una de esas peticiones devuelve un `HttpResponseMessage` con:

- el código de estado (200, 404, 500, etc.)
- el contenido de la respuesta
- información sobre si la operación fue exitosa

### 4. Validación de respuesta HTTP

Se revisa la propiedad `IsSuccessStatusCode` para decidir si la respuesta sirve para seguir procesando el contenido.

Si la llamada salió bien, se extrae el JSON y se lee la propiedad `base_experience`.

### 5. Lectura de JSON con `System.Text.Json`

Para procesar el cuerpo devuelto por la API, se usa `JsonDocument` de `System.Text.Json`.

Esto permite convertir el texto JSON en un árbol de datos y acceder a sus propiedades con `GetProperty("base_experience")`.

Un ejemplo del flujo es:

```csharp
string json = response.Content.ReadAsStringAsync().Result;
using System.Text.Json.JsonDocument document = System.Text.Json.JsonDocument.Parse(json);
int baseExperience = document.RootElement.GetProperty("base_experience").GetInt32();
```

## Flujo de la aplicación

1. Se crea una instancia de `HttpClient`.
2. Se ejecutan las llamadas a la API de Pokémon.
3. Cada llamada usa `await` para esperar la respuesta sin bloquear el programa.
4. Se verifica si la operación tuvo éxito.
5. Si tuvo éxito, se obtiene el JSON y se lee `base_experience`.
6. Se imprime el valor por consola para mostrar el resultado.

## Ejemplo del método principal

El programa inicia desde `Main`, y esa función también se declara como `async Task`:

```csharp
public static async Task Main(string[] args)
{
    Console.WriteLine("Iniciamos consulta a la API de Pokemon.");
    await ConsultarAPI();
}
```

Esto permite usar `await` directamente en el punto de entrada del programa y dejar claro que la ejecución puede continuar cuando la operación asincrónica termine.

## Qué se aprendió en esta clase

- cómo consumir una API REST desde una aplicación de consola
- cómo dividir la lógica de consulta y lectura de respuesta
- por qué `async`/`await` es útil cuando hay espera de red
- cómo trabajar con respuestas HTTP y JSON
- cómo extraer datos específicos del contenido de la API

## Pendientes / mejoras sugeridas

> [!TIP]
> Este fue un primer ejemplo práctico, por lo que quedan varias mejoras posibles para hacerlo más limpio y profesional.

- usar `await` también para leer el contenido del body, no solo para la llamada HTTP
- encapsular la lógica en una clase o servicio separado
- manejar errores con `try/catch` y `HttpRequestException`
- evitar repetir código para cada pokemon y reutilizar una función común
- modelar la respuesta con una clase en lugar de usar `JsonDocument`

## Estado final

> [!IMPORTANT]
> La demo quedó funcionando como una base para comprender el uso de APIs, llamadas HTTP y programación asincrónica en .NET, y sirve como introducción a conceptos que se reutilizan en ejemplos más complejos con servicios y aplicaciones web.

- [x] Consumir API pública con `HttpClient`
- [x] Usar `async`/`await` para esperar respuestas
- [x] Leer el JSON devuelto por la API
- [x] Extraer un valor concreto desde el contenido
- [x] Mostrar el resultado por consola
- [ ] Mejorar la reutilización y refactorización del código
- [ ] Manejar errores de red con mayor detalle
- [ ] Separar la lógica de acceso a datos en una clase dedicada
