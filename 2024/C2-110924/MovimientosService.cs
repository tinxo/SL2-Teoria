using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2_110924
{
    internal class MovimientosService
    {

        // Esta clase implementa el controlador de persistencia
        private static string GetAppPath()
        {
            return AppContext.BaseDirectory;
        }

        public static void GuardarMovimiento(Movimiento unMovimiento, string idProducto)
        {
            // Se establece el nombre del archivo a escribir
            string fileName = Path.Combine(GetAppPath(), "movimientos.txt");
            if (!File.Exists(fileName))
            {
                // Se crea y escribe el archivo ya que no existe
                // Se genera un StreamWriter para controlar la escritura de datos
                using (StreamWriter archivoSalida = new StreamWriter(fileName))
                {
                    string datos = $"{unMovimiento.Id};{unMovimiento.Cantidad};{unMovimiento.Fecha};{idProducto}";
                    archivoSalida.WriteLine(datos);
                }
            }
            else
            {
                // Se añaden datos al archivo ya que existe, para eso se establece el segundo parámetro
                using (StreamWriter archivoSalida = new StreamWriter(fileName, true))
                {
                    string datos = $"{unMovimiento.Id};{unMovimiento.Cantidad};{unMovimiento.Fecha};{idProducto}";
                    archivoSalida.WriteLine(datos);
                }
            }
        }
        
        public static List<Movimiento> ObtenerMovimientosProducto(Producto unProducto)
        {
            // Se establece el nombre del archivo a leer
            string fileName = Path.Combine(GetAppPath(), "movimientos.txt");
            if (File.Exists(fileName))
            {
                // Se lee el archivo ya que existe
                List<Movimiento> movimientos = new List<Movimiento>();
                string[] lineas = File.ReadAllLines(fileName);
                foreach (string movimientoComoTexto in lineas)
                {
                    var datos = movimientoComoTexto.Split(";");
                    if (unProducto.ID == datos[datos.Length - 1])
                    {
                        Movimiento unMovimiento = new Movimiento(datos[0], int.Parse(datos[1]), DateTime.Parse(datos[2]));
                        movimientos.Add(unMovimiento);
                    }
                }
                return movimientos;
            }
            else
            {
                // TODO: acá tiene que saltar una excepción
                return null;
            }
        }
    }
}
