using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("GRUPOS_EMBARQUE")]
    public class GruposEmbarqueModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_GRUPO_EMBARQUE")]
        public int IdGrupoEmbarque { get; set; }

        [Column("ID_VUELO")]
        public int IdVuelo { get; set; }

        [Column("NUMERO_GRUPO")]
        public int NumeroGrupo { get; set; }

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }

        [Column("ORDEN")]
        public int Orden { get; set; }

        [Column("TIEMPO_ESTIMADO")]
        public DateTime? TiempoEstimado { get; set; }
    }
}
