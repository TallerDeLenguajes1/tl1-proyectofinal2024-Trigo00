namespace Personajes
{
    public class Datos
    {
        private string nombre;
        private string raza;
        private string genero;
        private double ki;
        private string descripcion;
        private string paisOrigen;

        public string Nombre { get => nombre; }
        public string Raza { get => raza; }
        public string Genero { get => genero; }
        public double Ki { get => ki; set => ki = value; }
        public string Descripcion { get => descripcion; }
        public string PaisOrigen { get => paisOrigen; }
    }

    public class Caracteristicas
    {

        private int fuerza;
        private int salud;
        private int velocidad;
        private int agilidad;
        private int resistencia;
        private int energia;
        private int transformacion;

        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Salud { get => salud; set => salud = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Agilidad { get => agilidad; set => agilidad = value; }
        public int Resistencia { get => resistencia; set => resistencia = value; }
        public int Energia { get => energia; set => energia = value; }
        public int Transformacion { get => transformacion; set => transformacion = value; }
    }

    public enum generoPj
    {
        Femenino,
        Masculino
    }
}