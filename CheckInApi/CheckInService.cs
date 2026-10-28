using CheckInApi.Modelos;
using CheckInApi.Modelos.Exceptions;

public class CheckInService
{
    private readonly IPasajeroRepository repositorio;

    public CheckInService(IPasajeroRepository repositorio)
    {
        this.repositorio = repositorio;
    }

    // Pasaje

    public Pasaje? ObtenerPasaje(int idPasajero)
    {
        Pasajero? pasajero = repositorio.ObtenerPorId(idPasajero);
        if (pasajero == null)
        {
            return null;
        }
        return pasajero.Pasaje;
    }
    
    public (bool exito, string mensaje) AgregarPasaje(int idPasajero, PasajeRequest datos)
    {
        Pasajero? pasajero = repositorio.ObtenerPorId(idPasajero);
        if (pasajero == null)
        {
            return (false, "Error al agregar el pasaje a un pasajero inexistente.");
        }
        Pasaje nuevo;
        try
        {
            nuevo = new Pasaje(
                datos.TipoVuelo ?? string.Empty,
                datos.TipoTarifa ?? string.Empty,
                datos.NroVuelo ?? string.Empty
            );
        }
        catch (DatosInvalidosException)
        {
            // Manejar la excepción según sea necesario, por ejemplo, registrarla o devolver un mensaje de error.
            return (false, "Error al agregar el pasaje al pasajero.");
        }

        pasajero.Pasaje = nuevo;
        bool exito = repositorio.Actualizar(pasajero);
        if (!exito)
        {
            return (false, "Error al actualizar el pasajero con el nuevo pasaje.");
        }
        else
        {
            return (true, "Pasaje agregado correctamente al pasajero.");
        }
    }

}