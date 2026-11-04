namespace CheckInWeb.Services;

public class ResultadoApi
{
    public bool Exito { get; set; }
    public string Mensaje { get; set; } = "";

    public static ResultadoApi Ok(string mensaje = "")
    {
        return new ResultadoApi { Exito = true, Mensaje = mensaje };
    }

    public static ResultadoApi Falla(string mensaje = "")
    {
        return new ResultadoApi { Exito = false, Mensaje = mensaje };
    }
}

public class ResultadoApi<T> : ResultadoApi
{
    public T? Valor { get; set; }

    public static new ResultadoApi<T> Ok(T valor)
    {
        return new ResultadoApi<T> { Exito = true, Valor = valor };
    }

    public static new ResultadoApi<T> Falla(string mensaje = "")
    {
        return new ResultadoApi<T> { Exito = false, Mensaje = mensaje };
    }
}