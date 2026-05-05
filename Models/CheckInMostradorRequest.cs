namespace Aeropuerto.Backend.Models
{
    public class CheckInMostradorRequest
    {
        public string CodigoReserva { get; set; } = null!;
        public string NumeroDocumento { get; set; } = null!;
        public string NumeroAsiento { get; set; } = null!;
        public decimal EquipajeFacturado { get; set; } // kg
        public decimal EquipajeMano { get; set; }      // kg
        public string TipoVuelo { get; set; } = null!;          // 'Nacional' o 'Internacional'
        public int VisaValida { get; set; }            // 1 o 0
    }
}
