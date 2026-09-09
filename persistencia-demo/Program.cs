// Ejemplo de la documentación
using System;
using System.IO;

class Program
{

    static string leerArchivo(string path)
    {
        try
        {
            // Open the text file using a stream reader.
            using StreamReader reader = new(path);

            // Read the stream as a string.
            string text = reader.ReadToEnd();

            // Devuelve el contenido del archivo
            return text;
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
        return string.Empty;
    }

    static void agregarContenido(string path, string contenido)
    {
        // Se instancia el writer para agregar contenido al archivo
        using (StreamWriter outputFile = new StreamWriter(path, true))
        {
            outputFile.WriteLine(contenido);
        }
    }

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
        personaService.Crear(persona1);
        personaService.Crear(persona2);
        personaService.Crear(persona3);

        Console.WriteLine($"Se escribieron los datos en: {docPath}");

        // Read
        List<Persona> personas = personaService.ObtenerTodas();
        Console.WriteLine("Personas leídas del archivo:");
        foreach (var persona in personas)
        {
            Console.WriteLine($"Apellido: {persona.Apellido}, Nombre: {persona.Nombre}, Documento: {persona.NroDocumento}");
        }

        // TODO: acá viene la parte donde me lista las personas cargadas y me permite elegir una para modificarla
        //      esa instancia se modifica (algún campo, excepto el ID) y se vuelve a escribir el archivo

        // TODO: se hace lo mismo pero para eliminar una persona del archivo

    }
}