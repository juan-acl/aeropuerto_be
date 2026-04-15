using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("RESPALDOS_SISTEMA")]
    public class RespaldosSistema
    {
        
        [Key]
        [Column("ID_RESPALDO")]
        public decimal IdRespaldo { get; set; }
        
        [Column("FECHA_RESPALDO")]
        public DateTime? FechaRespaldo { get; set; }
        
        [Column("TIPO_RESPALDO")]
        public string? TipoRespaldo { get; set; }
        
        [Column("TAMANO_MB")]
        public decimal? TamanoMb { get; set; }
        
        [Column("UBICACION_RESPALDO")]
        public string? UbicacionRespaldo { get; set; }
        
        [Column("NOMBRE_ARCHIVO")]
        public string? NombreArchivo { get; set; }
        
        [Column("VERIFICADO")]
        public decimal? Verificado { get; set; }
        
        [Column("FECHA_VERIFICACION")]
        public DateTime? FechaVerificacion { get; set; }
        
        [Column("REALIZADO_POR")]
        public decimal? RealizadoPor { get; set; }
        
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
        
        [Column("FOREIGN")]
        public decimal? Foreign { get; set; }
    }
}
