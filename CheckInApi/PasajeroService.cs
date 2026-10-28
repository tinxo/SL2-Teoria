using CheckInApi.Modelos;
using CheckInApi.Modelos.Exceptions;

public class PasajeroService
{
    private readonly IPasajeroRepository repositorio;

    public PasajeroService(IPasajeroRepository repositorio)
    {
        // este constructor inyecta la dependencia del repositorio de pasajeros
        this.repositorio = repositorio;
    }

    public List<Pasajero> ObtenerTodos()
    {
        return repositorio.ObtenerTodos();
    }

    public Pasajero? ObtenerPorDocumento(string documento)
    {
        return repositorio.ObtenerPorDocumento(documento);
    }

    public Pasajero? ObtenerPorId(int id)
    {
        return repositorio.ObtenerPorId(id);
    }

    public (bool exito, string mensaje) Agregar(PasajeroRequest pasajero)
    {
        string documento = pasajero.Documento ?? string.Empty;
        // Se valida que el documento no esté vacío al crear
        Pasajero nuevoPasajero;
        try
        {
            nuevoPasajero = new Pasajero(
                pasajero.Nombre ?? string.Empty,
                pasajero.Apellido ?? string.Empty,
                documento,
                pasajero.PasajeroFrecuente ?? string.Empty
            );
        }
        catch (DatosInvalidosException ex)
        {
            return (false, $"Error al crear el pasajero: {ex.Message}");
        };

        // Validación para evitar duplicados por documento
        if (repositorio.ObtenerPorDocumento(documento) != null)
        {
            // logica de control de duplicados x documento
            return (false, "Ya existe un pasajero con el mismo documento.");
        }

        bool exito = repositorio.Agregar(nuevoPasajero);
        if (!exito)
        {
            return (false, "Error al agregar el pasajero al repositorio.");
        }
        return (true, "Pasajero agregado exitosamente.");
    }

    public (bool exito, string mensaje) Actualizar(int Id, PasajeroRequest pasajero)
    {
        string documento = pasajero.Documento ?? string.Empty;
        Pasajero? pasajeroExistente = repositorio.ObtenerPorDocumento(documento);
        if (pasajeroExistente == null && pasajeroExistente?.Id != Id)
        {
            return (false, "No existe un pasajero con el documento proporcionado.");
        }

        Pasajero pasajeroActualizado;
        try
        {
            pasajeroActualizado = new Pasajero(
                pasajero.Nombre ?? string.Empty,
                pasajero.Apellido ?? string.Empty,
                pasajero.Documento ?? string.Empty,
                pasajero.PasajeroFrecuente ?? string.Empty,
                Id
            );
        }
        catch (DatosInvalidosException ex)
        {
            return (false, $"Error al actualizar el pasajero: {ex.Message}");
        }
        bool exito = repositorio.Actualizar(pasajeroActualizado);
        if (!exito)
        {
            return (false, "Error al actualizar el pasajero en el repositorio.");
        }
        return (true, "Pasajero actualizado exitosamente.");
    }

    public (bool exito, string mensaje) Eliminar(int id)
    {
        if (repositorio.ObtenerPorId(id) == null)
        {
            return (false, "No existe un pasajero con el ID proporcionado.");
        }

        bool exito = repositorio.Eliminar(id);
        if (!exito)
        {
            return (false, "Error al eliminar el pasajero del repositorio.");
        }
        return (true, "Pasajero eliminado exitosamente.");
    }

}
