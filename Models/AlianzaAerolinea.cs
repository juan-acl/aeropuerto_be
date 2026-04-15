using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("ALIANZAS_AEROLINEAS")] 
    public class AlianzaAerolineaModel
    {
        [Key]
        [Column("ID_ALIANZA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAlianza { get; set; }

        [Column("NOMBRE_ALIANZA")]
        [Required]
        [StringLength(50)]
        public string NombreAlianza { get; set; } = null!;

        [Column("FECHA_FUNDACION")]
        public DateTime? FechaFundacion { get; set; }

        [Column("SEDE")]
        [StringLength(100)]
        public string? Sede { get; set; }

        [Column("NUMERO_MIEMBROS")]
        public int? NumeroMiembros { get; set; }

        [Column("DESCRIPCION")]
        [StringLength(500)]
        public string? Descripcion { get; set; }
    }
}