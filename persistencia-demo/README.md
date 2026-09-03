# Clase 1 - 02/09/2026

Se desarrolló un demo de persistencia básica a un archivo de texto plano.  
El código base es el obtenido desde la documentación de .NET ([escritura](https://learn.microsoft.com/es-es/dotnet/standard/io/how-to-write-text-to-a-file) y [lectura](https://learn.microsoft.com/es-es/dotnet/standard/io/how-to-read-text-from-a-file)) y con algunas adaptaciones básicas.  

> [!NOTE]
> El proyecto incializado es uno de tipo **consola**.

## Idea principal

Generar el código para escribir un archivo de texto plano mediante C#, esto se realiza tanto cuando el archivo está completamente vacío como cuando se debe úncicamente agregar contenido (append).  
También se ha implmentado una operación para hacer la lectura completa del archivo.

> [!IMPORTANT]
> Conceptos clave: polimorfismo, sobrecarga de métodos, clases abstractas, cambios de comportamiento en herencia.

## Pendientes

> [!WARNING]
> Hay partes del código que no fueron finalizadas en clase, podrían tener algún error menor. En la última prueba al menos compilaba.

Se ha incorporado al final una clase **[Persona](Persona.cs)** con un estructura básica y un método ToString que hace un override sobre el método de igual nombre de la clase Object.  
Este será el punto de partida para la **próxima clase** donde se buscará:
- Hacer una escritura de más de una persona al archivo
- Controlar si se quiere agregar más contenido al mismo o modificar lo que estaba previamente
- Hacer una lectura que "reconstruya" los objetos Persona debidamente
- Organizar mejor el código para modularizar la aplicación