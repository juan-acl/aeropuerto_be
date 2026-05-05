using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("GESTION_RESIDUOS")]
    public class GestionResiduos
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_RESIDUO")]
        public int IdResiduo { get; set; }
        
        [Column("FECHA_RECOLECCION")]
        public DateTime FechaRecoleccion { get; set; }
        
        [Column("TIPO_RESIDUO")]
        public string? TipoResiduo { get; set; }
        
        [Column("CANTIDAD_KG")]
        public decimal? CantidadKg { get; set; }
        
        [Column("ORIGEN")]
        public string? Origen { get; set; }
        
        [Column("EMPRESA_RECOLECTORA")]
        public string? EmpresaRecolectora { get; set; }
        
        [Column("TRATAMIENTO")]
        public string? Tratamiento { get; set; }
        
        [Column("CERTIFICADO_TRATAMIENTO")]
        public string? CertificadoTratamiento { get; set; }
        
        [Column("COSTO_TRATAMIENTO")]
        public decimal? CostoTratamiento { get; set; }
        
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
    }
}
