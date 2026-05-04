using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("CAMPANAS_MARKETING")]
    public class CampanasMarketing
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_CAMPANA_MARKETING")]
        public int IdCampanaMarketing { get; set; }
        
        [Column("NOMBRE_CAMPANA")]
        public string NombreCampana { get; set; } = null!;
        
        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }
        
        [Column("TIPO_CAMPANA")]
        public string? TipoCampana { get; set; }
        
        [Column("OBJETIVO")]
        public string? Objetivo { get; set; }
        
        [Column("FECHA_INICIO")]
        public DateTime FechaInicio { get; set; }
        
        [Column("FECHA_FIN")]
        public DateTime FechaFin { get; set; }
        
        [Column("PRESUPUESTO")]
        public decimal? Presupuesto { get; set; }
        
        [Column("MONEDA")]
        public string? Moneda { get; set; }
        
        [Column("COSTO_REAL")]
        public decimal? CostoReal { get; set; }
        
        [Column("PUBLICO_OBJETIVO")]
        public string? PublicoObjetivo { get; set; }
        
        [Column("SEGMENTO_OBJETIVO")]
        public string? SegmentoObjetivo { get; set; }
        
        [Column("ACTIVA")]
        public decimal? Activa { get; set; }
        
        [Column("RESPONSABLE")]
        public decimal? Responsable { get; set; }
        
        [Column("RESULTADOS")]
        public string? Resultados { get; set; }
    }
}

