using System.Text.Json;

namespace CuantoSabes
{
    public class PreguntasyRespuestas
    {
        public string Pregunta { get; set; }
        public List<string> Respuestas { get; set; }
        public int RespuestaCorrectaIndex { get; set; } // Índice de la respuesta correcta

        public bool EsRespuestaCorrecta(int indiceRespuestaElegida)
        {
            return indiceRespuestaElegida == RespuestaCorrectaIndex;
        }
    }

    public class CargandoPreguntasYRespuestas
    {
        public List<PreguntasyRespuestas> ListaPreguntas;

        public CargandoPreguntasYRespuestas(string nombreArchivo)
        {
            ListaPreguntas = CargarPreguntasDesdeJson(nombreArchivo);
        }

        private List<PreguntasyRespuestas> CargarPreguntasDesdeJson(string nombreArchivo)
        {
            var jsonData = File.ReadAllText(nombreArchivo);
            return JsonSerializer.Deserialize<List<PreguntasyRespuestas>>(jsonData);
        }

        public PreguntasyRespuestas ObtenerPreguntaAleatoria()
        {
            if (ListaPreguntas == null || ListaPreguntas.Count == 0)
            {
                Console.WriteLine("La lista de preguntas está vacía o no se ha inicializado correctamente.");

                return null;
            }

            Random random = new Random();
            int index = random.Next(ListaPreguntas.Count); // Genero un número aleatorio entre 0 y el tamaño de la lista
            return ListaPreguntas[index];
        }
    }

    public class MostrarResultados
    {
        public static bool MostrarResultadosPreguntas()
        {
            string nombreArchivo = "Json/Preguntas.json";

            if (!File.Exists(nombreArchivo))
            {
                Console.WriteLine("El archivo de preguntas no existe.");
                return false;
            }

            // Creo una instancia de CargandoPreguntasYRespuestas
            CargandoPreguntasYRespuestas cargador;
            try
            {
                cargador = new CargandoPreguntasYRespuestas(nombreArchivo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar las preguntas desde el archivo JSON: {ex.Message}");
                return false;
            }

            // Obtengo una pregunta aleatoria
            PreguntasyRespuestas preguntaAleatoria;
            try
            {
                preguntaAleatoria = cargador.ObtenerPreguntaAleatoria();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            // Muestro la pregunta aleatoria
            Console.WriteLine(preguntaAleatoria.Pregunta);

            // Muestro respuestas
            for (int i = 0; i < preguntaAleatoria.Respuestas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {preguntaAleatoria.Respuestas[i]}");
            }

            // Solicito al usuario que elija una respuesta
            Console.Write("Elige una respuesta (1-3): ");
            int opcionElegida;
            while (!int.TryParse(Console.ReadLine(), out opcionElegida) || opcionElegida < 1 || opcionElegida > preguntaAleatoria.Respuestas.Count)
            {
                Console.WriteLine($"Opción inválida. Debes elegir una respuesta válida (1-{preguntaAleatoria.Respuestas.Count}).");
                Console.Write("Elige una respuesta (1-3): ");
            }

            // Valido la opción elegida
            int indiceRespuestaElegida = opcionElegida - 1;
            bool esRespuestaCorrecta = preguntaAleatoria.EsRespuestaCorrecta(indiceRespuestaElegida);

            if (esRespuestaCorrecta)
            {
                Console.WriteLine("Puar: ¡Respuesta correcta!");
                return true;
            }
            else
            {
                Console.WriteLine("Puar: Respuesta incorrecta.");
                return false;
            }
        }
    }
}