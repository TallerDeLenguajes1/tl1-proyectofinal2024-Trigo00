using Personajes;

namespace Cruces
{
    public class Peleas
    {
        public static void mostrarCruces(List<Personaje> lista)
        {
            Random rng = new Random();

            // Mezclar la lista de participantes aleatoriamente
            Shuffle(lista, rng);

            // Mostrar los cruces de octavos de final
            Console.WriteLine("\n== Torneo de Artes Marciales ==");
            MostrarCrucesDeRonda("Octavos de Final", lista);

            // Simular y mostrar los cruces de cuartos de final
            List<Tuple<Personaje, Personaje>> crucesOctavos = GenerarCruces(lista);
            List<Personaje> ganadoresOctavos = SimularPeleas(crucesOctavos);
            MostrarCrucesDeRonda("Cuartos de Final", ganadoresOctavos);

            // Simular y mostrar los cruces de semifinales
            List<Tuple<Personaje, Personaje>> crucesCuartos = GenerarCruces(ganadoresOctavos);
            List<Personaje> ganadoresCuartos = SimularPeleas(crucesCuartos);
            MostrarCrucesDeRonda("Semifinales", ganadoresCuartos);

            // Simular y mostrar la final
            List<Tuple<Personaje, Personaje>> crucesSemifinales = GenerarCruces(ganadoresCuartos);
            List<Personaje> ganadoresSemifinales = SimularPeleas(crucesSemifinales);
            MostrarCrucesDeRonda("Final", ganadoresSemifinales);

            // Mostrar al ganador final del torneo
            Personaje ganadorFinal = ObtenerGanadorFinal(ganadoresSemifinales);
            Console.WriteLine($"\n¡El ganador del torneo es: {ganadorFinal.Datos.Nombre}!");
        }

        public static Personaje ObtenerGanadorFinal(List<Personaje> ganadoresSemifinales)
        {
            // El ganador final es el último elemento de la lista de ganadores de semifinales
            return ganadoresSemifinales[ganadoresSemifinales.Count - 1];
        }

        private static void Shuffle(List<Personaje> lista, Random rng)
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

        private static List<Personaje> SimularPeleas(List<Tuple<Personaje, Personaje>> cruces)
        {
            Random rng = new Random();
            List<Personaje> ganadores = new List<Personaje>();

            foreach (var pelea in cruces)
            {
                // Simular un ganador aleatorio para cada pelea
                Personaje ganador = rng.Next(2) == 0 ? pelea.Item1 : pelea.Item2;
                ganadores.Add(ganador);
            }

            return ganadores;
        }
    }
}