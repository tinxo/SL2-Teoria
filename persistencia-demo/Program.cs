// Ejemplo de la documentación
using System;
using System.IO;
using System.Collections.Generic;

class Program
{   

    static void Main(string[] args)
    {
        Console.WriteLine("Ejemplo de persistencia con archivos");

        // Guardamos una persona
        Persona persona1 = new Persona(1, "Juan", "Perez", "12345678");
        Persona persona2 = new Persona(2, "María", "Perez", "23456781");
        Persona persona3 = new Persona(3, "Pedro", "Perez", "34567812");

        // Set a variable to the Documents path.
        string docPath =
          Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        docPath = Path.Combine(docPath, "datosSL2/datos.txt");

        PersonaService personaService = new PersonaService(docPath);

        // Create
        // personaService.Crear(persona1);
        // personaService.Crear(persona2);
        // personaService.Crear(persona3);

        Console.WriteLine($"Se escribieron los datos en: {docPath}");

        // Read
        List<Persona> personas = personaService.ObtenerTodas();
        Console.WriteLine("Personas leídas del archivo:");
        foreach (var persona in personas)
        {
            Console.WriteLine($"Apellido: {persona.Apellido}, Nombre: {persona.Nombre}, Documento: {persona.NroDocumento}");
        }

        //Update
        int idToUpdate = 2;
        Persona personaToUpdate = personaService.ObtenerPorId(idToUpdate);
        if (personaToUpdate != null)
        {
            personaToUpdate.Nombre = "María Actualizada";
            var (resultado, mensaje) = personaService.Actualizar(personaToUpdate);
            if (resultado)
            {
                Console.WriteLine($"Operación correcta. {mensaje}");
            }
            else
            {
                Console.WriteLine($"Error al actualizar: {mensaje}");
            }
        }
        else
        {
            Console.WriteLine($"Persona con ID {idToUpdate} no encontrada.");
        }
        
        // Eliminar
        int idToDelete = 3;
        var (result, message) = personaService.Eliminar(idToDelete);
        if (result)
        {
            Console.WriteLine($"Operación correcta. {message}");
        }
        else
        {
            Console.WriteLine($"Error al eliminar: {message}");
        }

    }
}