using System.Text.Json;
using Personajes;

namespace ManejoJson
{
    public class Json
    {
        public static void convertirEnJson(List<Personaje> misPersonajes, string nombreArchivo)
        {
            // SerializO la lista de personajes a JSON
            string jsonString = JsonSerializer.Serialize(misPersonajes, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(nombreArchivo, jsonString);
            
        }
    }
}