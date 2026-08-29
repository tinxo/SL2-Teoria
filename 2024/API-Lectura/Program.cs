class Consulta 
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Empezamos la consulta de la API de DolarAPI");

        string url = "https://dolarapi.com/v1/dolares/oficial";

        //  Hacer la consulta
        await ConsumirApi(url);
        await variasConsultas();
        await consultasConcurrentes();

    }

    public static async Task ConsumirApi(string url)
    {
        //  Crear el cliente
        HttpClient cliente = new HttpClient();

       try
       {
            //  Hacer la consulta
            HttpResponseMessage respuesta = await cliente.GetAsync(url);

            //  Verificar si la consulta fue exitosa
            if (respuesta.IsSuccessStatusCode)
            {
                //  Leer la respuesta
                string contenido = await respuesta.Content.ReadAsStringAsync();

                //  Mostrar la respuesta
                Console.WriteLine(contenido);
            }
            else
            {
                Console.WriteLine("Error en la consulta");
                Console.WriteLine("Status Code: " + respuesta.StatusCode);
                Console.WriteLine("Mensaje: " + respuesta.ReasonPhrase);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error en la consulta: " + ex.Message);
       }
    }

    // Hacemos varias consultas
    public static async Task variasConsultas() 
    {
        HttpClient cliente = new HttpClient();
        string urlBlue = "https://dolarapi.com/v1/dolares/blue";
        string urlOficial = "https://dolarapi.com/v1/dolares/oficial";
        string urlTarjeta = "https://dolarapi.com/v1/dolares/tarjeta";

        Console.WriteLine("Inicio solicitudes asincronas");

        Console.WriteLine("Consulta dolar blue");
        Task<HttpResponseMessage> taskBlue = cliente.GetAsync(urlBlue);
        Console.WriteLine("Consulta dolar oficial");
        Task<HttpResponseMessage> taskOficial = cliente.GetAsync(urlOficial);
        Console.WriteLine("Consulta dolar tarjeta");
        Task<HttpResponseMessage> taskTarjeta = cliente.GetAsync(urlTarjeta);

        HttpResponseMessage respuestaBlue = await taskBlue;
        Console.WriteLine("Respuesta dolar blue: " + respuestaBlue.StatusCode);
        HttpResponseMessage respuestaOficial = await taskOficial;
        Console.WriteLine("Respuesta dolar oficial: " + respuestaOficial.StatusCode);
        HttpResponseMessage respuestaTarjeta = await taskTarjeta;
        Console.WriteLine("Respuesta dolar tarjeta: " + respuestaTarjeta.StatusCode);

        Console.WriteLine("Fin solicitudes asincronas");

    }

    public static async Task consultasConcurrentes() 
    {
        HttpClient cliente = new HttpClient();
        string urlBlue = "https://dolarapi.com/v1/dolares/blue";
        string urlOficial = "https://dolarapi.com/v1/dolares/oficial";
        string urlTarjeta = "https://dolarapi.com/v1/dolares/tarjeta";

        Console.WriteLine("Inicio solicitudes asincronas");

        Console.WriteLine("Consulta dolar blue");
        Task<HttpResponseMessage> taskBlue = cliente.GetAsync(urlBlue);
        Console.WriteLine("Consulta dolar oficial");
        Task<HttpResponseMessage> taskOficial = cliente.GetAsync(urlOficial);
        Console.WriteLine("Consulta dolar tarjeta");
        Task<HttpResponseMessage> taskTarjeta = cliente.GetAsync(urlTarjeta);

        HttpResponseMessage[] respuestas = await Task.WhenAll(taskBlue, taskOficial, taskTarjeta);
        Console.WriteLine("Respuesta dolar blue: " + respuestas[0].StatusCode);
        
        Console.WriteLine("Respuesta dolar oficial: " + respuestas[1].StatusCode);
        
        Console.WriteLine("Respuesta dolar tarjeta: " + respuestas[2].StatusCode);

        Console.WriteLine("Fin solicitudes concurrentes");

    }

}
