using Personajes;
using CuantoSabes;

namespace Pelea
{
    public class PeleaUsuario
    {

        private static Random rand = new Random();

        public static int devolverDanio(Personaje personajeUsuario)
        {
            double Ataque = (personajeUsuario.Caracteristicas.Fuerza) * (personajeUsuario.Caracteristicas.Velocidad) * (personajeUsuario.Caracteristicas.Energia);
            double Efectividad = rand.Next(50, 101);
            double Defensa = (personajeUsuario.Caracteristicas.Resistencia) * (personajeUsuario.Caracteristicas.Agilidad) * (personajeUsuario.Caracteristicas.Energia);
            double CtteAjuste = 1000000;
            double DanioProvocado = ((Ataque * Efectividad) - Defensa) / CtteAjuste;

            return (int)DanioProvocado;
        }



        public static Personaje peleaPersonaje(Personaje peleadorUsuario, Personaje contrincante)
        {

            // Determina aleatoriamente quién comienza
            int numeroRandom = rand.Next(0,2);// 0 a 1
            int primerTurno = 1;

            while (peleadorUsuario.Caracteristicas.Salud > 0 && contrincante.Caracteristicas.Salud > 0)
            {

                if (numeroRandom == 1)
                {
                    // Turno del usuario
                    if(primerTurno == 1){
                        Console.WriteLine("Comienza atacando " + peleadorUsuario.Datos.Nombre);
                    }
                    AtaqueEspecial(peleadorUsuario, contrincante);
                    // Cambia de turno
                    numeroRandom = 0;
                }
                else
                {
                    // Turno del contrincante
                    if(primerTurno == 1){
                        Console.WriteLine("Comienza atacando " + contrincante.Datos.Nombre);
                    }
                    DefensaEspecial(contrincante, peleadorUsuario);
                    // Cambia de turno
                    numeroRandom = 1;
                }
                primerTurno++;
            }

            // Retorna el ganador
            if (peleadorUsuario.Caracteristicas.Salud <= 0)
            {
                contrincante.Caracteristicas.Salud = 100;
                return contrincante;
            }
            else
            {
                peleadorUsuario.Caracteristicas.Salud = 100;
                return peleadorUsuario;
            }

        }

        private static void AtaqueEspecial(Personaje atacante, Personaje defensor)
        {
            Console.WriteLine("\nAtaque Especial");
            int danio = devolverDanio(atacante);
            Console.WriteLine("Danio = " + danio);
            bool respuesta = MostrarResultados.MostrarResultadosPreguntas();

            if (respuesta)
            {
                danio *= 5;
                Console.WriteLine("Obtienes un buffo, aprovechalo!");
                defensor.Caracteristicas.Salud = defensor.Caracteristicas.Salud - danio;
                if (defensor.Caracteristicas.Salud < 0)
                {
                    defensor.Caracteristicas.Salud = 0;
                }
                Console.WriteLine($"\n{atacante.Datos.Nombre} ataca a {defensor.Datos.Nombre} y causa {danio} puntos de daño. Salud restante de {defensor.Datos.Nombre}: {defensor.Caracteristicas.Salud}");
            }
            else
            {
                Console.WriteLine("Dejaste escapar una gran oportunidad");
                defensor.Caracteristicas.Salud = defensor.Caracteristicas.Salud - danio;
                if (defensor.Caracteristicas.Salud < 0)
                {
                    defensor.Caracteristicas.Salud = 0;
                }
                Console.WriteLine($"\n{atacante.Datos.Nombre} ataca a {defensor.Datos.Nombre} y causa {danio} puntos de daño. Salud restante de {defensor.Datos.Nombre}: {defensor.Caracteristicas.Salud}");
            }

        }

        private static void DefensaEspecial(Personaje atacante, Personaje defensor)
        {
            Console.WriteLine("\nDefensa Especial");
            bool respuesta = MostrarResultados.MostrarResultadosPreguntas();
            int danio = devolverDanio(atacante);
            Console.WriteLine("Danio = " + danio);

            if (respuesta)
            {
                danio /= 2;
                Console.WriteLine("Los dioses estan de tu lado");
                defensor.Caracteristicas.Salud = defensor.Caracteristicas.Salud - danio;
                if (defensor.Caracteristicas.Salud < 0)
                {
                    defensor.Caracteristicas.Salud = 0;
                }
                Console.WriteLine($"\n{atacante.Datos.Nombre} ataca a {defensor.Datos.Nombre} y causa {danio} puntos de daño. Salud restante de {defensor.Datos.Nombre}: {defensor.Caracteristicas.Salud}");
            }
            else
            {
                Console.WriteLine("Preparate para recibir el ataque");
                defensor.Caracteristicas.Salud = defensor.Caracteristicas.Salud - danio;
                if (defensor.Caracteristicas.Salud < 0)
                {
                    defensor.Caracteristicas.Salud = 0;
                }
                Console.WriteLine($"\n{atacante.Datos.Nombre} ataca a {defensor.Datos.Nombre} y causa {danio} puntos de daño. Salud restante de {defensor.Datos.Nombre}: {defensor.Caracteristicas.Salud}");
            }

        }


    }
}