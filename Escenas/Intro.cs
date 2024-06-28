namespace Intro
{

    public class PresentacionJuego
    {
        public static void Presentacion()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@"
                     ___  ___    _   ___  ___  _  _ ___   _   _    _      ____
                    |   \| _ \  /_\ / __|/ _ \| \| | _ ) /_\ | |  | |    |_  /
                    | |) |   / / _ \ (_ | (_) | .` | _ \/ _ \| |__| |__   / / 
                    |___/|_|_\/_/ \_\___|\___/|_|\_|___/_/ \_\____|____| /___|                                                  
            ");

            string frase = "Pulse una tecla para iniciar...";

            Console.Write(new string(' ', (Console.WindowWidth - frase.Length) / 5));
            Console.WriteLine(frase);
            Console.WriteLine("\n\n");

            // Espera que el usuario ingrese una tecla sin mostrarla en la consola
            Console.CursorVisible = false;
            Console.ReadKey(true);
<<<<<<< HEAD

=======
            Console.Clear();
>>>>>>> Prueba

        }
    }

}