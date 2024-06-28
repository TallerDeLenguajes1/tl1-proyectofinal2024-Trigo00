namespace Animaciones
{
    public class misAnimaciones
    {

        public static void AnimacionCargaDeJuego()
        {
            MostrarMensajeConCarga("Cargando...");
        }

        public static void AnimacionCargaDePelea()
        {
            MostrarMensajeConCarga("Preparando el combate...");
        }

        public static void AnimacionRegresarAMenu()
        {
            Console.Clear();
            MostrarMensajeConCarga("Regresando al Menu Principal...");
        }

        private static void MostrarMensajeConCarga(string mensaje)
        {
            Console.WriteLine(mensaje);
            AnimacionDeCarga();
        }

        private static void AnimacionDeCarga()
        {
            int total = 50;
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