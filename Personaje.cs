using Personajes;

namespace Personaje
{
    
    public class Personaje
    {
        private Datos datos;
        private Caracteristicas caracteristicas;

        public Datos Datos { get => datos; set => datos = value; }
        public Caracteristicas Caracteristicas { get => caracteristicas; set => caracteristicas = value; }
    }

}