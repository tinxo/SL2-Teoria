using System.ComponentModel.DataAnnotations;

namespace CheckInWeb.Models
{
    // Este modelo es para la validación de los datos que ingresa
    // el pasajero en el formulario de check-in.
    public class DatosPasajero
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; } = "";

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string Apellido { get; set; } = "";
        [Required(ErrorMessage = "El documento es obligatorio.")]
        public string Documento { get; set; } = "";
        
        public string PasajeroFrecuente { get; set; } = "";

        public static DatosPasajero Desde(Pasajero pasajero)
        {
            return new DatosPasajero
            {
                Nombre = pasajero.Nombre,
                Apellido = pasajero.Apellido,
                Documento = pasajero.Documento,
                PasajeroFrecuente = pasajero.PasajeroFrecuente
            };
        }



    }
}