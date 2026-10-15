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

    public (bool exito, string mensaje) Agregar(PasajeroRequest pasajero)
    {
        string documento = pasajero.Documento ?? string.Empty;

        if (repositorio.ObtenerPorDocumento(pasajero.Documento) != null)
        {
            // logica de control de duplicados x documento
            return (false, "Ya existe un pasajero con el mismo documento.");
        }

        Pasajero nuevoPasajero;
        try
        {
            nuevoPasajero = new Pasajero(
                pasajero.Nombre ?? string.Empty,
                pasajero.Apellido ?? string.Empty,
                pasajero.Documento ?? string.Empty,
                pasajero.PasajeroFrecuente ?? string.Empty
            );
        }
        catch (DatosInvalidosException ex)
        {
            return (false, $"Error al crear el pasajero: {ex.Message}");
        };
        bool exito = repositorio.Agregar(nuevoPasajero);
        if (!exito)
        {
            return (false, "Error al agregar el pasajero al repositorio.");
        }
        return (true, "Pasajero agregado exitosamente.");
    }

    public (bool exito, string mensaje) Actualizar(PasajeroRequest pasajero)
    {
        string documento = pasajero.Documento ?? string.Empty;
        
        if (repositorio.ObtenerPorDocumento(pasajero.Documento) == null)
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
                pasajero.PasajeroFrecuente ?? string.Empty
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

    public (bool exito, string mensaje) Eliminar(string documento)
    {
        if (repositorio.ObtenerPorDocumento(documento) == null)
        {
            return (false, "No existe un pasajero con el documento proporcionado.");
        }

        bool exito = repositorio.Eliminar(documento);
        if (!exito)
        {
            return (false, "Error al eliminar el pasajero del repositorio.");
        }
        return (true, "Pasajero eliminado exitosamente.");
    }

}
