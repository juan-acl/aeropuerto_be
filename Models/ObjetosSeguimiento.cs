using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("OBJETOS_SEGUIMIENTO")]
    public class ObjetosSeguimientoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_SEGUIMIENTO")]
        public int IdSeguimiento { get; set; }

        [Column("ID_OBJETO")]
        public int? IdObjeto { get; set; }

        [Column("FECHA_MOVIMIENTO")]
        public DateTime? FechaMovimiento { get; set; }

        [Column("UBICACION")]
        public string? Ubicacion { get; set; }

        [Column("RESPONSABLE")]
        public string? Responsable { get; set; }

        [Column("ACCION")]
        public string? Accion { get; set; } // Ejemplo: TRASLADO, INVENTARIADO, ENTREGADO

        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
    }
}
