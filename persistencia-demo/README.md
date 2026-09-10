# Demo sobre persistencia

## Clase 1 - 02/09/2026

Se desarrolló un demo de persistencia básica a un archivo de texto plano.  
El código base es el obtenido desde la documentación de .NET ([escritura](https://learn.microsoft.com/es-es/dotnet/standard/io/how-to-write-text-to-a-file) y [lectura](https://learn.microsoft.com/es-es/dotnet/standard/io/how-to-read-text-from-a-file)) y con algunas adaptaciones básicas.  

> [!NOTE]
> El proyecto inicializado es uno de tipo **consola**.

## Idea principal

Generar el código para escribir un archivo de texto plano mediante C#, esto se realiza tanto cuando el archivo está completamente vacío como cuando se debe únicamente agregar contenido (append).  
También se ha implementado una operación para hacer la lectura completa del archivo.

> [!IMPORTANT]
> Conceptos clave: polimorfismo, sobrecarga de métodos, clases abstractas, cambios de comportamiento en herencia.

## Pendientes

> [!WARNING]
> Hay partes del código que no fueron finalizadas en clase, podrían tener algún error menor. En la última prueba al menos compilaba.

Se incorporó al final una clase **[Persona](Persona.cs)** con una estructura básica y un método `ToString()` que hace un override sobre el método de igual nombre de la clase `Object`.  
Ese punto fue la base para la siguiente etapa, donde se buscó resolver la parte de persistencia más organizada y modular.

- [x] Escribir un archivo de texto plano desde una aplicación de consola
- [x] Leer el contenido completo de un archivo
- [x] Crear una clase `Persona` con propiedades básicas
- [x] Implementar `ToString()` para serializar la entidad
- [x] Implementar `FromString()` para reconstruir la entidad al leer
- [x] Escribir más de una persona en el mismo archivo
- [x] Hacer lectura que reconstruya correctamente objetos `Persona`
- [x] Organizar mejor el código para modularizar la aplicación

## Clase 2 - 09/09/2026

En esta clase se comenzó a separar responsabilidades en capas para darle una pequeña estructura arquitectónica al ejemplo, manteniendo el enfoque de que sigue siendo una demo simple.

### Objetivo de la clase

Probar una primera versión de arquitectura básica:
- capa de dominio: la entidad `Persona`
- capa de servicio: `PersonaService`
- capa de persistencia: `PersonaDataController`
- capa de presentación: `Program`

### Cambios principales

Se reorganizó la lógica para que el programa principal no tenga toda la responsabilidad de guardar y leer archivos.  
Ahora la aplicación queda dividida en una entidad y dos componentes de acceso a datos/negocio:

- `Persona` contiene los datos básicos y la lógica de serialización de la instancia.
- `PersonaDataController` se encarga de la persistencia real en el archivo.
- `PersonaService` actúa como servicio intermedio para la lógica de negocio.
- `Program` solo crea instancias, llama al servicio y muestra resultados por consola.

### Métodos agregados en esta clase

Se implementó la parte de creación y lectura de personas:

- `PersonaService.Crear(Persona persona)`
- `PersonaService.ObtenerTodas()`
- `PersonaDataController.AgregarPersona(Persona persona)`
- `PersonaDataController.LeerPersonas()`

Además, se deja planteado el uso de `ToString()` y `FromString()` para persistir y reconstruir cada persona a partir de una línea del archivo.

### Ejemplo de flujo

1. Se crean varias instancias de `Persona`.
2. El `Program` las envía al `PersonaService`.
3. El servicio delega al `PersonaDataController`.
4. El controlador escribe cada persona en el archivo con una línea por registro.
5. Luego se lee el archivo completo y cada línea se transforma nuevamente en un objeto `Persona`.

### Pendientes de esta etapa

> [!TIP]
> La idea de esta clase fue dejar una base ordenada para seguir avanzando, pero quedan tareas pendientes.

- [ ] Agregar un método para modificar una persona existente
- [ ] Agregar un método para eliminar una persona del archivo
- [ ] Controlar si se quiere agregar contenido o sobrescribir el archivo
- [ ] Validar campos antes de guardar
- [ ] Mejorar la serialización para evitar errores si el archivo tiene líneas vacías o formatos inválidos
- [ ] Revisar y limpiar la estructura para que el ejemplo quede más elegante y consistente

