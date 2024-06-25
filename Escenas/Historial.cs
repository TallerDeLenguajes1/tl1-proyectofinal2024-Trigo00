using Personajes;

namespace Historial
{
    public class HistorialGanadores
    {

        public Personaje Ganador { get; set; }
        public DateTime Hora { get; set; }

        public HistorialGanadores(Personaje ganador, DateTime hora)
        {
            Ganador = ganador;
            Hora = hora;
        }

        public static void cargarHistorial(Personaje PersonajeGanador, List<HistorialGanadores> listaHistorial)
        {
            DateTime horaActual = DateTime.Now;
            HistorialGanadores datos = new HistorialGanadores(PersonajeGanador, horaActual);
            listaHistorial.Add(datos);
        }

        public static void mostrarListado(List<HistorialGanadores> listado){
            Console.WriteLine("Ganadores recientes");
            foreach (var ganador in listado)
            {
                Console.WriteLine(ganador.Hora + ":" + ganador.Ganador.Datos.Nombre);
            }
        }
    }


}