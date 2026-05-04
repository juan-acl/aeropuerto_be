using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("BITACORA_CAMBIOS_DB")]
    public class BitacoraCambiosDb
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_BITACORA_CAMBIO")]
        public decimal IdBitacoraCambio { get; set; }
        
        [Column("ID_USUARIO_SISTEMA")]
        public decimal? IdUsuarioSistema { get; set; }
        
        [Column("TIMESTAMP_CAMBIO")]
        public DateTime? TimestampCambio { get; set; }
        
        [Column("TABLA_AFECTADA")]
        public string TablaAfectada { get; set; } = null!;
        
        [Column("REGISTRO_ID")]
        public decimal? RegistroId { get; set; }
        
        [Column("TIPO_OPERACION")]
        public string? TipoOperacion { get; set; }
        
        [Column("VALORES_ANTERIORES")]
        public string? ValoresAnteriores { get; set; }
        
        [Column("VALORES_NUEVOS")]
        public string? ValoresNuevos { get; set; }
        
        [Column("IP_ORIGEN")]
        public string? IpOrigen { get; set; }
        
        [Column("SESION_ID")]
        public string? SesionId { get; set; }
    }
}

