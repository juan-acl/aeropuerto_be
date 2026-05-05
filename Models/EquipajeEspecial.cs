using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("EQUIPAJE_ESPECIAL")]
    public class EquipajeEspecialModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_EQUIPAJE_ESPECIAL")]
        public int IdEquipajeEspecial { get; set; }

        [Column("ID_RESERVA")]
        public int IdReserva { get; set; }

        [Column("TIPO_EQUIPAJE")]
        public string TipoEquipaje { get; set; } = null!; // DEPORTIVO, INSTRUMENTO_MUSICAL, etc.

        [Column("PESO_KG")]
        public decimal PesoKg { get; set; }

        [Column("DIMENSIONES")]
        public string? Dimensiones { get; set; }

        [Column("CONTENIDO")]
        public string? Contenido { get; set; }

        [Column("REQUIERE_AUTORIZACION")]
        public int RequiereAutorizacion { get; set; } = 1;

        [Column("AUTORIZADO")]
        public int Autorizado { get; set; } = 0;

        [Column("COSTO_ADICIONAL")]
        public decimal CostoAdicional { get; set; }
    }
}
