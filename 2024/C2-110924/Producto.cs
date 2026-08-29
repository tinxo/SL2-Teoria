using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace C2_110924
{
    internal class Producto
    {
        private string _id;
        private string _nombre;
        private int _cantidad;// ESTO SE TIENE QUE IR

        public Producto(string id,  string nombre, int cantidad)
        {
            _id = id;
            _nombre = nombre;
            _cantidad = cantidad;// ESTO SE TIENE QUE IR
        }

        public string ID
        {
            get { return _id; }
            set
            {
                if (value != String.Empty)
                {
                    _id = value;
                }
            }
        }

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (value != String.Empty)
                {
                    _nombre = value;
                }
            }
        }
        
        public int Cantidad // ESTO SE TIENE QUE IR
        {
            get { return _cantidad; }
            set
            {
                if (value > 0)
                {
                    _cantidad = value;
                }
            }
        }
        public override string ToString()
        {
            // Personaliza la representación de la instancia como cadena
            return $"{_nombre} [{_id}] | Stock actual: {_cantidad}"; // Stock actual debería usar la propiedad
        }

        public int StockActual
        {
            get
            {
                int stockActual = 0;
                foreach (var movimiento in this._movimientos)
                {
                    stockActual += movimiento.Cantidad;
                }
                return stockActual;
            }
        }

        public void CargarMovimientos(List<Movimiento> listaMovimientos)
        {
            _movimientos = listaMovimientos;
        }

        // Se define la lista de movimientos de stock
        private List<Movimiento> _movimientos = new List<Movimiento>();

        // Se definen los métodos para agregar y restar stock
        public Movimiento agregarUnidades(string idMovimiento, int cantidadUnidades,
            DateTime fecha)
        {
            // Se genera el objeto para registrar el movimiento
            Movimiento carga = new Movimiento(idMovimiento, cantidadUnidades,
                fecha);
            // Se carga el movimiento en la lista del objeto
            _movimientos.Add(carga);
            return carga;
        }

        public Movimiento restarUnidades(string idMovimiento, int cantidadUnidades,
            DateTime fecha)
        {
            // Se genera el objeto para registrar el movimiento
            Movimiento descarga = new Movimiento(idMovimiento, -cantidadUnidades,
                fecha);
            // Se carga el movimiento en la lista del objeto
            _movimientos.Add(descarga);
            return descarga;
        }
    }
}
