/*
 * Capa de negocio para la entidad Persona.
 * Clase de servicio para manejar operaciones relacionadas con la entidad Persona.
 * Esta clase actúa como una capa intermedia entre la lógica de negocio y la persistencia de datos.
 */

class PersonaService
{

    private PersonaDataController dataController;

    public PersonaService(string filePath)
    {
        dataController = new PersonaDataController(filePath);
    }

    public (bool exito, string mensaje) Crear(Persona persona)
    {
        // Se verifica si ya existe una persona con el mismo número de documento antes de agregarla.
        List<Persona> personas = dataController.LeerPersonas();

        if (personas.Any(p => p.NroDocumento == persona.NroDocumento))
            return (false, "Ya existe una persona con ese número de documento.");

        // Se hace la llamada al método AgregarPersona del controlador de datos para persistir la nueva persona.
        bool exito = dataController.AgregarPersona(persona);
        // Se suma el control de resultados de la capa de persistencia para informar al usuario si la operación fue exitosa o no.
        if (!exito)
            return (false, "No se pudo escribir en el archivo.");
        else
            return (true, $"Persona con ID {persona.Id} creada.");
    }

    public List<Persona> ObtenerTodas()
    {
        return dataController.LeerPersonas();
    }

    public Persona ObtenerPorId(int id)
    {
        var personas = dataController.LeerPersonas();
        return personas.Find(p => p.Id == id);
    }

    public (bool exito, string mensaje) Actualizar(Persona persona)
    {
        var personas = dataController.LeerPersonas();
        var index = personas.FindIndex(p => p.Id == persona.Id);
        if (index != -1)
        {
            personas[index] = persona;
            dataController.GuardarPersonas(personas);
            return (true, $"Persona con ID {persona.Id} actualizada.");
        }
        else
        {
            return (false, $"Persona con ID {persona.Id} no actualizada.");
        }
    }

    public (bool exito, string mensaje) Eliminar(int id)
    {
        var personas = dataController.LeerPersonas();
        var personaAEliminar = personas.Find(p => p.Id == id);
        if (personaAEliminar != null)
        {
            personas.Remove(personaAEliminar);
            dataController.GuardarPersonas(personas);
            return (true, $"Persona con ID {id} eliminada.");
        }
        else
        {
            return (false, $"Persona con ID {id} no encontrada.");
        }
    }

}