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

- [x] Agregar un método para modificar una persona existente
- [x] Agregar un método para eliminar una persona del archivo
- [x] Controlar si se quiere agregar contenido o sobrescribir el archivo
- [x] Validar campos antes de guardar
- [ ] Mejorar la serialización para evitar errores si el archivo tiene líneas vacías o formatos inválidos
- [ ] Revisar y limpiar la estructura para que el ejemplo quede más elegante y consistente

## Clase 3 - 16/09/2026

En esta clase se consolidó la lógica de negocio y se mejoró la experiencia de uso del demo, con un enfoque más práctico en la consola.

### Cambios realizados

Se agregaron funcionalidades que permiten trabajar con la lista de personas de forma más realista:

- validación para no duplicar personas por número de documento
- posibilidad de crear el archivo con datos de ejemplo si no existe
- opción de carga manual si el usuario no quiere usar los ejemplos
- consulta de una persona por su `Id`
- actualización de una persona existente
- eliminación de una persona por `Id`
- reescritura completa del archivo cuando se modifica la colección de personas

### Ajustes importantes del código

- `PersonaService.Crear(Persona persona)` ahora devuelve un resultado con `exito` y `mensaje`.
- `PersonaService.Actualizar(Persona persona)` reemplaza la persona encontrada y guarda la lista completa nuevamente.
- `PersonaService.Eliminar(int id)` elimina la persona seleccionada y vuelve a persistir el archivo.
- `PersonaDataController.GuardarPersonas(List<Persona> personas)` reemplaza el contenido del archivo con la lista actualizada.
- `Program` incorpora la lógica para:
  - detectar si el archivo existe
  - decidir si cargar personas de ejemplo o manualmente
  - listar el contenido
  - actualizar y borrar registros desde consola

### Flujo de la aplicación en esta clase

1. Se verifica si el archivo ya existe.
2. Si no existe, se ofrece generar ejemplo o cargar manualmente.
3. El usuario puede crear nuevas personas.
4. Se lista el contenido del archivo.
5. Se actualiza una persona por `Id`.
6. Se elimina otra persona por `Id`.
7. El archivo queda nuevamente persistido con el estado actual.

### Estado final de la demo

> [!SUCCESS]
> La aplicación quedó funcionando como una pequeña práctica completa de CRUD básico sobre un archivo de texto, manteniendo la separación por capas y dejando la base para una próxima mejora de validaciones y limpieza del código.

- [x] Crear personas
- [x] Leer personas
- [x] Actualizar personas
- [x] Eliminar personas
- [x] Validar duplicados por documento
- [x] Manejar archivo existente o inexistente
- [ ] Mejorar la serialización ante líneas vacías o formatos inválidos
- [ ] Dejar la estructura aún más limpia y extensible

