using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("TARIFAS_ESPECIALES")]
    public class TarifasEspecialesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_TARIFA")]
        public int IdTarifa { get; set; }

        [Column("ID_AEROLINEA")]
        public int IdAerolinea { get; set; }

        [Column("NOMBRE_TARIFA")]
        public string NombreTarifa { get; set; } = null!;

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }

        [Column("CONDICIONES")]
        public string? Condiciones { get; set; }

        [Column("DESCUENTO_PORCENTAJE")]
        public decimal DescuentoPorcentaje { get; set; }

        [Column("FECHA_INICIO")]
        public DateTime? FechaInicio { get; set; }

        [Column("FECHA_FIN")]
        public DateTime? FechaFin { get; set; }

        [Column("ACTIVA")]
        public int Activa { get; set; } = 1;
    }
}
