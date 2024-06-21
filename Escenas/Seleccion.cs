using Personajes;

namespace Seleccion
{
    public class SeleccionUsuario
    {
        public static Personaje SeleccionPersonaje(List<Personaje> listaPersonajes)
        {
            if (listaPersonajes == null || listaPersonajes.Count == 0)
            {
                Console.WriteLine("No hay personajes disponibles.");
                return null;
            }

            int columnas = 3; // Número de columnas
            int filas = (int)Math.Ceiling(listaPersonajes.Count / (double)columnas);

            // Calcular el ancho de cada columna
            int maxNombreLength = listaPersonajes.Max(p => p.Datos.Nombre.Length);
            int columnWidth = maxNombreLength + 5; // Ajustar el espacio entre columnas

            int seleccionIndex = 0;

            Console.CursorVisible = false;
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Seleccione un personaje de la lista:");

                // Mostrar los personajes en columnas
                for (int fila = 0; fila < filas; fila++)
                {
                    for (int col = 0; col < columnas; col++)
                    {
                        int index = fila * columnas + col;
                        if (index < listaPersonajes.Count)
                        {
                            string item = $"{listaPersonajes[index].Datos.Nombre}";
                            if (index == seleccionIndex)
                            {
                                Console.BackgroundColor = ConsoleColor.Gray;
                                Console.ForegroundColor = ConsoleColor.Black;
                            }
                            Console.Write(item.PadRight(columnWidth));
                            Console.ResetColor();
                        }
                    }
                    Console.WriteLine();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (seleccionIndex - columnas >= 0) seleccionIndex -= columnas;
                        break;
                    case ConsoleKey.DownArrow:
                        if (seleccionIndex + columnas < listaPersonajes.Count) seleccionIndex += columnas;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (seleccionIndex > 0) seleccionIndex--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (seleccionIndex < listaPersonajes.Count - 1) seleccionIndex++;
                        break;
                    case ConsoleKey.Enter:
                        Personaje seleccionado = listaPersonajes[seleccionIndex];
                        Console.WriteLine($"\nHas seleccionado a {seleccionado.Datos.Nombre}.");
                        Console.CursorVisible = true;
                        Console.WriteLine("Presiona cualquier tecla para continuar...");
                        Console.ReadKey(true);
                        return seleccionado;
                }
            }
        }

        public static void MostrarMenuContrincantes(List<Personaje> listaPersonajes, Personaje personajePrincipal)
        {
            Console.Clear();
            Console.WriteLine("Selecciona cómo quieres elegir los contrincantes:");

            int seleccionIndex = 0;
            string[] opciones = {
                "1. Seleccionar contrincantes aleatoriamente",
                "2. Seleccionar contrincantes manualmente"
            };

            while (true)
            {
                Console.SetCursorPosition(0, 2); // Posicionar el cursor después del título

                // Mostrar las opciones
                for (int i = 0; i < opciones.Length; i++)
                {
                    if (i == seleccionIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(opciones[i]);
                    Console.ResetColor();
                }

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
                        switch (seleccionIndex)
                        {
                            case 0:
                                List<Personaje> contrincantesAleatorios = SeleccionarContrincantesAleatoriamente(listaPersonajes, personajePrincipal);
                                MostrarContrincantes(contrincantesAleatorios);
                                break;
                            case 1:
                                List<Personaje> contrincantesSeleccionados = SeleccionarContrincantesManualmente(listaPersonajes, personajePrincipal);
                                MostrarContrincantes(contrincantesSeleccionados);
                                break;
                        }
                        return;
                }
            }
        }

        public static List<Personaje> SeleccionarContrincantesAleatoriamente(List<Personaje> listaPersonajes, Personaje personajePrincipal)
        {
            Random random = new Random();
            List<Personaje> contrincantes = listaPersonajes.Where(p => p != personajePrincipal).OrderBy(p => random.Next()).Take(15).ToList();
            return contrincantes;
        }

        public static List<Personaje> SeleccionarContrincantesManualmente(List<Personaje> listaPersonajes, Personaje personajePrincipal)
        {
            List<Personaje> seleccionados = new List<Personaje>();
            List<Personaje> disponibles = listaPersonajes.Where(p => p != personajePrincipal).ToList();
            int seleccionadosCount = 0;
            int seleccionIndex = 0;
            int columnas = 3; // Número de columnas
            int maxNombreLength = disponibles.Max(p => p.Datos.Nombre.Length);
            int columnWidth = maxNombreLength + 5; // Ajustar el espacio entre columnas
            int filas = (int)Math.Ceiling(disponibles.Count / (double)columnas);
            ConsoleKeyInfo keyInfo;

            Console.Clear();
            Console.WriteLine("Seleccione 15 contrincantes (presione Enter para seleccionar):");

            // Mostrar los personajes disponibles inicialmente
            MostrarPersonajesDisponibles(disponibles, seleccionIndex);

            while (seleccionadosCount < 15)
            {
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        if (disponibles.Count > seleccionIndex)
                        {
                            Personaje seleccionado = disponibles[seleccionIndex];
                            seleccionados.Add(seleccionado);
                            disponibles.RemoveAt(seleccionIndex);
                            seleccionadosCount++;
                            if (seleccionIndex >= disponibles.Count && disponibles.Count > 0)
                            {
                                seleccionIndex = disponibles.Count - 1;
                            }

                            // Mostrar los personajes disponibles actualizados después de la selección
                            Console.Clear();
                            Console.WriteLine("Seleccione 15 contrincantes (presione Enter para seleccionar):");
                            MostrarPersonajesDisponibles(disponibles, seleccionIndex);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (seleccionIndex - columnas >= 0)
                        {
                            seleccionIndex -= columnas;
                            MostrarPersonajesDisponibles(disponibles, seleccionIndex);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (seleccionIndex + columnas < disponibles.Count)
                        {
                            seleccionIndex += columnas;
                            MostrarPersonajesDisponibles(disponibles, seleccionIndex);
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (seleccionIndex > 0)
                        {
                            seleccionIndex--;
                            MostrarPersonajesDisponibles(disponibles, seleccionIndex);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (seleccionIndex < disponibles.Count - 1)
                        {
                            seleccionIndex++;
                            MostrarPersonajesDisponibles(disponibles, seleccionIndex);
                        }
                        break;
                }
            }

            return seleccionados;
        }

        public static void MostrarPersonajesDisponibles(List<Personaje> disponibles, int seleccionIndex)
        {
            Console.SetCursorPosition(0, 3); // Posiciona el cursor debajo del título

            int columnas = 3; // Número de columnas
            int filas = (int)Math.Ceiling(disponibles.Count / (double)columnas);

            // Calcular el ancho de cada columna
            int maxNombreLength = disponibles.Max(p => p.Datos.Nombre.Length);
            int columnWidth = maxNombreLength + 5; // Ajustar el espacio entre columnas

            // Mostrar los personajes en columnas
            for (int fila = 0; fila < filas; fila++)
            {
                for (int col = 0; col < columnas; col++)
                {
                    int index = fila * columnas + col;
                    if (index < disponibles.Count)
                    {
                        string item = $"{disponibles[index].Datos.Nombre}";
                        if (index == seleccionIndex)
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        Console.Write(item.PadRight(columnWidth));
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
        }


        public static void MostrarContrincantes(List<Personaje> contrincantes)
        {
            Console.Clear();
            Console.WriteLine("Contrincantes seleccionados:");
            foreach (var contrincante in contrincantes)
            {
                Console.WriteLine(contrincante.Datos.Nombre);
            }
        }
    }
}