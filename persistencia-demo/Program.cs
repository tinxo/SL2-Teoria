// Ejemplo de la documentación
using System;
using System.IO;
using System.Collections.Generic;

class Program
{   

    private static List<Persona> CrearEjemplos()
    {
        List<Persona> personas = new List<Persona>
        {
            new Persona(1, "Juan", "Perez", "12345678"),
            new Persona(2, "María", "Gonzalez", "23456781"),
            new Persona(3, "Pedro", "Lopez", "34567812")
        };

        return personas;
    }

    static Persona PedirDatosPersona()
    {
        Console.Write("Id: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Id inválido.");
            return null;
        }

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Apellido: ");
        string apellido = Console.ReadLine();

        Console.Write("Nro. documento: ");
        string nroDocumento = Console.ReadLine();

        return new Persona(id, nombre, apellido, nroDocumento);
    }

    static void Main(string[] args)
    {
        // Setup general de la app.
        string docPath =
          Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        docPath = Path.Combine(docPath, "datosSL2/datos.txt");

        PersonaService personaService = new PersonaService(docPath);

        // Inicio de la aplicación
        Console.WriteLine("Ejemplo de persistencia con archivos");
        
        // Create (controlado por la existencia del archivo)
        if (!File.Exists(docPath))
        {
            // Se brinda la opción de generar el archivo con datos de ejemplo si no existe.
            Console.WriteLine("El archivo no existe. ¿Desea crear un archivo con datos de ejemplo? (s/n)");
            string respuesta = Console.ReadLine();
            if (respuesta.ToLower() == "s")
            {
                // Se cargan los datos de ejemplo usados en clase en el archivo.
                List<Persona> ejemplos = CrearEjemplos();
                foreach (var persona in ejemplos)
                {
                    personaService.Crear(persona);
                }
            }
            else
            {
                // Se hace la carga manual de datos si el usuario no desea usar los ejemplos.
                Console.WriteLine("Debe realizar una carga manual de datos para continuar:");
                Persona persona = PedirDatosPersona();
                if (persona != null)
                {
                    personaService.Crear(persona);
                }
                else
                {
                    Console.WriteLine("No se pudo crear la persona debido a datos inválidos.");
                }
                return;
            }
        }

        Console.WriteLine($"Archivo de datos: {docPath}");

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