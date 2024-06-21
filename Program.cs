using CuantoSabes;
using ArmarJsonPjsConApi;
using System.Text.Json;
using Personajes;


///////Cargar datos desde Api//////////
await CargadorDatos.CargarDatosPersonajesAsync();

//////Probando el preguntas y respuestas//////////
//MostrarResultados.MostrarResultadosPreguntas();

///////Seleccion que tiene el usuario del personaje que va a usar//////
/////Traigo las lista de personajes cargada del json
string jsonData = File.ReadAllText("Json/Personajes.json");
List<Personaje> personajes = JsonSerializer.Deserialize<List<Personaje>>(jsonData);
Personaje personajeSeleccionado = Seleccion.SeleccionUsuario.SeleccionPersonaje(personajes);

Seleccion.SeleccionUsuario.MostrarMenuContrincantes(personajes, personajeSeleccionado);
