namespace Aeropuerto.Backend.Models
{
    public class PagoBoletoRequest
    {
        public int IdReserva { get; set; }
        public int IdMetodoPago { get; set; }
        public decimal Monto { get; set; }
        public string Moneda { get; set; } = null!;
        public string CodigoTransaccion { get; set; } = null!;
        public byte[] Comprobante { get; set; } // Representa el BLOB de Oracle
    }
}
