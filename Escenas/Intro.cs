namespace Intro
{
    public class PresentacionJuego
    {
        public static void Presentacion()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            
            string[] logo = 
            {
                " ___  ___    _   ___  ___  _  _ ___   _   _    _      ____",
                "|   \\| _ \\  /_\\ / __|/ _ \\| \\| | _ ) /_\\ | |  | |    |_  /",
                "| |) |   / / _ \\ (_ | (_) | .` | _ \\/ _ \\| |__| |__   / / ",
                "|___/|_|_\\/_/ \\_\\___|\\___/|_|\\_|___/_/ \\_\\____|____| /___|"
            };

            foreach (var line in logo)
            {
                Console.WriteLine(line.PadLeft((Console.WindowWidth + line.Length) / 2));
            }

            string frase = "Pulse una tecla para iniciar...";
            int emptyLinesBeforeFrase = (logo.Length / 2) - 1; // Número de líneas vacías antes de la frase
            for (int i = 0; i < emptyLinesBeforeFrase; i++)
            {
                Console.WriteLine();
            }

            Console.WriteLine(frase.PadLeft((Console.WindowWidth + frase.Length) / 2));

            // Espera que el usuario ingrese una tecla sin mostrarla en la consola
            Console.CursorVisible = false;
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
