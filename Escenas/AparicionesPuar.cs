using Personajes;

namespace AparicionesPuar
{
    public class ApPuar
    {

        public static void AparicionParaElegirPersonaje()
        {
            int mensajeNumero = 0;

            List<string> mensajes = new List<string>();

            mensajes.Add("Muy bien, comencemos por elegir el personaje que usaras para los combates");
            mensajes.Add("Recuerda que al elegir un personaje, no podras elegir otro.");

            for (int i = 0; i < mensajes.Count; i++)
            {
                mensajeNumero = MostrarMensajesPuar(mensajeNumero, mensajes);
            }
        }

        public static void ExplicacionEleccionOponentes()
        {
            int mensajeNumero = 0;

            List<string> mensajes = new List<string>();

            mensajes.Add("Ahora tendras que elegir como te gustaria que sea la seleccion de tus oponentes");
            mensajes.Add("Si eliges de manera aleatoria, se cargaran todos tus oponentes aleatoriamente y automaticamente");
            mensajes.Add("En cambio");
            mensajes.Add("Si eliges de manera manual, tendras que elegir 15 oponentes que quieras que participen del torneo");
            mensajes.Add("Tu eliges...");


            for (int i = 0; i < mensajes.Count; i++)
            {
                mensajeNumero = MostrarMensajesPuar(mensajeNumero, mensajes);
            }
        }

        public static void AparicionParaMostrarParticipantes(List<Personaje> lista)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int mensajeNumero = 0;

            List<string> mensajes = new List<string>();

            mensajes.Add("Excelente, ya tenemos a los 16 participantes del Torneo.");
            mensajes.Add("Esta es la lista de participantes");

            for (int i = 0; i < mensajes.Count; i++)
            {
                mensajeNumero = MostrarMensajesPuar(mensajeNumero, mensajes);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Lista de participantes");
                Console.WriteLine();
                int cont = 1;
                foreach (var participantes in lista)
                {
                    Console.WriteLine(cont + ": " + participantes.Datos.Nombre);
                    cont++;
                }
            }
            Thread.Sleep(4000);
        }

        public static void AparicionParaSorteo()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int mensajeNumero = 0;
            List<string> mensajes = new List<string>();

            mensajes.Add("Ahora se hara el sorteo de los enfrentamientos");
            mensajes.Add("Espero tengas buena suerte");
            mensajes.Add("...");
            mensajes.Add("Muy bien, estos son los enfrentamientos");

            for (int i = 0; i < mensajes.Count; i++)
            {
                mensajeNumero = MostrarMensajesPuar(mensajeNumero, mensajes);
            }
        }

        public static void ExplicacionSobreCombates()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int mensajeNumero = 0;
            List<string> mensajes = new List<string>();

            mensajes.Add("Los combates se haran de manera simultanea");
            mensajes.Add("Por lo tanto, no podras observar a los demas pelear");
            mensajes.Add("...");
            mensajes.Add("Hare algo que no deberia, pero Yamcha siempre me dice que debo ayudar a mis amigos");
            mensajes.Add("Asi que te dare ataques y defensas especiales, pero no se lo digas a nadie");
            mensajes.Add("Lo que debes hacer es simple, responde bien las preguntas y obtendras beneficios");
            mensajes.Add("Si atacas y respondes bien, tu ataque será potenciado, de lo contrario, no recibes nada");
            mensajes.Add("Si te defiendes y respondes bien, obtendras mayor resistencia. Y en caso de errar, no recibiras nada");

            for (int i = 0; i < mensajes.Count; i++)
            {
                mensajeNumero = MostrarMensajesPuar(mensajeNumero, mensajes);
            }
        }

        public static void AparicionCuandoPerdesCombate()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int mensajeNumero = 0;
            List<string> mensajes = new List<string>();

            mensajes.Add("Vaya, perdiste...");
            mensajes.Add("No importa, lo importante es participar y divertirse");
            mensajes.Add("¡Te espero en el siguiente torneo!");

            for (int i = 0; i < mensajes.Count; i++)
            {
                mensajeNumero = MostrarMensajesPuar(mensajeNumero, mensajes);
            }
        }

        public static void AparicionCuandoGanasCombate()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int mensajeNumero = 0;
            List<string> mensajes = new List<string>();

            mensajes.Add("Felicidades, estuviste increible");
            mensajes.Add("Como premio por tu esfuerzo, recibiste un incremento de tus estadisticas");
            mensajes.Add("Aprovechalas");

            for (int i = 0; i < mensajes.Count; i++)
            {
                mensajeNumero = MostrarMensajesPuar(mensajeNumero, mensajes);
            }
        }


        public static void AparicionAlGanarTorneo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int mensajeNumero = 0;
            List<string> mensajes = new List<string>();

            mensajes.Add("¡Felicidades!, ganaste el Torneo");
            mensajes.Add("Siempre confie en ti");
            mensajes.Add("Ahora formaras parte del salon de campeones");

            for (int i = 0; i < mensajes.Count; i++)
            {
                mensajeNumero = MostrarMensajesPuar(mensajeNumero, mensajes);
            }
        }

        public static void MostrarPuar()
        {

            Console.WriteLine("              ,$$.       ,$$.      ");
            Console.WriteLine("             ,$'$.       ,$'$.     ");
            Console.WriteLine("             $'  $      $'   $     ");
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
            Console.WriteLine("           --'     $$$       '--  ");
            Console.WriteLine("                    :$$;           ");
            Console.WriteLine("                     :$$           ");
            Console.WriteLine("                     'T$bg+.____   ");
            Console.WriteLine("                       'T$$$$$  :  ");
            Console.WriteLine("                           \"**--'  ");

        }
        public static void AparicionCuandoNoQuiereJugar()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int mensajeNumero = 0;
            List<string> mensajes = new List<string>();

            mensajes.Add("Aun no estas listo por lo visto");
            mensajes.Add("Vuelve cuando estes preparado, te estare esperando");

            for (int i = 0; i < mensajes.Count; i++)
            {
                mensajeNumero = MostrarMensajesPuar(mensajeNumero, mensajes);
            }
        }

        private static int MostrarMensajesPuar(int mensajeNumero, List<string> mensajes)
        {
            Console.Clear();
            Console.CursorVisible = false;

            // Muevo el cursor al principio de la consola
            Console.SetCursorPosition(0, 0);

            // Imprimo el ASCII de Puar
            MostrarPuar();

            // Imprimo el mensaje al costado
            Console.SetCursorPosition(40, 0);

            // Obtengo el tamaño de la ventana de la consola
            int windowHeight = Console.WindowHeight;

            // Cuento el número de líneas en el texto
            int textLineCount = mensajes[mensajeNumero].Split('\n').Length;

            // Calculo el número de líneas de relleno necesarias para centrar el texto
            int paddingLines = (windowHeight - textLineCount) / 2;

            // Imprimo líneas en blanco antes del texto para centrarlo verticalmente
            for (int j = 0; j < paddingLines - 5; j++)
            {
                Console.WriteLine();
            }

            Console.WriteLine("         ^T$$     :\"---\";    $$P^'      " + mensajes[mensajeNumero]);
            mensajeNumero = (mensajeNumero + 1) % mensajes.Count;
            Thread.Sleep(4000);
            Console.Clear();

            return mensajeNumero;
        }
    }
}