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

    public void Crear(Persona persona)
    {
        dataController.AgregarPersona(persona);
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