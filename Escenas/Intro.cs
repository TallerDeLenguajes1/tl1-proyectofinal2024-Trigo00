namespace Intro
{

    public class Presentacion
    {
        public static void InicioJuego()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@"
                     ___  ___    _   ___  ___  _  _ ___   _   _    _      ____
                    |   \| _ \  /_\ / __|/ _ \| \| | _ ) /_\ | |  | |    |_  /
                    | |) |   / / _ \ (_ | (_) | .` | _ \/ _ \| |__| |__   / / 
                    |___/|_|_\/_/ \_\___|\___/|_|\_|___/_/ \_\____|____| /___|                                                  
            ");

            string frase = "Pulse una tecla para iniciar...";
            // int velocidad = 20; // milisegundos
            // for (int i = 0; i < helloWorld.Length; i++)
            // {
            //     Console.Write(helloWorld[i]);
            //     if (i + 1 < helloWorld.Length && helloWorld[i + 1] == ' ')
            //     {
            //         Console.Write(' ');
            //     }
            //     Thread.Sleep(velocidad);
            // }

            Console.Write(new string(' ', (Console.WindowWidth - frase.Length) / 5));
            Console.WriteLine(frase);
            Console.WriteLine("\n\n");

            // Esperar a que el usuario ingrese una tecla sin mostrarla en la consola
            Console.CursorVisible = false;
            Console.ReadKey(true);


        }
    }

}