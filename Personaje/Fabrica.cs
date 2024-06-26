using DatosApi;
using Personajes;

namespace FabricaPersonajes
{
    public class Fabrica
    {
        private static Random random = new Random();

        public static List<Personaje> cargarDatos(List<Personaje> listaPersonajes, List<PersonajeApi> personajesApi)
        {

            foreach (var personaje in personajesApi)
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

                listaPersonajes.Add(nuevoPersonaje);

            }
            return listaPersonajes;
        }
    }
}