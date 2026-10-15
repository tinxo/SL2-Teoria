using CheckInApi.Modelos;
public class PasajeroRepositoryArchivo : IPasajeroRepository
    {
        private readonly string path;

        public PasajeroRepositoryArchivo(string path)
        {
            this.path = path;
        }

        public List<Pasajero> ObtenerTodos()
        {
            List<Pasajero> pasajeros = new List<Pasajero>();

            try
            {
                if (!File.Exists(path))
                {
                    return pasajeros; // Retorna una lista vacía si el archivo no existe
                }

                foreach (var linea in File.ReadLines(path))
                {
                    if (!string.IsNullOrWhiteSpace(linea))
                    {
                        pasajeros.Add(Pasajero.FromString(linea));
                    }
                }
            }
            catch (Exception)
            {
                // Manejo de excepciones, por ejemplo, loguear el error
            }
            return pasajeros;
        }

        public Pasajero? ObtenerPorDocumento(string documento)
        {
            return ObtenerTodos().FirstOrDefault(p => p.Documento == documento);
        }

        public bool Agregar(Pasajero pasajero)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(pasajero.ToString());
                }
                return true;
            }
            catch (Exception)
            {
                // Manejo de excepciones, por ejemplo, loguear el error
                return false;
            }
        }

        public bool Actualizar(Pasajero pasajero)
        {
            var pasajeros = ObtenerTodos();
            var index = pasajeros.FindIndex(p => p.Documento == pasajero.Documento);
            if (index < 0)
            {
                return false; // No se encontró el pasajero a actualizar
            }
            pasajeros[index] = pasajero;
            return GuardarTodos(pasajeros);;
        }

        public bool Eliminar(string documento)
        {
            var pasajeros = ObtenerTodos();
            var pasajeroAEliminar = pasajeros.FirstOrDefault(p => p.Documento == documento);
            if (pasajeroAEliminar == null)
            {
                return false; // No se encontró el pasajero a eliminar
            }
            pasajeros.RemoveAll(p => p.Documento == documento);
            return GuardarTodos(pasajeros);
        }

        private bool GuardarTodos(List<Pasajero> pasajeros)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    foreach (var pasajero in pasajeros)
                    {
                        sw.WriteLine(pasajero.ToString());
                    }
                }
                return true;
            }
            catch (Exception)
            {
                // Manejo de excepciones, por ejemplo, loguear el error
                return false;
            }
        }

    }