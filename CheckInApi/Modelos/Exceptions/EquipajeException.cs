using System;
using System.Collections.Generic;
using System.Text;

namespace CheckInApi.Modelos.Exceptions
{
    public class EquipajeException : Exception
    {
        public EquipajeException(string mensaje) : base(mensaje) { }
    }

    public class PesoExcedidoException : EquipajeException
    {
        public double PesoActual {  get; }
        public double PesoMaximo {  get; }
        public int NroItem{  get; }

        public PesoExcedidoException(double pesoActual, double pesoMaximo, int nroItem)
            : base($"Peso excedido: {pesoActual}kg para el item {nroItem} supera el límite de {pesoMaximo}kg para este vuelo.")
        {
            PesoActual = pesoActual;
            PesoMaximo = pesoMaximo;
            NroItem = nroItem;
        }
    }

}
