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

        // Create a string array with the lines of text
        string[] lines = { "First line", "Second line", "Third line" };

        // Set a variable to the Documents path.
        string docPath =
          Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        docPath = Path.Combine(docPath, "ejemplo.txt");

        Console.WriteLine($"Ruta de escritura: {docPath}");

        // Write the string array to a new file named "WriteLines.txt".
        using (StreamWriter outputFile = new StreamWriter(docPath))
        {
            foreach (string line in lines)
                outputFile.WriteLine(line);
        }
        Console.WriteLine("Archivo creado con éxito.");

        // Contenido nuevo
        string contenido = "Cuarta línea";
        agregarContenido(docPath, contenido);

        Console.WriteLine("Contenido agregado con éxito.");


        // Ahora probamos leer el contenido completo
        string contenidoArchivo = leerArchivo(docPath);
        Console.WriteLine($"Contenido del archivo: {contenidoArchivo}");
}
}