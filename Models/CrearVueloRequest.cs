namespace Aeropuerto.Backend.Models
{
    public class CrearVueloRequest
    {
        public int IdPrograma { get; set; }
        public DateTime FechaVuelo { get; set; }
        public DateTime HoraSalida { get; set; }
        public DateTime HoraLlegada { get; set; }
        public int IdModeloAvion { get; set; }
        public string MatriculaAvion { get; set; }
    }
}
