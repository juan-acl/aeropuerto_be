using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("CARGA_UBICACION")]
    public class CargaUbicacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_CARGA_UB")]
        public int IdCargaUb { get; set; }
        [Column("ID_ENVIO")]
        public int IdEnvio { get; set; }
        [Column("ID_BODEGA")]
        public int IdBodega { get; set; }
        [Column("PASILLO")]
        public string Pasillo { get; set; } = null!;
        [Column("ESTANTE")]
        public string Estante { get; set; } = null!;
        [Column("FECHA_INGRESO")]
        public DateTime FechaIngreso { get; set; }
        [Column("FECHA_SALIDA")]
        public DateTime? FechaSalida { get; set; }
    }
}
