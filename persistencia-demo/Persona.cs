// Clase Persona

class Persona
{

    public Persona(int id, string nombre, string apellido, int nroDocumento)
    {
        Id = id;
        Nombre = nombre;
        Apellido = apellido;
        NroDocumento = nroDocumento;
    }

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int NroDocumento { get; set; }

    public override string ToString()
    {
        return $"{Id}|{Nombre}|{Apellido}|{NroDocumento}";
    }

}