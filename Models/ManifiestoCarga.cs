using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("MANIFIESTO_CARGA")]
    public class ManifiestoCarga
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_MANIFIESTO")]
        public int IdManifiesto { get; set; }
        [Column("ID_VUELO")]
        public int IdVuelo { get; set; }
        [Column("FECHA_CREACION")]
        public DateTime FechaCreacion { get; set; }
        [Column("ESTADO")]
        public string Estado { get; set; } = "CERRADO";
        [Column("PESO_TOTAL")]
        public decimal PesoTotal { get; set; }
    }
}
