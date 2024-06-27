using Personajes;
using Historial;
using MenuPrincipal;

namespace Cruces
{
    public class Peleas
    {
        public static void mostrarCruces(List<Personaje> lista, List<HistorialGanadores> listado)
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
            Presentacion.Juego.SextaAparicion();
            if(VerificarSiEstoy(crucesOctavos, personajePrincipal)){
                Animaciones.misAnimaciones.CargaDePelea();
            }
            List<Personaje> ganadoresOctavos = SimularPeleas(crucesOctavos, personajePrincipal);
            MostrarCrucesDeRonda("Cuartos de Final", ganadoresOctavos);

            // Simulo y muestro los cruces de semifinales
            List<Tuple<Personaje, Personaje>> crucesCuartos = GenerarCruces(ganadoresOctavos);
            if(VerificarSiEstoy(crucesCuartos, personajePrincipal)){
                Animaciones.misAnimaciones.CargaDePelea();
            }
            List<Personaje> ganadoresCuartos = SimularPeleas(crucesCuartos, personajePrincipal);
            MostrarCrucesDeRonda("Semifinales", ganadoresCuartos);

            // Simulo y muestro la final
            List<Tuple<Personaje, Personaje>> crucesSemifinales = GenerarCruces(ganadoresCuartos);
            if(VerificarSiEstoy(crucesSemifinales, personajePrincipal)){
                Animaciones.misAnimaciones.CargaDePelea();
            }
            List<Personaje> ganadoresSemifinales = SimularPeleas(crucesSemifinales, personajePrincipal);
            MostrarCrucesDeRonda("Final", ganadoresSemifinales);

            // Muestro al ganador final del torneo
            List<Tuple<Personaje, Personaje>> cruceFinal = GenerarCruces(ganadoresSemifinales);
            if(VerificarSiEstoy(cruceFinal, personajePrincipal)){
                Animaciones.misAnimaciones.CargaDePelea();
            }
            List<Personaje> ganadorFinales = SimularPeleaFinal(cruceFinal, personajePrincipal);
            Console.WriteLine($"¡El ganador del torneo es: {ganadorFinales[0].Datos.Nombre}!");
            Thread.Sleep(4000);
            Animaciones.misAnimaciones.RegresarAMenu();
            Console.Clear();
            HistorialGanadores.cargarHistorial(ganadorFinales[0], listado);
            Menu.MostrarOpciones(listado);
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
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\n=== {nombreRonda} ===\n");

            for (int i = 0; i < participantes.Count; i += 2)
            {
                Console.WriteLine($"{i / 2 + 1}: {participantes[i].Datos.Nombre} vs {participantes[i + 1].Datos.Nombre}");
            }
            Thread.Sleep(4000);
            Console.Clear();
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
                    Pelea.PeleaUsuario.contadorPelea();
                    // Si el personajeUsuario está en esta pelea, llama a PeleaPersonaje
                    ganador = Pelea.PeleaUsuario.peleaPersonaje(pelea.Item1, pelea.Item2);
                    if (ganador != personajeUsuario)
                    {
                        Console.WriteLine("¡Perdiste!");
                        Thread.Sleep(3000);
                        Console.Clear();
                        Presentacion.Juego.SeptimaAparicion();
                    }
                    else
                    {
                        Console.WriteLine("¡Ganaste!, avanzas a la siguiente ronda.");
                        Thread.Sleep(3000);
                        Console.Clear();
                        Presentacion.Juego.OctavaAparicion();
                    }
                }
                else
                {
                    if (pelea.Item2 == personajeUsuario)
                    {
                        Pelea.PeleaUsuario.contadorPelea();
                        // Si el personajeUsuario está en esta pelea, llama a PeleaPersonaje
                        ganador = Pelea.PeleaUsuario.peleaPersonaje(pelea.Item2, pelea.Item1);
                        if (ganador != personajeUsuario)
                        {
                            Console.WriteLine("¡Perdiste!");
                            Thread.Sleep(3000);
                            Console.Clear();
                            Presentacion.Juego.SeptimaAparicion();

                        }
                        else
                        {
                            Console.WriteLine("¡Ganaste!, avanzas a la siguiente ronda.");
                            Thread.Sleep(3000);
                            Console.Clear();
                            Presentacion.Juego.OctavaAparicion();
                        }
                    }
                    else
                    {
                        // Si no es una pelea del usuario, elige un ganador aleatorio
                        ganador = rng.Next(2) == 0 ? pelea.Item1 : pelea.Item2;
                    }

                }
                subirEstadisticasGanador(ganador); //Subo las estadisticas del pj que gana un combate en el torneo
                ganadores.Add(ganador);
            }
            return ganadores;
        }

        private static List<Personaje> SimularPeleaFinal(List<Tuple<Personaje, Personaje>> cruces, Personaje personajeUsuario)
        {
            Console.Clear();
            Random rng = new Random();
            List<Personaje> ganadores = new List<Personaje>();

            foreach (var pelea in cruces)
            {
                Personaje ganador;

                if (pelea.Item1 == personajeUsuario)
                {
                    Pelea.PeleaUsuario.contadorPelea();
                    // Si el personajeUsuario está en esta pelea, llama a PeleaPersonaje
                    ganador = Pelea.PeleaUsuario.peleaPersonaje(pelea.Item1, pelea.Item2);
                    if (ganador != personajeUsuario)
                    {
                        Console.WriteLine("¡Perdiste!");
                        Thread.Sleep(3000);
                        Console.Clear();
                        Presentacion.Juego.SeptimaAparicion();
                    }
                    else
                    {
                        Presentacion.Juego.Aparicion10();
                    }
                }
                else
                {
                    if (pelea.Item2 == personajeUsuario)
                    {
                        Pelea.PeleaUsuario.contadorPelea();
                        // Si el personajeUsuario está en esta pelea, llama a PeleaPersonaje
                        ganador = Pelea.PeleaUsuario.peleaPersonaje(pelea.Item2, pelea.Item1);
                        if (ganador != personajeUsuario)
                        {
                            Console.WriteLine("¡Perdiste!");
                            Thread.Sleep(3000);
                            Console.Clear();
                            Presentacion.Juego.SeptimaAparicion();
                        }
                        else
                        {
                            Presentacion.Juego.Aparicion10();
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

        public static void subirEstadisticasGanador(Personaje ganador){

            ganador.Caracteristicas.Agilidad += 2;
            ganador.Caracteristicas.Energia += 2;
            ganador.Caracteristicas.Fuerza += 2;
            ganador.Caracteristicas.Resistencia += 2;
            ganador.Caracteristicas.Velocidad += 2;

        }

        public static bool VerificarSiEstoy(List<Tuple<Personaje, Personaje>> cruces, Personaje personajeUsuario)
        {

            foreach (var pelea in cruces)
            {
                if (pelea.Item1 == personajeUsuario)
                {
                    return true;
                }
                else
                {
                    if (pelea.Item2 == personajeUsuario)
                    {
                        return true;
                    }
                }
                
            }
            return false;
        }

    }
}