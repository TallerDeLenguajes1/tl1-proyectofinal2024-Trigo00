using System.Text.Json;
using Personajes;

namespace LuchadoresTorneo
{
    public class Torneo
    {
        public static List<Personaje> ObtenerListaPeleadores()
        {
            /////Traigo las lista de personajes cargada del json
            string jsonData = File.ReadAllText("Json/Personajes.json");
            List<Personaje> personajes = JsonSerializer.Deserialize<List<Personaje>>(jsonData);

            Presentacion.Juego.SegundaAparicion();

            //Seleccion de personaje del usuario
            Personaje personajeSeleccionado = Seleccion.SeleccionUsuario.SeleccionPersonaje(personajes);

            Presentacion.Juego.TerceraAparicion();

            //Eleccion de resto de personajes del torneo
            List<Personaje> listaPersonajesSeleccionados = Seleccion.SeleccionUsuario.MostrarMenuContrincantes(personajes, personajeSeleccionado);

            //Agrego a la lista de peleadores obtenidos(manual o automaticamente) el personaje a usar por el usuario.
            List<Personaje> listaPersonajesTorneo = [];
            listaPersonajesTorneo.Add(personajeSeleccionado);
            foreach (var personaje in listaPersonajesSeleccionados)
            {
                listaPersonajesTorneo.Add(personaje);
            }

            return listaPersonajesTorneo;
        }
    }
}