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
}