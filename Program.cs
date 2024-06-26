using ArmarJsonPjsConApi;
using Personajes;

//Esto esta listo
/*Intro.Presentacion.InicioJuego();
Console.Clear();
var mensajes = Presentacion.Juego.cargarMensajes();
Presentacion.Juego.mostrarMensajes(mensajes);*/

MenuPrincipal.Menu.MostrarOpciones();


/*///////Cargar datos desde Api//////////
await CargadorDatos.CargarDatosPersonajesAsync();

//Obtengo la lista de peleadores del torneo
List<Personaje> listaPersonajesTorneo = LuchadoresTorneo.Torneo.ObtenerListaPeleadores();

Console.WriteLine("\nLos personajes del torneo son:");

foreach (var personaje in listaPersonajesTorneo)
{
    Console.WriteLine(personaje.Datos.Nombre);
}

Cruces.Peleas.mostrarCruces(listaPersonajesTorneo);*/
