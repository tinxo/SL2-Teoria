using Proyecto1.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Proyecto1
{
    internal static class PersistenciaArtistas
    {
        private static string GetPath()
        {
            return AppContext.BaseDirectory;
        }

        public static void GuardarArtista(Artista unArtista)
        {
            string fullPath = Path.Combine(GetPath(), "datos_artistas.txt");
            // UltimoIdArtista();
            // unArtista.setID(GenerarIdArtista());
            if (!File.Exists(fullPath))
            {
                // El archivo no existe
                using (StreamWriter outputFile = new StreamWriter(fullPath))
                {
                    string datos = $"{unArtista.getID()}|{unArtista.NombreCompleto}|{unArtista.NombreArtistico}|{unArtista.getAnioInicio()}|{unArtista.Nacionalidad}|{unArtista.Discografica}";
                    outputFile.WriteLine(datos);
                }
                //MessageBox.Show("Archivo creado y datos guardados correctamente.");
            }
            else
            {
                // El archivo ya existe, agregamos el mismo contenido
                using (StreamWriter outputFile = new StreamWriter(fullPath, true))
                {
                    // Escribir el contenido del archivo línea a línea
                    string datos = $"{unArtista.getID()}|{unArtista.NombreCompleto}|{unArtista.NombreArtistico}|{unArtista.getAnioInicio()}|{unArtista.Nacionalidad}|{unArtista.Discografica}";
                    outputFile.WriteLine(datos);
                }
                //MessageBox.Show("Archivo actualizado correctamente.");
            }
        }

        public static List<Artista> LeerArtistas()
        {
            string fullPath = Path.Combine(GetPath(), "datos_artistas.txt");
            List<Artista> resultados = new List<Artista>();
            if (File.Exists(fullPath))
            {
                string[] lineas = File.ReadAllLines(fullPath);
                foreach (string line in lineas)
                {
                    var datos = line.Split('|');
                    Artista unArtista = new Artista(datos[1], datos[2]);
                    unArtista.setID(int.Parse(datos[0]));
                    unArtista.setAnioInicio(int.Parse(datos[3]));
                    unArtista.Nacionalidad = datos[4];
                    unArtista.Discografica = datos[5];
                    resultados.Add(unArtista);
                }
                // traer todos los discos
                LeerDiscosArtistas(resultados);
                return resultados;
            }
            else
            {
                // El archivo no existe
                return resultados;
            }
        }

        public static void GuardarDisco(Disco unDisco, int idArtista)
        {
            string fullPath = Path.Combine(GetPath(), "datos_discos.txt");
            // UltimoIdDisco();
            // unDisco.setID(GenerarIdDisco());
            if (!File.Exists(fullPath))
            {
                // archivo nuevo
                using (StreamWriter outputFile = new StreamWriter(fullPath))
                {
                    string datos = $"{unDisco.getID()}|{unDisco.Nombre}|{unDisco.AnioLanzamiento}|{unDisco.CantidadCanciones}|{unDisco.DuracionTotal}|{unDisco.TipoDisco}|{idArtista}";
                    outputFile.WriteLine(datos);
                }
            }
            else
            {
                using (StreamWriter outputFile = new StreamWriter(fullPath, true))
                {
                    string datos = $"{unDisco.getID()}|{unDisco.Nombre}|{unDisco.AnioLanzamiento}|{unDisco.CantidadCanciones}|{unDisco.DuracionTotal}|{unDisco.TipoDisco}|{idArtista}";
                    outputFile.WriteLine(datos);
                }
            }
        }

        public static List<Artista> LeerDiscosArtistas(List<Artista> listaArtistas)
        {
            string fullPath = Path.Combine(GetPath(), "datos_discos.txt");
            List<Disco> resultados = new List<Disco>();
            if (File.Exists(fullPath))
            {
                string[] lineas = File.ReadAllLines(fullPath);
                foreach (string line in lineas)
                {
                    var datos = line.Split('|');
                    // string datos = $"{unDisco.getID()}|{unDisco.Nombre}|{unDisco.AnioLanzamiento}|{unDisco.CantidadCanciones}|{unDisco.DuracionTotal}|{unDisco.TipoDisco}|{idArtista}";
                    Disco unDisco = new Disco(datos[1], int.Parse(datos[2]), int.Parse(datos[3]), int.Parse(datos[4]), datos[5]);
                    unDisco.setID(int.Parse(datos[0]));
                    int idArtista = int.Parse(datos[6]);
                    resultados.Add(unDisco);
                    Artista artistaAsociado = listaArtistas.FirstOrDefault(a => a.getID() == idArtista);
                    artistaAsociado?.agregarDisco(unDisco);
                }
                return listaArtistas;
            }
            else
            {
                return listaArtistas;
            }
        }

        public static List<Disco> LeerDiscos()
        {
            string fullPath = Path.Combine(GetPath(), "datos_discos.txt");
            List<Disco> resultados = new List<Disco>();
            if (File.Exists(fullPath))
            {
                List<Artista> listaArtistas = LeerArtistas();
                string[] lineas = File.ReadAllLines(fullPath);
                foreach (string line in lineas)
                {
                    var datos = line.Split('|');
                    // string datos = $"{unDisco.getID()}|{unDisco.Nombre}|{unDisco.AnioLanzamiento}|{unDisco.CantidadCanciones}|{unDisco.DuracionTotal}|{unDisco.TipoDisco}|{idArtista}";
                    Disco unDisco = new Disco(datos[1], int.Parse(datos[2]), int.Parse(datos[3]), int.Parse(datos[4]), datos[5]);
                    unDisco.setID(int.Parse(datos[0]));
                    int idArtista = int.Parse(datos[6]);
                    resultados.Add(unDisco);
                    Artista artistaAsociado = listaArtistas.FirstOrDefault(a => a.getID() == idArtista);
                    artistaAsociado?.agregarDisco(unDisco);
                }
                return resultados;
            }
            else
            {
                return resultados;
            }
        }
    }
}
