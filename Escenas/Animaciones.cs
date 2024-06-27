namespace Animaciones
{
    public class misAnimaciones
    {

        public static void CargaDeJuego()
        {

            int total = 50;
            Console.WriteLine("Cargando...");
            Thread.Sleep(1000); 
            for (int i = 0; i <= total; i++)
            {
                Console.Write("\r");
                Console.Write(new string('█', i));
                Console.Write(new string('░', total - i));
                Console.Write($" {i * 2}%");
                Thread.Sleep(50); // Pausa de 50ms entre cada incremento
            }
        }

        public static void CargaDePelea()
        {

            int total = 50;
            Console.WriteLine("Preparando el combate...");
            Thread.Sleep(1000); 
            for (int i = 0; i <= total; i++)
            {
                Console.Write("\r");
                Console.Write(new string('█', i));
                Console.Write(new string('░', total - i));
                Console.Write($" {i * 2}%");
                Thread.Sleep(50); // Pausa de 50ms entre cada incremento
            }
        }

        public static void RegresarAMenu()
        {
            Console.Clear();
            int total = 50;
            Console.WriteLine("Regresando al Menu Principal...");
            Thread.Sleep(1000); 
            for (int i = 0; i <= total; i++)
            {
                Console.Write("\r");
                Console.Write(new string('█', i));
                Console.Write(new string('░', total - i));
                Console.Write($" {i * 2}%");
                Thread.Sleep(50); // Pausa de 50ms entre cada incremento
            }
        }

    }
}