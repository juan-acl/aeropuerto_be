namespace Aeropuerto.Backend.Models
{
    public class ReprogramarVueloRequest
    {
        public int IdVuelo { get; set; }
        public DateTime NuevaFecha { get; set; }
        public DateTime NuevaHoraSalida { get; set; }
        public DateTime NuevaHoraLlegada { get; set; }
    }
}
