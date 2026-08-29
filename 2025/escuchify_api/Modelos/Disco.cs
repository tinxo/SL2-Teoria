namespace escuchify_api.Modelos;

public class Disco
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public int AnioLanzamiento { get; set; }
    public string TipoDisco { get; set; }

    // Canciones vinculadas
    public List<Cancion> Canciones { get; set; } = new List<Cancion>();

    public Disco(int id, string titulo, int anioLanzamiento, string tipoDisco)
    {
        Id = id;
        Titulo = titulo;
        AnioLanzamiento = anioLanzamiento;
        TipoDisco = tipoDisco;
    }

    public override string ToString()
    {
        return $"Nombre: {Titulo}, Año de Lanzamiento: {AnioLanzamiento}, Tipo de Disco: {TipoDisco}";
    }

}


