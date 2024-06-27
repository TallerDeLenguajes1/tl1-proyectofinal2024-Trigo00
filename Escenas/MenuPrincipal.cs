using Historial;
using Personajes;

namespace MenuPrincipal
{
    public class Menu
    {
        public static void MostrarOpciones(List<HistorialGanadores> listado)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string asciiArt = @"
    __  ___                     ____       _            _             __
   /  |/  /__  ____  __  __    / __ \_____(_)___  _____(_)___  ____ _/ /
  / /|_/ / _ \/ __ \/ / / /   / /_/ / ___/ / __ \/ ___/ / __ \/ __ / / 
 / /  / /  __/ / / / /_/ /   / ____/ /  / / / / / /__/ / /_/ / /_/ / /  
/_/  /_/\___/_/ /_/\__,_/   /_/   /_/  /_/_/ /_/\___/_/ .___/\__,_/_/   
                                                     /_/                 
";
            string[] opciones = {
                "Jugar",
                "Historial de Campeones",
                "Salir"
            };

            int seleccionIndex = 0;

            // Ocultar el cursor
            Console.CursorVisible = false;

            void DibujarMenu()
            {
                Console.Clear();

                // Obtengo el ancho de la consola
                int anchoConsola = Console.WindowWidth;

                // Divido el arte ASCII en líneas y luego las centro
                string[] lineasAscii = asciiArt.Split('\n');
                foreach (var linea in lineasAscii)
                {
                    int espaciosBlanco = (anchoConsola - linea.Length) / 2;
                    if (espaciosBlanco > 0)
                    {
                        Console.Write(new string(' ', espaciosBlanco));
                    }

                    // Esto hago para que no me pinte todos los espacios en blanco, sino solo el texto
                    foreach (char c in linea)
                    {
                        if (c == ' ')
                        {
                            Console.Write(' ');
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(c);
                        }
                    }
                    Console.WriteLine();
                }

                // Muestro las opciones
                for (int i = 0; i < opciones.Length; i++)
                {
                    int espaciosBlanco = (anchoConsola - opciones[i].Length) / 2;
                    if (espaciosBlanco > 0)
                    {
                        Console.Write(new string(' ', espaciosBlanco));
                    }

                    if (i == seleccionIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }

                    Console.WriteLine(opciones[i]);
                    Console.ResetColor(); // Restablezco los colores después de imprimir cada opción
                }
            }

            // Dibujo el menú inicial
            DibujarMenu();

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (seleccionIndex > 0) seleccionIndex--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (seleccionIndex < opciones.Length - 1) seleccionIndex++;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        // Mostrar el título nuevamente antes de salir del método
                        int anchoConsola = Console.WindowWidth;
                        string[] lineasAscii = asciiArt.Split('\n');
                        foreach (var line in lineasAscii)
                        {
                            int espaciosBlanco = (anchoConsola - line.Length) / 2;
                            if (espaciosBlanco > 0)
                            {
                                Console.Write(new string(' ', espaciosBlanco));
                            }

                            foreach (char c in line)
                            {
                                if (c == ' ')
                                {
                                    Console.Write(' ');
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write(c);
                                }
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine($"Seleccionaste: {opciones[seleccionIndex]}");
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        switch (seleccionIndex)
                        {
                            case 0:
                                // Lógica de "Jugar"
                                Animaciones.misAnimaciones.CargaDeJuego();
                                Console.Clear();
                                List<Personaje> listaPersonajesTorneo = LuchadoresTorneo.Torneo.ObtenerListaPeleadores();
                                Presentacion.Juego.CuartaAparicion(listaPersonajesTorneo);
                                Presentacion.Juego.QuintaAparicion();
                                Cruces.Peleas.mostrarCruces(listaPersonajesTorneo, listado);
                                break;
                            case 1:
                                // Lógica de "Historial de Campeones"
                                HistorialGanadores.mostrarListado(listado);
                                break;
                            case 2:
                                // Lógica de "Salir"
                                Console.WriteLine("Saliendo del programa...");
                                Thread.Sleep(3000); 
                                Console.Clear();
                                return;
                        }
                        return;
                }

                // Actualizo el menú
                DibujarMenu();
            }
        }
    }
}
