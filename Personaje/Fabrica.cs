using DatosApi;
using Personajes;

namespace FabricaPersonajes
{
    public class Fabrica
    {

        public static List<Personaje> CreacionPersonajes(List<Personaje> listaPersonajes, List<PersonajeApi> personajesApi)
        {

            foreach (var personaje in personajesApi)
            {
                Personaje nuevoPersonaje = CreacionPersonaje(personaje);
                listaPersonajes.Add(nuevoPersonaje);
            }
            return listaPersonajes;
        }

        private static Random random = new Random();

        private static Personaje CreacionPersonaje(PersonajeApi personaje)
        {
            Personaje nuevoPersonaje = new Personaje();

            //Datos
            nuevoPersonaje.Datos.Nombre = personaje.Name;
            nuevoPersonaje.Datos.Raza = personaje.Race;
            switch (personaje.Gender)
            {
                case "Male":
                    nuevoPersonaje.Datos.Genero = "Masculino";
                    break;
                case "Female":
                    nuevoPersonaje.Datos.Genero = "Femenino";
                    break;
            }
            nuevoPersonaje.Datos.Ki = personaje.Ki;
            nuevoPersonaje.Datos.Descripcion = personaje.Description;

            //Caracteristicas
            nuevoPersonaje.Caracteristicas.Fuerza = random.Next(20, 71);
            nuevoPersonaje.Caracteristicas.Salud = 100;
            nuevoPersonaje.Caracteristicas.Velocidad = random.Next(20, 71);
            nuevoPersonaje.Caracteristicas.Agilidad = random.Next(20, 71);
            nuevoPersonaje.Caracteristicas.Resistencia = random.Next(20, 71);
            nuevoPersonaje.Caracteristicas.Energia = random.Next(20, 71);
            
            return nuevoPersonaje;
        }
    }
}