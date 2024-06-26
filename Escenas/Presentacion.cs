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

        public static void mostrarMensajes()
        {
            int mensajeNumero = 0;

            List<string> mensajes = new List<string>();

            mensajes.Add("Hola, mi nombre es Puar y yo sere tu guia durante esta experiencia");
            mensajes.Add("Este es un juego de rol basado en la serie Dragon Ball Z");
            mensajes.Add("La modalidad del mismo consiste en llevar a cabo el Gran Torneo de Artes Marciales");
            mensajes.Add("Donde habran un total de 16 participantes listos para luchar y poner a prueba sus habilidades");
            mensajes.Add("Estas listo para comenzar?");

            for (int i = 0; i < mensajes.Count; i++)
            {
                Console.Clear();

                // Mover el cursor al principio de la consola
                Console.SetCursorPosition(0, 0);

                // Imprimo el ASCII de Puar
                mostrarPuar();

                // Imprimir el mensaje al costado
                Console.SetCursorPosition(40, 0);

                // Obtener el tamaño de la ventana de la consola
                int windowHeight = Console.WindowHeight;

                // Contar el número de líneas en el texto
                int textLineCount = mensajes[mensajeNumero].Split('\n').Length;

                // Calcular el número de líneas de relleno necesarias para centrar el texto
                int paddingLines = (windowHeight - textLineCount) / 2;

                // Imprimir líneas en blanco antes del texto para centrarlo verticalmente
                for (int j = 0; j < paddingLines - 5; j++)
                {
                    Console.WriteLine();
                }

                // Imprimir el texto
                Console.WriteLine("         ^T$$     :\"---\";    $$P^'      " + mensajes[mensajeNumero]);

                // Cambiar el mensaje después de un tiempo
                int cantidadTextos = mensajes.Count;
                if (i == cantidadTextos - 1)
                {
                    // Interacción con botones Sí y No
                    int seleccionIndex = 0;
                    string[] opciones = { "Si", "No" };

                    // Oculto el cursor
                    Console.CursorVisible = false;

                    // Posicionar el cursor antes de la línea de opciones
                    int leftMargin = 45;
                    int topMargin = Console.CursorTop + 2;

                    while (true)
                    {
                        Console.SetCursorPosition(0, topMargin - 1);
                        Console.WriteLine();
                        Console.SetCursorPosition(0, topMargin);

                        // Muestro las opciones
                        for (int k = 0; k < opciones.Length; k++)
                        {
                            Console.SetCursorPosition(leftMargin + (k * 10), topMargin);
                            if (k == seleccionIndex)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                            }
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write($"[{opciones[k]}]");
                            Console.ResetColor();
                        }

                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.LeftArrow:
                                if (seleccionIndex > 0) seleccionIndex--;
                                break;
                            case ConsoleKey.RightArrow:
                                if (seleccionIndex < opciones.Length - 1) seleccionIndex++;
                                break;
                            case ConsoleKey.Enter:
                                Console.Clear();
                                // Muestro el cursor nuevamente antes de salir del método
                                Console.CursorVisible = true;
                                if(opciones[seleccionIndex] == "Si"){
                                    MenuPrincipal.Menu.MostrarOpciones();
                                }else{
                                    Console.WriteLine($"Seleccionaste: {opciones[seleccionIndex]}");
                                }
                                return;
                        }
                    }
                }
                else
                {
                    mensajeNumero = (mensajeNumero + 1) % mensajes.Count;
                    Thread.Sleep(4000); // Esperar 4 segundos antes de cambiar el mensaje
                }
            }
        }







    }
}