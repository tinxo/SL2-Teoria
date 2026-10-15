using CheckInApi.Modelos;

public interface IPasajeroRepository
    {
        List<Pasajero> ObtenerTodos();
        Pasajero? ObtenerPorDocumento(string documento);
        bool Agregar(Pasajero pasajero);
        bool Actualizar(Pasajero pasajero);
        bool Eliminar(string documento);
    }