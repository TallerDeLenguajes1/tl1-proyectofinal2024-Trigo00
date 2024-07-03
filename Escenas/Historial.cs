using MenuPrincipal;
using Personajes;

namespace Historial
{
    public class HistorialGanadores
    {

        public Personaje Ganador { get; set; }
        public DateTime Hora { get; set; }

        public static void cargarHistorial(Personaje PersonajeGanador, List<HistorialGanadores> listaHistorial)
        {
            DateTime horaActual = DateTime.Now;
            HistorialGanadores datos = new HistorialGanadores(PersonajeGanador, horaActual);
            listaHistorial.Add(datos);
        }
        public static void mostrarListado(List<HistorialGanadores> listado)
        {
            Console.WriteLine("GANADORES DEL TORNEO");
            Console.WriteLine();
            if (listado.Count == 0)
            {
                Console.WriteLine("No existen ganadores del torneo");
            }
            else
            {
                foreach (var ganador in listado)
                {
                    Animaciones.misAnimaciones.AnimacionDeCargaHistorial();
                    Console.WriteLine("\r" + ganador.Hora + ": " + ganador.Ganador.Datos.Nombre);
                }
            }


            Console.WriteLine();
            string frase = "Pulse una tecla regresar al menu...";
            Console.WriteLine(frase);
            Console.CursorVisible = false;
            Console.ReadKey(true);
            Menu.MostrarOpciones(listado);
        }

        private HistorialGanadores(Personaje ganador, DateTime hora)
        {
            Ganador = ganador;
            Hora = hora;
        }

        
    }


}