using CuantoSabes;
using ArmarJsonPjsConApi;
using Personajes;

///////Cargar datos desde Api//////////
await CargadorDatos.CargarDatosPersonajesAsync();

//////Probando el preguntas y respuestas//////////
//MostrarResultados.MostrarResultadosPreguntas();

//Obtengo la lista de peleadores del torneo
List<Personaje> listaPersonajesTorneo = LuchadoresTorneo.Torneo.ObtenerListaPeleadores();

Console.WriteLine("\nLos personajes del torneo son:");
foreach (var personaje in listaPersonajesTorneo)
{
    Console.WriteLine(personaje.Datos.Nombre);
}

Cruces.Peleas.mostrarCruces(listaPersonajesTorneo);
