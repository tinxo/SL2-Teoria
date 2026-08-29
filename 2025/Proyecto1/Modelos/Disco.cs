using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Modelos
{
    public class Disco
    {
        // definición de atributos
        private int _id = 0;
        private string _nombre;
        private int _anioLanzamiento;
        private int _cantidadCanciones;
        private int _duracionTotal;
        private string _tipoDisco; //estudio, en vivo, antología, etc

        public Disco(string nombre, int anioLanzamiento, int cantidadCanciones, int duracionTotal, string tipoDisco)
        {
            _nombre = nombre;
            _anioLanzamiento = anioLanzamiento;
            _cantidadCanciones = cantidadCanciones;
            _duracionTotal = duracionTotal;
            _tipoDisco = tipoDisco;
        }

        public string Nombre { get { return _nombre; } }

        public int AnioLanzamiento { get { return _anioLanzamiento; } }

        public int getID()
        {
            return _id;
        }

        public void setID(int id)
        {
            _id = id;
        }

        public override string ToString()
        {
            return $"Nombre: {_nombre}, Año de Lanzamiento: {_anioLanzamiento}, Cantidad de Canciones: {_cantidadCanciones}, Duración Total: {_duracionTotal} minutos, Tipo de Disco: {_tipoDisco}";
        }

        public int CantidadCanciones { get { return _cantidadCanciones; } }
        public int DuracionTotal { get { return _duracionTotal; } } 
        public string TipoDisco { get { return _tipoDisco; } }
    }
}
