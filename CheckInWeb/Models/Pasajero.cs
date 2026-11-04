// Estos modelos van a servir para reflejar lo que devuelve la API.

namespace CheckInWeb.Models;

public record Pasaje(string TipoVuelo, string TipoTarifa, string NroVuelo)
{
    public string TipoVuelvoTexto => TipoVuelo == "I" ? "Internacional" : "Nacional";
}

public record Pasajero(
    int Id,
    string Nombre,
    string Apellido,
    string Documento,
    string PasajeroFrecuente,
    Pasaje? Pasaje)
{
    public string NombreCompleto => $"{Nombre} {Apellido}";
    public bool EsPasajeroFrecuente => !string.IsNullOrEmpty(PasajeroFrecuente);
}