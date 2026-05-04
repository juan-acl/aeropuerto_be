using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Aeropuerto.Backend.Models
{
    [Table("TARIFAS_VUELO")]
    public class TarifaVueloModel
    {
        [Key][Column("ID_TARIFA")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTarifa { get; set; }
        [Column("ID_PROGRAMA")]
        public int IdPrograma { get; set; }
        [Column("CLASE_SERVICIO")][StringLength(20)]
        public string? ClaseServicio { get; set; }   // ECONOMICA|EJECUTIVA|PRIMERA_CLASE
        [Column("PRECIO_BASE")]
        public decimal PrecioBase { get; set; }
        [Column("IMPUESTOS")]
        public decimal? Impuestos { get; set; }
        [Column("CARGOS_ADICIONALES")]
        public decimal? CargosAdicionales { get; set; }
        [Column("MONEDA")][StringLength(5)]
        public string Moneda { get; set; } = "GTQ";
        [Column("DISPONIBILIDAD")]
        public int? Disponibilidad { get; set; }
        [Column("FECHA_INICIO_VIGENCIA")]
        public DateTime? FechaInicioVigencia { get; set; }
        [Column("FECHA_FIN_VIGENCIA")]
        public DateTime? FechaFinVigencia { get; set; }
        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}
