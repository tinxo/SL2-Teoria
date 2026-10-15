using System;
using System.Collections.Generic;
using System.Text;

namespace CheckInApi.Modelos.Exceptions
{
    public class DatosException : Exception
    {
        public DatosException(string mensaje) : base(mensaje) { }
    }

    public class DatosInvalidosException : DatosException
    {
        public string Campo {  get; }
        public string Error {  get; }
        public DatosInvalidosException(string campo, string error)
            : base($"El campo {campo} tiene un error: ")
        {
            Campo = campo;
            Error = error;
        }
    }

}
