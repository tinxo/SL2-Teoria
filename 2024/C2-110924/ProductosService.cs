using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2_110924
{
    internal static class ProductosService
    {
        // Esta clase implementa el controlador de persistencia
        private static string GetAppPath()
        {
            return AppContext.BaseDirectory;
        }

        public static void GuardarProducto(Producto unProducto)
        {
            // Se establece el nombre del archivo a escribir
            string fileName = Path.Combine(GetAppPath(), "productos.txt");
            if (!File.Exists(fileName))
            {
                // Se crea y escribe el archivo ya que no existe
                // Se genera un StreamWriter para controlar la escritura de datos
                using (StreamWriter archivoSalida = new StreamWriter(fileName))
                {
                    // TODO: cambiar el uso de Cantidad por StockActual o podría NO guardarse
                    string datos = $"{unProducto.ID};{unProducto.Nombre};{unProducto.Cantidad}";
                    archivoSalida.WriteLine(datos);
                }
            }
            else
            {
                // Se añaden datos al archivo ya que existe, para eso se establece el segundo parámetro
                using (StreamWriter archivoSalida = new StreamWriter(fileName, true))
                {
                    // TODO: cambiar el uso de Cantidad por StockActual o podría NO guardarse
                    string datos = $"{unProducto.ID};{unProducto.Nombre};{unProducto.Cantidad}";
                    archivoSalida.WriteLine(datos);
                }
            }
        }

        public static List<Producto> LeerProductos()
        {
            // Se establece el nombre del archivo a leer
            string fileName = Path.Combine(GetAppPath(), "productos.txt");
            if (File.Exists(fileName))
            {
                // Se lee el archivo ya que existe
                // Se genera un StreamReader para controlar la lectura de datos
                //using (StreamReader archivoEntrada = new StreamReader(fileName))
                //{
                    // Se lee el archivo completo
                //    string contenido = archivoEntrada.ReadLine();
                //    Console.WriteLine(contenido);
                //}
                List<Producto> productos = new List<Producto>();
                string[] lineas = File.ReadAllLines(fileName);
                foreach (string productoComoTexto in lineas) 
                {
                    var datos = productoComoTexto.Split(";");
                    // si se cambia (eliminando) el campo de cantidad se tiene que modificar acá la lectura
                    Producto unProducto = new Producto(datos[0], datos[1], int.Parse(datos[2]));
                    productos.Add(unProducto);  
                }
                return productos;
            }
            else
            {
                // TODO: Generar una exception con este caso
                return null;
            }
        }

    }
}
