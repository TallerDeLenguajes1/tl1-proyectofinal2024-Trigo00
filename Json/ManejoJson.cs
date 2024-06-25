using System.Text.Json;
using Personajes;

namespace ManejoJson
{
    public class PersonajesJson
    {

        public static bool Existe(string nombreArchivo)
        {
            if(File.Exists(nombreArchivo))
            {
                return true;
            }else{
                return false;
            }
        }
        public static void GuardarPersonajes(List<Personaje> misPersonajes, string nombreArchivo)
        {
            // Creo el directorio si no existe
            string directorio = Path.GetDirectoryName(nombreArchivo);
            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }

            // Configuración para formatear el JSON
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

        //No uso esta funcion pero la tengo porque debo hacerla
        public static List<Personaje> LeerPersonajes(string nombreArchivo)
        {
            string dev = File.ReadAllText(nombreArchivo);
            return JsonSerializer.Deserialize<List<Personaje>>(dev);
        }
    }
}