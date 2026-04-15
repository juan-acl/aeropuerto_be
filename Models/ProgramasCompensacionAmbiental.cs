using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("PROGRAMAS_COMPENSACION_AMBIENTAL")]
    public class ProgramasCompensacionAmbiental
    {
        
        [Key]
        [Column("ID_PROGRAMA_COMPENSACION")]
        public int IdProgramaCompensacion { get; set; }
        
        [Column("NOMBRE_PROGRAMA")]
        public string NombrePrograma { get; set; } = null!;
        
        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }
        
        [Column("TIPO_PROGRAMA")]
        public string? TipoPrograma { get; set; }
        
        [Column("FECHA_INICIO")]
        public DateTime? FechaInicio { get; set; }
        
        [Column("FECHA_FIN")]
        public DateTime? FechaFin { get; set; }
        
        [Column("INVERSION_TOTAL")]
        public decimal? InversionTotal { get; set; }
        
        [Column("MONEDA")]
        public string? Moneda { get; set; }
        
        [Column("CO2_COMPENSADO_ESTIMADO_KG")]
        public decimal? Co2CompensadoEstimadoKg { get; set; }
        
        [Column("ENTIDAD_EJECUTORA")]
        public string? EntidadEjecutora { get; set; }
        
        [Column("ACTIVO")]
        public decimal? Activo { get; set; }
        
        [Column("CONTACTO_RESPONSABLE")]
        public string? ContactoResponsable { get; set; }
    }
}
