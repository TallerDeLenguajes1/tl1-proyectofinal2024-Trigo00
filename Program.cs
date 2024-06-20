using CuantoSabes;
using ArmarJsonPjsConApi;

///////Cargar datos desde Api//////////
await CargadorDatos.CargarDatosPersonajesAsync();

//////Probando el preguntas y respuestas//////////
MostrarResultados.MostrarResultadosPreguntas();
