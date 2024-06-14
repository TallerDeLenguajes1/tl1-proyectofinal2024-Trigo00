using DatosApi;
using FabricaPersonajes;
using Personajes;
using ManejoJson;

List<PersonajeApi> listaPersonajesApi = new List<PersonajeApi>();
List<Personaje> listaPersonajes = new List<Personaje>();

listaPersonajesApi = await InfoApi.TraerInformacionApi(listaPersonajesApi);
listaPersonajes = Fabrica.cargarDatos(listaPersonajes, listaPersonajesApi);

Json.convertirEnJson(listaPersonajes, "Json/personajes.json");

