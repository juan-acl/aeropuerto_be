namespace Aeropuerto.Backend.Models
{
    public class CheckInMostradorRequest
    {
        public string CodigoReserva { get; set; }
        public string NumeroDocumento { get; set; }
        public string NumeroAsiento { get; set; }
        public decimal EquipajeFacturado { get; set; } // kg
        public decimal EquipajeMano { get; set; }      // kg
        public string TipoVuelo { get; set; }          // 'Nacional' o 'Internacional'
        public int VisaValida { get; set; }            // 1 o 0
    }
}
