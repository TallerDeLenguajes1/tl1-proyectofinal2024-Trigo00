using DatosApi;
using FabricaPersonajes;
using ManejoJson;
using Personajes;

namespace ArmarJsonPjsConApi
{
    public class CargadorDatos
    {
        public static async Task CargarDatosPersonajesAsync()
        {
            List<PersonajeApi> listaPersonajesApi = new List<PersonajeApi>();
            List<Personaje> listaPersonajes = new List<Personaje>();

            listaPersonajesApi = await InfoApi.traerInformacionApi(listaPersonajesApi);
            listaPersonajes = Fabrica.CreacionPersonajes(listaPersonajes, listaPersonajesApi);

<<<<<<< HEAD
            // Guardo los personajes en un archivo JSON en el directorio "Json"
            PersonajesJson.GuardarPersonajes(listaPersonajes, "Json/Personajes.json");
=======
            // Guarda los personajes en un archivo JSON en el directorio "Json"
            PersonajesJson.GenerarJsonPersonajes(listaPersonajes, "Json/Personajes.json");
>>>>>>> Prueba
        }
    }
}