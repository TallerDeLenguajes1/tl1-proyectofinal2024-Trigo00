using CuantoSabes;
using ArmarJsonPjsConApi;
using System.Text.Json;
using Personajes;

///////Cargar datos desde Api//////////
await CargadorDatos.CargarDatosPersonajesAsync();

//////Probando el preguntas y respuestas//////////
//MostrarResultados.MostrarResultadosPreguntas();

/////Traigo las lista de personajes cargada del json
string jsonData = File.ReadAllText("Json/Personajes.json");
List<Personaje> personajes = JsonSerializer.Deserialize<List<Personaje>>(jsonData);

//Seleccion de personaje del usuario
Personaje personajeSeleccionado = Seleccion.SeleccionUsuario.SeleccionPersonaje(personajes);

//Eleccion de resto de personajes del torneo
List<Personaje> listaPersonajesTorneo = Seleccion.SeleccionUsuario.MostrarMenuContrincantes(personajes, personajeSeleccionado);


listaPersonajesTorneo.Add(personajeSeleccionado);

Console.WriteLine("\nLos personajes del torneo son:");
foreach (var personaje in listaPersonajesTorneo)
{
    Console.WriteLine(personaje.Datos.Nombre);
}
