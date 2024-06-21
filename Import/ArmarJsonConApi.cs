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

            listaPersonajesApi = await InfoApi.traerInformacionApi1(listaPersonajesApi);
            listaPersonajes = Fabrica.cargarDatos(listaPersonajes, listaPersonajesApi);

            // Guarda los personajes en un archivo JSON en el directorio "Json"
            PersonajesJson.GuardarPersonajes(listaPersonajes, "Json/Personajes.json");
        }
    }
}