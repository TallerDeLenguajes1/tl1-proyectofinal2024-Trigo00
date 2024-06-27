using ArmarJsonPjsConApi;
using Historial;
using Presentacion;

//Esto esta listo
await CargadorDatos.CargarDatosPersonajesAsync();
Intro.Presentacion.InicioJuego();
Console.Clear();
List<HistorialGanadores> listado = new List<HistorialGanadores>();
Juego.mostrarMensajes(listado);


///////Cargar datos desde Api//////////
// await CargadorDatos.CargarDatosPersonajesAsync();

// //Obtengo la lista de peleadores del torneo
// List<Personaje> listaPersonajesTorneo = LuchadoresTorneo.Torneo.ObtenerListaPeleadores();

// Cruces.Peleas.mostrarCruces(listaPersonajesTorneo);