using System;
using System.Collections.Generic;
using System.Text;

namespace CheckInApi.Modelos
{
    public class Pasaje
    {
        private string _tipoVuelo;
        private string _tipoTarifa;
        private string _nroVuelo;

        public Pasaje(string tipoVuelo, string tipoTarifa, string nroVuelo)
        {
            _tipoVuelo = tipoVuelo;
            _tipoTarifa = tipoTarifa;
            _nroVuelo = nroVuelo;
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
