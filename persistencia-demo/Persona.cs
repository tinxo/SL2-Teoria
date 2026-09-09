// Clase Persona

class Persona
{

    public Persona(int id, string nombre, string apellido, string nroDocumento)
    {
        Id = id;
        Nombre = nombre;
        Apellido = apellido;
        NroDocumento = nroDocumento;
    }

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string NroDocumento { get; set; }

    public override string ToString()
    {
        return $"{Id}|{Nombre}|{Apellido}|{NroDocumento}";
    }

    public static Persona FromString(string data)
    {
        var parts = data.Split('|');
        if (parts.Length != 4)
            throw new FormatException("Invalid data format for Persona.");

        return new Persona(
            int.Parse(parts[0]),
            parts[1],
            parts[2],
            parts[3]
        );
    }

}