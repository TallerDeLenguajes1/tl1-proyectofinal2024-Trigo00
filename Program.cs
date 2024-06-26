using ArmarJsonPjsConApi;
using Personajes;

//Esto esta listo
await CargadorDatos.CargarDatosPersonajesAsync();
Intro.Presentacion.InicioJuego();
Console.Clear();
Presentacion.Juego.mostrarMensajes();


///////Cargar datos desde Api//////////
// await CargadorDatos.CargarDatosPersonajesAsync();

// //Obtengo la lista de peleadores del torneo
// List<Personaje> listaPersonajesTorneo = LuchadoresTorneo.Torneo.ObtenerListaPeleadores();

// Console.WriteLine("\nLos personajes del torneo son:");

// foreach (var personaje in listaPersonajesTorneo)
// {
//     Console.WriteLine(personaje.Datos.Nombre);
// }

// Cruces.Peleas.mostrarCruces(listaPersonajesTorneo);
