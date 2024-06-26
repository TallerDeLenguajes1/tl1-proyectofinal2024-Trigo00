namespace Presentacion
{
    public class Juego
    {

        public static void mostrarPuar()
        {

            Console.WriteLine("              ,$$.       ,$$.      ");
            Console.WriteLine("             ,$'$.     ,$'$.     ");
            Console.WriteLine("             $'  $     $'  $     ");
            Console.WriteLine("            :$    $;   :$    $;    ");
            Console.WriteLine("            $$    $$   $$    $$    ");
            Console.WriteLine("            $$  _.$bqgpd$._  $$    ");
            Console.WriteLine("            ;$gd$$^$$$$$^$$bg$:    ");
            Console.WriteLine("          .d$P^*'   \"*\"   *^T$b.  ");
            Console.WriteLine("         d$$$    ,*\"   \"*.    $$$b ");
            Console.WriteLine("        d$$$b._    o   o    _.d$$$b");
            Console.WriteLine("       *T$$$$$P             T$$$$$P*");
            Console.WriteLine("         ^T$$    :\"---\";    $$P^' ");
            Console.WriteLine("            $._     ---'   _.$'    ");
            Console.WriteLine("           .d$$P\"**-----**\"T$$b.   ");
            Console.WriteLine("          d$$P'             T$$b  ");
            Console.WriteLine("         d$$P                 T$$b ");
            Console.WriteLine("        d$P'.'               .T$b");
            Console.WriteLine("        --:                   ;--'");
            Console.WriteLine("           |                   |   ");
            Console.WriteLine("           :                   ;   ");
            Console.WriteLine("            \\                 /    ");
            Console.WriteLine("            .-.           .-'.    ");
            Console.WriteLine("           /   .\"*--+g+--*\".   \\   ");
            Console.WriteLine("          :   /     $$$     \\   ;  ");
            Console.WriteLine("          --'      $$$      --'  ");
            Console.WriteLine("                    :$$;           ");
            Console.WriteLine("                     :$$           ");
            Console.WriteLine("                     'T$bg+.____   ");
            Console.WriteLine("                       'T$$$$$  :  ");
            Console.WriteLine("                           \"**--'  ");

        }

        public static List<string> cargarMensajes()
        {

            List<string> mensajes = new List<string>();

            mensajes.Add("Hola, mi nombre es Puar y yo sere tu guia durante esta experiencia");
            mensajes.Add("Este es un juego de rol basado en la serie Dragon Ball Z");
            mensajes.Add("La modalidad del mismo consiste en llevar a cabo el Gran Torneo de Artes Marciales");
            mensajes.Add("Donde habran un total de 16 participantes listos para luchar y poner a prueba sus habilidades");
            mensajes.Add("Estas listo para comenzar?");

            return mensajes;

        }

        public static void mostrarOpciones()
{
    string asciiArt = @"
    __  ___                     ____       _            _             __
   /  |/  /__  ____  __  __    / __ \_____(_)___  _____(_)___  ____ _/ /
  / /|_/ / _ \/ __ \/ / / /   / /_/ / ___/ / __ \/ ___/ / __ \/ __ `/ / 
 / /  / /  __/ / / / /_/ /   / ____/ /  / / / / / /__/ / /_/ / /_/ / /  
/_/  /_/\___/_/ /_/\__,_/   /_/   /_/  /_/_/ /_/\___/_/ .___/\__,_/_/   
                                                     /_/                 
";

    string[] opciones = {
        "Comenzar a Jugar",
        "Historial de Campeones",
        "Informacion Personajes",
        "Salir"
    };

    int seleccionIndex = 0;

    // Oculto el cursor
    Console.CursorVisible = false;

    // Calcular posiciones para centrar
    int windowHeight = Console.WindowHeight;
    int windowWidth = Console.WindowWidth;

    // Calcular posición vertical para el título
    int titleVerticalPosition = (windowHeight - asciiArt.Split('\n').Length) / 2;

    // Calcular posición vertical para el menú
    int menuVerticalPosition = titleVerticalPosition + asciiArt.Split('\n').Length + 2;

    // Dibujar el título centrado
    Console.Clear();
    Console.SetCursorPosition((windowWidth - asciiArt.Split('\n')[0].Length) / 2, titleVerticalPosition);
    Console.WriteLine(asciiArt);

    // Dibujar el menú centrado
    Console.SetCursorPosition((windowWidth - opciones[0].Length) / 2, menuVerticalPosition);

    void DibujarMenu()
    {
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
                // Muestro el cursor nuevamente antes de salir del método
                Console.CursorVisible = true;
                Console.WriteLine($"Seleccionaste: {opciones[seleccionIndex]}");
                // Aquí puedes agregar la lógica que desees al seleccionar una opción
                switch (seleccionIndex)
                {
                    case 0:
                        // Lógica para "Comenzar a Jugar"
                        break;
                    case 1:
                        // Lógica para "Historial de Campeones"
                        break;
                    case 2:
                        // Lógica para "Informacion Personajes"
                        break;
                    case 3:
                        // Lógica para "Salir"
                        return;
                }
                return;
        }

        // Actualizar el menú
        Console.SetCursorPosition((windowWidth - opciones[0].Length) / 2, menuVerticalPosition);
        DibujarMenu();
    }
}





    }
}