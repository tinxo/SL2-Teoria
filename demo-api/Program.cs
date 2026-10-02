// See https://aka.ms/new-console-template for more information

public static class Program
{
    // La idea central de async/await es evitar bloquear el hilo mientras esperamos la respuesta de red.
    // Si la app hiciera una llamada sincrónica, el programa se quedaría "con el tubo en la mano" esperando
    // hasta que la respuesta llegue, y no podría seguir haciendo otra cosa en ese momento.
    // Con await, se "pausa" la ejecución del método y el runtime puede seguir usando ese hilo para otras tareas.
    public static async Task ConsultarAPI()
    {
        // HttpClient es la clase que usamos para hacer peticiones HTTP a una API externa.
        // Se crea una instancia para reutilizar la conexión y centralizar la configuración del cliente.
        HttpClient cliente = new HttpClient();

        Console.WriteLine("Consultando la API de Pokemon...");

        // GET {id or name}/
        // GetAsync devuelve un Task<HttpResponseMessage>.
        // Eso significa: "ya arrancó la petición, pero todavía no tenemos la respuesta final".
        // Con await, el método se pausa hasta que la operación termine, pero sin bloquear el hilo completo.
        HttpResponseMessage response = await cliente.GetAsync("https://pokeapi.co/api/v2/pokemon/ditto");
        HttpResponseMessage response1 = await cliente.GetAsync("https://pokeapi.co/api/v2/pokemon/charmander");
        HttpResponseMessage response2 = await cliente.GetAsync("https://pokeapi.co/api/v2/pokemon/pikhu");

        // La respuesta HTTP incluye el código de estado (200 OK, 404, 500, etc.).
        // Esto nos permite saber si la petición fue exitosa o falló antes de intentar procesar el cuerpo del JSON.
        Console.WriteLine($"Status Code: {response.StatusCode}");

        // Los comentarios de abajo corresponden a una respuesta típica de Pokemon y muestran
        // algunos campos que aparecen en el JSON. Sirven como referencia para entender qué información trae la API.
        // base_experience:113
        // height:6
        // is_default:true
        // order:56
        // weight:75

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Consulta exitosa a la API de Pokemon.");

            // ReadAsStringAsync() también devuelve un Task, por lo que si se usa .Result se bloquea el hilo
            // hasta que el contenido llegue. En un ejemplo más limpio, se preferiría await para no bloquear.
            string jsonDitto = response.Content.ReadAsStringAsync().Result;

            // JsonDocument permite leer el JSON sin crear clases complejas.
            // Parse convierte el texto JSON en un árbol en memoria para poder acceder a sus propiedades por nombre.
            using System.Text.Json.JsonDocument document = System.Text.Json.JsonDocument.Parse(jsonDitto);
            int baseExperience = document.RootElement.GetProperty("base_experience").GetInt32();
            Console.WriteLine($"Content- Valor para base_experience : {baseExperience}");
        }
        else
        {
            Console.WriteLine("Error al consultar la API de Pokemon.");
        }

        if (response1.IsSuccessStatusCode)
        {
            Console.WriteLine("Consulta exitosa a la API de Pokemon.");
            string jsonCharmander = response1.Content.ReadAsStringAsync().Result;
            using System.Text.Json.JsonDocument document1 = System.Text.Json.JsonDocument.Parse(jsonCharmander);
            int baseExperience1 = document1.RootElement.GetProperty("base_experience").GetInt32();
            Console.WriteLine($"Content- Valor para base_experience : {baseExperience1}");
        }
        else
        {
            Console.WriteLine("Error al consultar la API de Pokemon.");
        }

        if (response2.IsSuccessStatusCode)
        {
            Console.WriteLine("Consulta exitosa a la API de Pokemon.");
            string jsonPikhu = response2.Content.ReadAsStringAsync().Result;
            using System.Text.Json.JsonDocument document2 = System.Text.Json.JsonDocument.Parse(jsonPikhu);
            int baseExperience2 = document2.RootElement.GetProperty("base_experience").GetInt32();
            Console.WriteLine($"Content- Valor para base_experience : {baseExperience2}");
        }
        else
        {
            Console.WriteLine("Error al consultar la API de Pokemon.");
        }
    }

    // Main también puede ser async Task. Esto permite usar await directamente en el punto de entrada del programa.
    // Así no se necesita bloquear con .Wait() o .Result al arrancar la app.
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Iniciamos consulta a la API de Pokemon.");
        await ConsultarAPI();
    }
}
