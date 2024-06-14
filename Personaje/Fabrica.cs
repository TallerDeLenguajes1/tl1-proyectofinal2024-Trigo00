using DatosApi;
using Personajes;
using System;
using System.Collections.Generic;

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
                nuevoPersonaje.Caracteristicas.Fuerza = random.Next(1, 100);
                nuevoPersonaje.Caracteristicas.Salud = random.Next(1, 100);
                nuevoPersonaje.Caracteristicas.Velocidad = random.Next(1, 100);
                nuevoPersonaje.Caracteristicas.Agilidad = random.Next(1, 100);
                nuevoPersonaje.Caracteristicas.Resistencia = random.Next(1, 100);
                nuevoPersonaje.Caracteristicas.Energia = random.Next(1, 100);
                nuevoPersonaje.Caracteristicas.Velocidad = random.Next(1, 100);

                listaPersonajes.Add(nuevoPersonaje);

            }
            return listaPersonajes;
        }
    }
}