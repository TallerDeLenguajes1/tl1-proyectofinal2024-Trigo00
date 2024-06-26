using System;

namespace MenuPrincipal
{
    public class Menu
    {
        public static void MostrarOpciones()
        {
            string asciiArt = @"
    __  ___                     ____       _            _             __
   /  |/  /__  ____  __  __    / __ \_____(_)___  _____(_)___  ____ _/ /
  / /|_/ / _ \/ __ \/ / / /   / /_/ / ___/ / __ \/ ___/ / __ \/ __ `/ / 
 / /  / /  __/ / / / /_/ /   / ____/ /  / / / / / /__/ / /_/ / /_/ / /  
/_/  /_/\___/_/ /_/\__,_/   /_/   /_/  /_/_/ /_/\___/_/ .___/\__,_/_/   
                                                     /_/                 
";
            Console.WriteLine(asciiArt);

            string[] opciones = {
                "Comenzar a Jugar",
                "Historial de Campeones",
                "Informacion Personajes",
                "Salir"
            };

            int seleccionIndex = 0;

            // Ocultar el cursor
            Console.CursorVisible = false;

            void DibujarMenu()
            {
                Console.SetCursorPosition(0, 9); // Posicionar el cursor debajo del título

                // Mostrar las opciones
                for (int i = 0; i < opciones.Length; i++)
                {
                    if (i == seleccionIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.ResetColor();
                    }
                    Console.WriteLine(opciones[i]);
                }

                // Restablecer el color por defecto
                Console.ResetColor();
            }

            // Dibujar el menú inicial
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
                        Console.WriteLine(asciiArt);
                        Console.WriteLine($"Seleccionaste: {opciones[seleccionIndex]}");
                        // Aquí puedes agregar la lógica que desees al seleccionar una opción
                        switch (seleccionIndex)
                        {
                            case 0:
                                // Lógica para "Comenzar a Jugar"
                                Console.WriteLine("Iniciar juego...");
                                break;
                            case 1:
                                // Lógica para "Historial de Campeones"
                                Console.WriteLine("Mostrar historial de campeones...");
                                break;
                            case 2:
                                // Lógica para "Informacion Personajes"
                                Console.WriteLine("Mostrar información de personajes...");
                                break;
                            case 3:
                                // Lógica para "Salir"
                                Console.WriteLine("Saliendo del programa...");
                                return;
                        }
                        return;
                }

                // Actualizar el menú
                DibujarMenu();
            }
        }
    }
}
