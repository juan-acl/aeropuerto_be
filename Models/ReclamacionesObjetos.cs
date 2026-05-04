using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("RECLAMACIONES_OBJETOS")]
    public class ReclamacionesObjetosModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_RECLAMACION")]
        public int IdReclamacion { get; set; }

        [Column("ID_PASAJERO")]
        public int? IdPasajero { get; set; }

        [Column("ID_OBJETO")]
        public int? IdObjeto { get; set; }

        [Column("FECHA_RECLAMACION")]
        public DateTime? FechaReclamacion { get; set; }

        [Column("DESCRIPCION_RECLAMACION")]
        public string? DescripcionReclamacion { get; set; }

        [Column("ESTADO")]
        public string Estado { get; set; } = "PENDIENTE"; // PENDIENTE, APROBADA, RECHAZADA

        [Column("FECHA_RESOLUCION")]
        public DateTime? FechaResolucion { get; set; }

        [Column("RESOLUCION")]
        public string? Resolucion { get; set; }

        [Column("RESUELTO_POR")]
        public string? ResueltoPor { get; set; }
    }
}
