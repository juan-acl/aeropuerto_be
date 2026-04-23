using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("ENVIO_CARGA")]
    public class EnvioCarga
    {
        [Key]
        [Column("ID_ENVIO")]
        public int IdEnvio { get; set; }
        [Column("NUMERO_GUIA")]
        public string NumeroGuia { get; set; } = null!; // AWB (Air Waybill)
        [Column("REMITENTE")]
        public string Remitente { get; set; } = null!;
        [Column("DESTINATARIO")]
        public string Destinatario { get; set; } = null!;
        [Column("PESO")]
        public decimal Peso { get; set; }
        [Column("VOLUMEN")]
        public decimal Volumen { get; set; }
        [Column("CONTENIDO")]
        public string Contenido { get; set; } = null!;
        [Column("FECHA_ENVIO")]
        public DateTime FechaEnvio { get; set; }
    }
}