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
}