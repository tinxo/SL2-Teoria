/*
 * Capa de persistencia de datos para la clase Persona.
 * Clase para manejar la persistencia de datos de personas en un archivo de texto.
 * Permite agregar nuevas personas y leer todas las personas almacenadas.
 */

class PersonaDataController
{
    private string filePath;

    public PersonaDataController(string filePath)
    {
        this.filePath = filePath;
    }

    public bool AgregarPersona(Persona persona)
    {
        // Se mejora la lógica para manejar excepciones y asegurar que el archivo se cierre correctamente.
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filePath, true))
            {
                outputFile.WriteLine(persona.ToString());
            }
            return true;
        }
        catch (IOException)
        {
            return false;
        }
    }

    public List<Persona> LeerPersonas()
    {
        List<Persona> personas = new List<Persona>();

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Persona persona = Persona.FromString(line);
                    personas.Add(persona);
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }

        return personas;
    }

    public void GuardarPersonas(List<Persona> personas)
    {
        using (StreamWriter outputFile = new StreamWriter(filePath, false))
        {
            foreach (var persona in personas)
            {
                outputFile.WriteLine(persona.ToString());
            }
        }
    }

}