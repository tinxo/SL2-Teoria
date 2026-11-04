using CheckInWeb.Models;

namespace CheckInWeb.Services;

public interface IPasajeroService
{
    Task<ResultadoApi<List<Pasajero>>> ObtenerTodosAsync();
    Task<ResultadoApi<Pasajero>> ObtenerPorIdAsync(int id);
    Task<ResultadoApi> CrearAsync(DatosPasajero datos);
    Task<ResultadoApi> ModificarAsync(int id, DatosPasajero datos);
    Task<ResultadoApi> EliminarAsync(int id);
    Task<ResultadoApi> GuardarPasajeAsync(int pasajeroId, DatosPasaje datos);
}