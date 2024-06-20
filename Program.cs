using DatosApi;
using FabricaPersonajes;
using Personajes;
using ManejoJson;

List<PersonajeApi> listaPersonajesApi1 = new List<PersonajeApi>();
List<PersonajeApi> listaPersonajesApi2 = new List<PersonajeApi>();
List<Personaje> listaPersonajes = new List<Personaje>();
List<Personaje> listaPersonajes2 = new List<Personaje>();

listaPersonajesApi1 = await InfoApi.traerInformacionApi1(listaPersonajesApi1);
listaPersonajesApi2 = await InfoApi.traerInformacionApi2(listaPersonajesApi2);
listaPersonajes = Fabrica.cargarDatos(listaPersonajes, listaPersonajesApi1);
listaPersonajes2 = Fabrica.cargarDatos(listaPersonajes2, listaPersonajesApi2);

foreach (var personaje in listaPersonajes2){
    listaPersonajes.Add(personaje);
}

PersonajesJson.GuardarPersonajes(listaPersonajes, "Json/personajes.json");

// foreach (var personaje in listaPersonajes)
// {
//     Console.WriteLine("Nombre: " + personaje.Datos.Nombre);
// }


