namespace escuchify_api.Modelos;

public class Cancion
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Duracion { get; set; }
    public string Genero { get; set; }


    public Cancion(int id, string titulo, string duracion, string genero)
    {
        Id = id;
        Titulo = titulo;
        Duracion = duracion;
        Genero = genero;
    }

    public override string ToString()
    {
        return $"Título: {Titulo}, Duración: {Duracion}, Género: {Genero}";
    }

    // FK para Disco
    public int DiscoId { get; set; }
    public Disco? Disco { get; set; } // Navegación hacia Disco



}