using System.Text.Json;

namespace DatosApi
{
    public class PersonajeApi
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ki { get; set; }
        public string MaxKi { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Affiliation { get; set; }
        public string DeletedAt { get; set; }
    }

    public class ApiResponse
    {
        public List<PersonajeApi> Items { get; set; }
    }

    public class InfoApi
    {
        public static async Task<List<PersonajeApi>> traerInformacionApi(List<PersonajeApi> listaPersonajes)
        {
            try
            {
                HttpClient client = new HttpClient();
                var url = "https://dragonball-api.com/api/characters";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserializar la respuesta JSON en ApiResponse
                var apiResponse = JsonSerializer.Deserialize<ApiResponse>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (apiResponse != null && apiResponse.Items != null)
                {
                    foreach (var personaje in apiResponse.Items)
                    {
                        listaPersonajes.Add(personaje);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }

            return listaPersonajes;
        }
    }

}