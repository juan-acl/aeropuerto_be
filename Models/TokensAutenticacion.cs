using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("TOKENS_AUTENTICACION")]
    public class TokensAutenticacion
    {
        
        [Key]
        [Column("ID_TOKEN")]
        public decimal IdToken { get; set; }
        
        [Column("ID_USUARIO_SISTEMA")]
        public decimal IdUsuarioSistema { get; set; }
        
        [Column("TOKEN")]
        public string Token { get; set; } = null!;
        
        [Column("TIPO_TOKEN")]
        public string? TipoToken { get; set; }
        
        [Column("FECHA_EMISION")]
        public DateTime? FechaEmision { get; set; }
        
        [Column("FECHA_EXPIRACION")]
        public DateTime FechaExpiracion { get; set; }
        
        [Column("ULTIMO_USO")]
        public DateTime? UltimoUso { get; set; }
        
        [Column("IP_CREACION")]
        public string? IpCreacion { get; set; }
        
        [Column("DISPOSITIVO_CREACION")]
        public string? DispositivoCreacion { get; set; }
        
        [Column("REVOCADO")]
        public decimal? Revocado { get; set; }
        
        [Column("FECHA_REVOCACION")]
        public DateTime? FechaRevocacion { get; set; }
        
        [Column("MOTIVO_REVOCACION")]
        public string? MotivoRevocacion { get; set; }
        
        [Column("FOREIGN")]
        public decimal? Foreign { get; set; }
    }
}
