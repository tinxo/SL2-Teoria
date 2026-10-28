using System;
using System.Collections.Generic;
using System.Text;
using CheckInApi.Modelos.Exceptions;

namespace CheckInApi.Modelos
{
    public class Pasaje
    {
        private string _tipoVuelo;
        private string _tipoTarifa;
        private string _nroVuelo;

        public Pasaje(string tipoVuelo, string tipoTarifa, string nroVuelo)
        {
            if (tipoVuelo != "N" && tipoVuelo != "I")
            {
                throw new DatosInvalidosException("TipoVuelo", "El tipo de vuelo debe ser 'N' (Nacional) o 'I' (Internacional).");
            }
            if (tipoTarifa != "P" && tipoTarifa != "B" && tipoTarifa != "PE" && tipoTarifa != "F")
            {
                throw new DatosInvalidosException("TipoTarifa", "El tipo de tarifa debe ser 'P' (Primera), 'B' (Business), 'PE' (Premium Economy) o 'F' (Economy).");
            }
            if (string.IsNullOrWhiteSpace(nroVuelo))
            {
                throw new DatosInvalidosException("NroVuelo", "El número de vuelo no puede estar vacío.");
            }
            _tipoVuelo = tipoVuelo.Trim().ToUpper();
            _tipoTarifa = tipoTarifa.Trim().ToUpper();
            _nroVuelo = nroVuelo.Trim().ToUpper();
        }

        public string TipoVuelo
        {
            get { return _tipoVuelo; }
        }

        public string TipoTarifa
        {
            get { return _tipoTarifa; }
        }

        public string NroVuelo
        {
            get { return _nroVuelo; }
        }
    }
}
