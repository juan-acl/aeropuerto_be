using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("CONDICIONES_PISTA_TIEMPO_REAL")]
    public class CondicionesPistaTiempoReal
    {
        
        [Key]
        [Column("ID_CONDICION_PISTA")]
        public decimal IdCondicionPista { get; set; }
        
        [Column("ID_PISTA")]
        public decimal IdPista { get; set; }
        
        [Column("FECHA_HORA_REGISTRO")]
        public DateTime? FechaHoraRegistro { get; set; }
        
        [Column("ESTADO_PISTA")]
        public string? EstadoPista { get; set; }
        
        [Column("CONDICION_SUPERFICIE")]
        public string? CondicionSuperficie { get; set; }
        
        [Column("COEFICIENTE_FRICCION")]
        public decimal? CoeficienteFriccion { get; set; }
        
        [Column("VISIBILIDAD_METROS")]
        public decimal? VisibilidadMetros { get; set; }
        
        [Column("TECHONUBES_PIES")]
        public decimal? TechonubesPies { get; set; }
        
        [Column("VIENTO_DIRECCION_GRADOS")]
        public decimal? VientoDireccionGrados { get; set; }
        
        [Column("VIENTO_VELOCIDAD_NUDOS")]
        public decimal? VientoVelocidadNudos { get; set; }
        
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
        
        [Column("REGISTRADO_POR")]
        public decimal? RegistradoPor { get; set; }
        

    }
}
