using System;
using System.Collections.Generic;

namespace CuantoSabes
{
    public class PreguntasyRespuestas
    {
        public string Pregunta { get; set; }
        public List<string> Respuestas { get; set; }
        public int RespuestaCorrectaIndex { get; set; } // Índice de la respuesta correcta

        public PreguntasyRespuestas(string pregunta, List<string> respuestas, int respuestaCorrectaIndex)
        {
            Pregunta = pregunta;
            Respuestas = respuestas;
            RespuestaCorrectaIndex = respuestaCorrectaIndex;
        }

        // Método para verificar si una respuesta es la correcta
        public bool EsRespuestaCorrecta(int indiceRespuestaElegida)
        {
            return indiceRespuestaElegida == RespuestaCorrectaIndex;
        }
    }

    public class CargandoPreguntasYRespuestas
    {
        // Crear una lista de PreguntasyRespuestas como un campo de clase
        public List<PreguntasyRespuestas> ListaPreguntas;

        // Constructor para inicializar la lista y agregar elementos
        public CargandoPreguntasYRespuestas()
        {
            ListaPreguntas = new List<PreguntasyRespuestas>
            {
                new PreguntasyRespuestas("Como se llama la madre de Goku?", new List<string> { "Gine", "Apple", "Nuts" }, 0), // Respuesta correcta: Gine (índice 0)
                new PreguntasyRespuestas("Quien mato a Nappa?", new List<string> { "Vegeta", "Goku", "Krillin" }, 0), // Respuesta correcta: Vegeta (índice 0)
                new PreguntasyRespuestas("Como se llama la reencarnacion buena de Majin Boo?", new List<string> { "Uub", "Pan", "Bra" }, 0), // Respuesta correcta: Uub (índice 0)
                new PreguntasyRespuestas("Quien mato al padre de Goku?", new List<string> { "Freezer", "Rey Vegeta", "Bills" }, 1), // Respuesta correcta: Rey Vegeta (índice 1)
                new PreguntasyRespuestas("Quien muere para que Gohan se transforme en Ssj 2?", new List<string> { "Androide 16", "Krillin", "Piccolo" }, 0), // Respuesta correcta: Androide 16 (índice 0)
                new PreguntasyRespuestas("De las esferas del dragon, cual es el numero de la suerte de Goku?", new List<string> { "7", "2", "4" }, 0), // Respuesta correcta: 7 (índice 0)
                new PreguntasyRespuestas("Como se llama el dragon en el planeta Namekusei?", new List<string> { "Shenron", "Porunga", "Omega Porunga" }, 1), // Respuesta correcta: Porunga (índice 1)
                new PreguntasyRespuestas("Quien derroto al Androide 19?", new List<string> { "Trunks", "Goku", "Vegeta" }, 2), // Respuesta correcta: Vegeta (índice 2)
                new PreguntasyRespuestas("Cuantas veces le cortaron la cola a Gohan?", new List<string> { "1", "2", "Nunca" }, 2), // Respuesta correcta: Nunca (índice 2)
                new PreguntasyRespuestas("Cuál es el seudónimo que utiliza Píccoro para registrarse en el torneo de las artes marciales?", new List<string> { "Majunia", "Daimakú", "Ninguno" }, 0), // Respuesta correcta: Ninguno (índice 0)
                new PreguntasyRespuestas("Quien secuestra a Gohan?", new List<string> { "Raditz", "Cell", "Vegeta" }, 0), // Respuesta correcta: Raditz (índice 0)
                new PreguntasyRespuestas("Cuantas veces muere Goku?", new List<string> { "1", "2", "3" }, 1), // Respuesta correcta: 2 (índice 1)
                new PreguntasyRespuestas("Como se llama la nieta de Goku y Milk?", new List<string> { "Asta", "Pan", "Apu" }, 1), // Respuesta correcta: Pan (índice 1)
                new PreguntasyRespuestas("Como se llama el maestro ermitanio que vive en una torre?", new List<string> { "Maestro Karin", "Kamisama", "Gran Patriarca" }, 0), // Respuesta correcta: Maestro Karin (índice 0)
                new PreguntasyRespuestas("De quien es la tecnica Kikoho?", new List<string> { "Krillin", "Yamcha", "Tenshinhan" }, 2) // Respuesta correcta: Tenshinhan (índice 2)
            };
        }

        // Método para obtener una pregunta aleatoriamente de la lista
        public PreguntasyRespuestas ObtenerPreguntaAleatoria()
        {
            Random random = new Random();
            int index = random.Next(ListaPreguntas.Count); // Generar un número aleatorio entre 0 y el tamaño de la lista
            return ListaPreguntas[index];
        }
    }

    public class MostrarResultados
    {
        public static void MostrarResultadosPreguntas()
        {
            // Crear una instancia de CargandoPreguntasYRespuestas
            CargandoPreguntasYRespuestas cargador = new CargandoPreguntasYRespuestas();

            // Obtener una pregunta aleatoria
            PreguntasyRespuestas preguntaAleatoria = cargador.ObtenerPreguntaAleatoria();

            // Mostrar la pregunta aleatoria
            Console.WriteLine(preguntaAleatoria.Pregunta);

            // Mostrar respuestas en el orden original sin mezclar
            for (int i = 0; i < preguntaAleatoria.Respuestas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {preguntaAleatoria.Respuestas[i]}");
            }

            // Solicitar al usuario que elija una respuesta
            Console.Write("Elige una respuesta (1-3): ");
            int opcionElegida;
            while (!int.TryParse(Console.ReadLine(), out opcionElegida) || opcionElegida < 1 || opcionElegida > preguntaAleatoria.Respuestas.Count)
            {
                Console.WriteLine($"Opción inválida. Debes elegir una respuesta válida (1-{preguntaAleatoria.Respuestas.Count}).");
                Console.Write("Elige una respuesta (1-3): ");
            }

            // Validar la opción elegida
            int indiceRespuestaElegida = opcionElegida - 1;
            bool esRespuestaCorrecta = preguntaAleatoria.EsRespuestaCorrecta(indiceRespuestaElegida);

            if (esRespuestaCorrecta)
            {
                Console.WriteLine("¡Respuesta correcta!");
            }
            else
            {
                Console.WriteLine("Respuesta incorrecta.");
            }
        }
    }
}