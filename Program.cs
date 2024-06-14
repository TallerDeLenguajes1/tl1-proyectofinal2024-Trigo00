using DatosApi;
using FabricaPersonajes;
using Personajes;
using ManejoJson;

List<PersonajeApi> listaPersonajesApi = new List<PersonajeApi>();
List<Personaje> listaPersonajes = new List<Personaje>();
List<Personaje> listaPersonajes2 = new List<Personaje>();

listaPersonajesApi = await InfoApi.traerInformacionApi(listaPersonajesApi);
listaPersonajes = Fabrica.cargarDatos(listaPersonajes, listaPersonajesApi);

PersonajesJson.GuardarPersonajes(listaPersonajes, "Json/personajes.json");

// listaPersonajes2 = PersonajesJson.LeerPersonajes("Json/personajes.json");
// foreach (var personaje in listaPersonajes2)
// {
//     Console.WriteLine("Nombre: " + personaje.Datos.Nombre);
// }
