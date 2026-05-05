namespace Aeropuerto.Backend.Models
{
    public class RegistrarAeronaveRequest
    {
        public string Matricula { get; set; } = null!;
        public string CodigoIcaoTipo { get; set; } = null!; // CHAR(4) usualmente
        public int IdAerolinea { get; set; }
        public string NombreAeronave { get; set; } = null!;
        public string Configuracion { get; set; } = null!; // String conteniendo el JSON
        public int NumeroMotores { get; set; }
        public int AnioFabricacion { get; set; }
    }
}
