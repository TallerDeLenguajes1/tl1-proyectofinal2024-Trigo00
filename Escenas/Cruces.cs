using Personajes;
using Historial;

namespace Cruces
{
    public class Peleas
    {
        public static void mostrarCruces(List<Personaje> lista)
        {
            Personaje personajePrincipal = lista[0];
            Random rng = new Random();

            // Mezclo la lista de participantes aleatoriamente
            Mezclar(lista, rng);

            // Muestro los cruces de octavos de final
            Console.WriteLine("\n== Torneo de Artes Marciales ==");
            MostrarCrucesDeRonda("Octavos de Final", lista);

            // Simulo y muestro los cruces de cuartos de final
            List<Tuple<Personaje, Personaje>> crucesOctavos = GenerarCruces(lista);
            List<Personaje> ganadoresOctavos = SimularPeleas(crucesOctavos, personajePrincipal);
            MostrarCrucesDeRonda("Cuartos de Final", ganadoresOctavos);

            // Simulo y muestro los cruces de semifinales
            List<Tuple<Personaje, Personaje>> crucesCuartos = GenerarCruces(ganadoresOctavos);
            List<Personaje> ganadoresCuartos = SimularPeleas(crucesCuartos, personajePrincipal);
            MostrarCrucesDeRonda("Semifinales", ganadoresCuartos);

            // Simulo y muestro la final
            List<Tuple<Personaje, Personaje>> crucesSemifinales = GenerarCruces(ganadoresCuartos);
            List<Personaje> ganadoresSemifinales = SimularPeleas(crucesSemifinales, personajePrincipal);
            MostrarCrucesDeRonda("Final", ganadoresSemifinales);

            // Muestro al ganador final del torneo
            List<Tuple<Personaje, Personaje>> cruceFinal = GenerarCruces(ganadoresSemifinales);
            List<Personaje> ganadorFinales = SimularPeleas(cruceFinal, personajePrincipal);
            Console.WriteLine($"\n¡El ganador del torneo es: {ganadorFinales[0].Datos.Nombre}!");

        }

        private static void Mezclar(List<Personaje> lista, Random rng)
        {
            int n = lista.Count;
            for (int i = 0; i < n; i++)
            {
                int k = rng.Next(i, n);
                Personaje temp = lista[i];
                lista[i] = lista[k];
                lista[k] = temp;
            }
        }

        private static void MostrarCrucesDeRonda(string nombreRonda, List<Personaje> participantes)
        {
            Console.WriteLine($"\n=== {nombreRonda} ===\n");

            for (int i = 0; i < participantes.Count; i += 2)
            {
                Console.WriteLine($"{i / 2 + 1}: {participantes[i].Datos.Nombre} vs {participantes[i + 1].Datos.Nombre}");
            }
        }

        private static List<Tuple<Personaje, Personaje>> GenerarCruces(List<Personaje> participantes)
        {
            List<Tuple<Personaje, Personaje>> cruces = new List<Tuple<Personaje, Personaje>>();

            for (int i = 0; i < participantes.Count; i += 2)
            {
                cruces.Add(Tuple.Create(participantes[i], participantes[i + 1]));
            }

            return cruces;
        }

        private static List<Personaje> SimularPeleas(List<Tuple<Personaje, Personaje>> cruces, Personaje personajeUsuario)
        {
            Random rng = new Random();
            List<Personaje> ganadores = new List<Personaje>();

            foreach (var pelea in cruces)
            {
                Personaje ganador;

                if (pelea.Item1 == personajeUsuario)
                {
                    // Si el personajeUsuario está en esta pelea, llama a PeleaPersonaje
                    ganador = Pelea.PeleaUsuario.peleaPersonaje(pelea.Item1, pelea.Item2);
                    if (ganador != personajeUsuario)
                    {
                        Console.WriteLine("¡Perdiste!");
                        Console.WriteLine("Vuelva a intentarlo en la siguiente oportunidad");
                    }
                    else
                    {
                        Console.WriteLine("¡Bien hecho!, avanzas a la siguiente ronda.");
                    }
                }
                else
                {
                    if (pelea.Item2 == personajeUsuario)
                    {
                        // Si el personajeUsuario está en esta pelea, llama a PeleaPersonaje
                        ganador = Pelea.PeleaUsuario.peleaPersonaje(pelea.Item2, pelea.Item1);
                        if (ganador != personajeUsuario)
                        {
                            Console.WriteLine("¡Perdiste!");
                            Console.WriteLine("Vuelva a intentarlo en la siguiente oportunidad");
                        }
                        else
                        {
                            Console.WriteLine("¡Bien hecho!, avanzas a la siguiente ronda.");
                        }
                    }
                    else
                    {
                        // Si no es una pelea del usuario, elige un ganador aleatorio
                        ganador = rng.Next(2) == 0 ? pelea.Item1 : pelea.Item2;
                    }

                }
                ganadores.Add(ganador);
            }
            return ganadores;
        }
    }
}