using System.ComponentModel.DataAnnotations;

namespace CheckInWeb.Models
{
    public class DatosPasaje
    {
        [Required(ErrorMessage = "Seleccione el tipo de vuelo.")]
        public string TipoVuelo { get; set; } = "";

        [Required(ErrorMessage = "Seleccione el tipo de tarifa.")]
        public string TipoTarifa { get; set; } = "";

        [Required(ErrorMessage = "El número de vuelo es obligatorio.")]
        public string NroVuelo { get; set; } = "";

        public static DatosPasaje Desde(Pasaje pasaje)
        {
            return new DatosPasaje
            {
                TipoVuelo = pasaje.TipoVuelo,
                TipoTarifa = pasaje.TipoTarifa,
                NroVuelo = pasaje.NroVuelo
            };
        }
    }
}