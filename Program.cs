using ArmarJsonPjsConApi;
using Presentacion;
using Intro;

await CargadorDatos.CargarDatosPersonajesAsync();
PresentacionJuego.Presentacion();
Juego.InicioJuego();