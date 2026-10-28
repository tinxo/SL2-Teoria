using CheckInApi.Modelos;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PasajeroController : ControllerBase
{
    // la capa de negocio (servicio)
    private readonly PasajeroService servicio;


    public PasajeroController(PasajeroService servicio)
    {
        this.servicio = servicio;
    }

    [HttpGet]
    public ActionResult<List<Pasajero>> ObtenerTodos()
    {
        var pasajeros = servicio.ObtenerTodos();
        return Ok(pasajeros);
    }

    // [HttpGet("{documento}")] //esto es /api/pasajero/12345678
    // public ActionResult<Pasajero> ObtenerPorDocumento(string documento)
    // {
    //     var pasajero = servicio.ObtenerPorDocumento(documento);
    //     if (pasajero == null)
    //     {
    //         return NotFound($"No se encontró un pasajero con el documento: {documento}");
    //     }
    //     return Ok(pasajero);
    // }

    [HttpGet("{id:int}")] //esto es /api/pasajero/1
    public ActionResult<Pasajero> ObtenerPorId(int id)
    {
        var pasajero = servicio.ObtenerPorId(id);
        if (pasajero == null)
        {
            return NotFound($"No se encontró un pasajero con el ID: {id}");
        }
        return Ok(pasajero);
    }

    // [HttpPost]
    // public ActionResult Agregar([FromBody] PasajeroRequest pasajero)
    // {
    //     var (exito, mensaje) = servicio.Agregar(pasajero);
    //     if (!exito)
    //     {
    //     }
    //     return Ok(pasajero);
    // }

    [HttpPost]
    public ActionResult Agregar([FromBody] PasajeroRequest pasajero)
    {
        var (exito, mensaje) = servicio.Agregar(pasajero);
        if (!exito)
        {
            return BadRequest(mensaje);
        }
        return Ok(mensaje);
    }

    [HttpPut("{id:int}")]
    public ActionResult Actualizar(int id, [FromBody] PasajeroRequest pasajero)
    {
        var (exito, mensaje) = servicio.Actualizar(id, pasajero);
        if (!exito)
        {
            return BadRequest(mensaje);
        }
        return Ok(mensaje);
    }

    // [HttpDelete("{documento}")]
    // public ActionResult Eliminar(string documento)
    // {
    //     var (exito, mensaje) = servicio.Eliminar(documento);
    //     if (!exito)
    //     {
    //         return BadRequest(mensaje); // TODO: modificar a notfound si el pasajero no existe
    //     }
    //     return Ok(mensaje);
    // }

    [HttpDelete("{id:int}")]
    public ActionResult Eliminar(int id)
    {
        var (exito, mensaje) = servicio.Eliminar(id);
        if (!exito)
        {
            return BadRequest(mensaje); // TODO: modificar a notfound si el pasajero no existe
        }
        return Ok(mensaje);
    }


    
}