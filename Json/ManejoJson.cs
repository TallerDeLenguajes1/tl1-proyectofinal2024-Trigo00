using System.Text.Json;
using Personajes;

namespace ManejoJson
{
    public class PersonajesJson
    {
        public static void GenerarJsonPersonajes(List<Personaje> misPersonajes, string nombreArchivo)
        {
            // Creo el archivo si no existe
            if (!File.Exists(nombreArchivo))
            {
                var opciones = new JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, //Para evitar los acentos
                    WriteIndented = true
                };

                // Convierto la lista de personajes a JSON
                string jsonString = JsonSerializer.Serialize(misPersonajes, opciones);

                // Guardo el JSON en el archivo
                File.WriteAllText(nombreArchivo, jsonString);
            }

        }
    }
}