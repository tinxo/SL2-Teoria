using System.Text.Json;

class DolarResponse
{
    public decimal venta { get; set; }
    public decimal compra { get; set; }
    public string casa { get; set; }
    public string nombre { get; set; }
    public DateTime fechaActualizacion { get; set; }
}

class ConsultaApi
{

public static async Task ConsultaDolarApiAsync()
    {
        string urlBlue = "https://dolarapi.com/v1/dolares/blue";
        string urlOficial = "https://dolarapi.com/v1/dolares/oficial";
        string urlCripto = "https://dolarapi.com/v1/dolares/cripto";

        HttpClient client = new HttpClient();

        try
        {
            Console.WriteLine("Varias consultas");

            Console.WriteLine("Consulta Blue");
            Task<HttpResponseMessage> taskBlue = client.GetAsync(urlBlue);
            Console.WriteLine("Consulta Oficial");
            Task<HttpResponseMessage> taskOficial = client.GetAsync(urlOficial);
            Console.WriteLine("Consulta Cripto");
            Task<HttpResponseMessage> taskCripto = client.GetAsync(urlCripto);

            HttpResponseMessage responseOficial = await taskOficial;
            Console.WriteLine("Escritura async Oficial");
            string respuesta = await responseOficial.Content.ReadAsStringAsync();
            DolarResponse dolarOficial = JsonSerializer.Deserialize<DolarResponse>(respuesta);
            Console.WriteLine($"Precio de venta: ${dolarOficial.venta}");

            HttpResponseMessage responseBlue = await taskBlue;
            Console.WriteLine("Escritura async Blue");
            Console.WriteLine(await responseBlue.Content.ReadAsStringAsync());

            HttpResponseMessage responseCripto = await taskCripto;
            Console.WriteLine("Escritura async Cripto");
            Console.WriteLine(await responseCripto.Content.ReadAsStringAsync());
            
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
        }

    }

    public static void ConsultaDolarApi()
    {
        string url = "https://dolarapi.com/v1/dolares/blue";

        HttpClient client = new HttpClient();

        try
        {
            Console.WriteLine("Antes de hacer la consulta");
            HttpResponseMessage response = client.GetAsync(url).Result;
            Console.WriteLine("Escritura no async");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(responseBody);
            }
            else
            {
                Console.WriteLine($"Error en la consulta a la API:");
                Console.WriteLine($"Status Code: {response.StatusCode}");
                Console.WriteLine($"Mensaje: {response.ReasonPhrase}");
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
        }

    }

    public static async Task Main(string[] args)
    {
        Console.WriteLine("Vamos a hacer una consulta a la API de DolarAPI.com");
        await ConsultaDolarApiAsync();
        Console.WriteLine("Consulta finalizada.");
    }
}