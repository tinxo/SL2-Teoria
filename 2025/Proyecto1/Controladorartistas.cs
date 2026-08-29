using Proyecto1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
//using Proyecto1.PersistenciaArtistas;

namespace Proyecto1
{
    internal static class ControladorArtistas
    {
        static List<Artista> _listaArtistas = new List<Artista>();

        public static List<Artista> getListaArtistas()
        {
            return _listaArtistas;
        }

        static private int getMaxIDArtistas()
        {
            if (_listaArtistas.Any())
            {
                return _listaArtistas.Max(a => a.getID());
            }
            else
            {
                return 0;
            }
        }

        static private int getMaxIDDiscos()
        {
            int maxIDDiscos = -1;
            foreach (Artista unArtista in _listaArtistas)
            {
                if (!unArtista.getDiscos().Any())
                {
                    continue;
                } 
                else
                {
                    if (unArtista.getDiscos().Max(d => d.getID()) > maxIDDiscos)
                    {
                        maxIDDiscos = unArtista.getDiscos().Max(d => d.getID());
                    }   
                } 
            }
            return maxIDDiscos;
        }   

        public static void GuardarArtista(string nombreCompleto, string nombreArtistico, int anioInicio, string nacionalidad, string discografica)
        {
            Artista unArtista = new(nombreCompleto, nombreArtistico);
            unArtista.setAnioInicio(anioInicio);
            unArtista.Nacionalidad = nacionalidad;
            unArtista.Discografica = discografica;
            int idartista = getMaxIDArtistas() + 1;
            unArtista.setID(idartista);
            PersistenciaArtistas.GuardarArtista(unArtista);
        }

        public static List<Artista> ObternerArtistas()
        {
            //List<Artista> listado = new List<Artista>();
            _listaArtistas = PersistenciaArtistas.LeerArtistas();
            // Si esto es null no existe el archivo
            if (_listaArtistas.Count > 0 )
            {
                return _listaArtistas;
            }
            else
            {
                throw new Exception("No hay artistas cargados");
            }
        }

        public static void GuardarDisco(Artista unArtista, string nombre, int anioPublicacion, int cantidadCanciones, int duracionTotal, string tipoDisco)
        {
            Disco discoNuevo = new Disco(nombre, anioPublicacion, cantidadCanciones, duracionTotal, tipoDisco);
            int idDisco = getMaxIDDiscos() + 1;
            discoNuevo.setID(idDisco);
            unArtista.agregarDisco(discoNuevo);
            PersistenciaArtistas.GuardarDisco(discoNuevo, unArtista.getID());
        }

    }
}
