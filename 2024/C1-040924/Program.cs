
using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Inicio del ejemplo de persistencia");

        // Se crea una colección de cadenas de caracteres a escribir al archivo
        string[] lineas = ["Hola mundo", "Esto es un ejemplo", "De cómo escribir un archivo"];

        // Se tiene que establecer la ruta a utilizar para guardar
        string appPath = GetAppPath();

        // Se escriben los datos al archivo
        realizarEscritura(lineas, appPath);

        Console.WriteLine("Lectura del archivo generado:");

        // Se lee el archivo generado y se imprime por consola
        realizarLectura(appPath);

    }

    static string GetAppPath()
    {
        Console.WriteLine($"La ubicación en ejecución es: {AppContext.BaseDirectory}");
        return AppContext.BaseDirectory;
    }

    static void realizarEscritura(string[] data, string filePath)
    {
        // Se establece el nombre del archivo a escribir
        string fileName = Path.Combine(filePath, "datos.txt");
        if (!File.Exists(fileName)) 
        {
            // Se crea y escribe el archivo ya que no existe
            // Se genera un StreamWriter para controlar la escritura de datos
            using (StreamWriter archivoSalida = new StreamWriter(fileName))
            {
                // Se recorre la colección de cadenas de caracteres y se escribe al archivo
                foreach (string line in data)
                    archivoSalida.WriteLine(line);
            }
        } 
        else 
        {
            // Se añaden datos al archivo ya que existe, para eso se establece el segundo parámetro
            // using (StreamWriter archivoSalida = new StreamWriter(fileName, true)) 
            using (StreamWriter archivoSalida = new StreamWriter(fileName)) 
            {
                archivoSalida.WriteLine("Nuevos datos en una nueva línea");
            }
        }        
    }

    static void realizarLectura(string filePath)
    {
        // Se establece el nombre del archivo a leer
        string fileName = Path.Combine(filePath, "datos.txt");
        if (File.Exists(fileName)) 
        {
            // Se lee el archivo ya que existe
            // Se genera un StreamReader para controlar la lectura de datos
            using (StreamReader archivoEntrada = new StreamReader(fileName))
            {
                // Se lee el archivo completo
                string contenido = archivoEntrada.ReadToEnd();
                Console.WriteLine(contenido);
            }
        } 
        else 
        {
            Console.WriteLine("El archivo no existe");
        }
    }
}