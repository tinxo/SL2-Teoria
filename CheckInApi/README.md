# CheckInApi

API REST para administrar pasajeros de una aerolínea, como parte del proyecto #1 de teoría de SL2. Permite consultar, crear, actualizar y eliminar pasajeros. Los datos se guardan en un archivo de texto.

## Requisitos

- .NET SDK 10

## Ejecutar

Desde esta carpeta:

```bash
dotnet run --launch-profile http
```

La API queda disponible en `http://localhost:5129`. En el entorno de desarrollo también se publica el documento OpenAPI en `http://localhost:5129/openapi/v1.json`.

## Endpoints - Clase del 14/10/2026

La ruta base es `/api/Pasajero`.

| Método | Ruta | Descripción |
| --- | --- | --- |
| `GET` | `/api/Pasajero` | Obtiene todos los pasajeros. |
| `GET` | `/api/Pasajero/{documento}` | Busca un pasajero por documento. Devuelve `404` si no existe. |
| `POST` | `/api/Pasajero` | Agrega un pasajero. Devuelve `400` si el documento ya existe o los datos no son válidos. |
| `PUT` | `/api/Pasajero` | Actualiza el pasajero identificado por el documento del cuerpo. Devuelve `400` si no existe o los datos no son válidos. |
| `DELETE` | `/api/Pasajero/{documento}` | Elimina un pasajero. Devuelve `400` si no existe. |

El cuerpo de `POST` y `PUT` es JSON con estos campos:

```json
{
  "nombre": "Ada",
  "apellido": "Lovelace",
  "documento": "12345678",
  "pasajeroFrecuente": "true"
}
```

El nombre no puede estar vacío. Para `PUT`, el documento debe corresponder a un pasajero existente.

## Probar la API desde VS Code

El archivo [CheckInApi.http](./CheckInApi.http) contiene ejemplos para probar los endpoints anteriores. Para ejecutarlos desde VS Code, instala la extensión [REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client), inicia la API con el comando indicado en **Ejecutar** y selecciona **Send Request** sobre la petición que quieras probar. No es necesario usar `curl`.

## Persistencia

El repositorio de archivo guarda los pasajeros en `pasajeros.txt`, ubicado en el directorio de salida de la aplicación (`AppContext.BaseDirectory`). En una ejecución local típica, ese directorio está debajo de `bin/Debug/net10.0/`. El archivo usa una línea por pasajero y `|` como separador entre campos.

## Estado de implementación

- **Pendiente:** corregir el constructor de `Pasajero`. Al crear un pasajero, los valores de `Documento` y `PasajeroFrecuente` quedan nulos porque el constructor no los asigna a las propiedades que expone el modelo.
- **Hecho:** se inyecta `IPasajeroRepository` como dependencia del servicio. Actualmente se utiliza la implementación basada en archivo; esta abstracción permite reemplazarla por una implementación con base de datos cuando sea necesario.
