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
            List<PersonajeApi> listaPersonajesApi1 = new List<PersonajeApi>();
            List<PersonajeApi> listaPersonajesApi2 = new List<PersonajeApi>();
            List<Personaje> listaPersonajes = new List<Personaje>();
            List<Personaje> listaPersonajes2 = new List<Personaje>();

            listaPersonajesApi1 = await InfoApi.traerInformacionApi1(listaPersonajesApi1);
            listaPersonajesApi2 = await InfoApi.traerInformacionApi2(listaPersonajesApi2);
            listaPersonajes = Fabrica.cargarDatos(listaPersonajes, listaPersonajesApi1);
            listaPersonajes2 = Fabrica.cargarDatos(listaPersonajes2, listaPersonajesApi2);

            foreach (var personaje in listaPersonajes2)
            {
                listaPersonajes.Add(personaje);
            }

            // Guarda los personajes en un archivo JSON en el directorio "Json"
            PersonajesJson.GuardarPersonajes(listaPersonajes, "Json/Personajes.json");
        }
    }
}