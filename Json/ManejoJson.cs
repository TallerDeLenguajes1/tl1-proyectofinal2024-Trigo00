using System.Text.Json;
using Personajes;

namespace ManejoJson
{
    public class PersonajesJson
    {
        public static void GuardarPersonajes(List<Personaje> misPersonajes, string nombreArchivo)
        {
            // Serializo la lista de personajes a JSON
            string jsonString = JsonSerializer.Serialize(misPersonajes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(nombreArchivo, jsonString);
        }
        //No uso esta funcion pero la tengo porque debo hacerla
        public static List<Personaje> LeerPersonajes(string nombreArchivo)
        {
            string dev = File.ReadAllText(nombreArchivo);
            return JsonSerializer.Deserialize<List<Personaje>>(dev);
        }
        //Tampoco uso esta funcion
        public static bool Existe(string nombreArchivo)
        {
            if(File.Exists(nombreArchivo))
            {
                return true;
            }else{
                return false;
            }
        }
    }
}