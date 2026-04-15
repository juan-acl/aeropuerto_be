using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("CHOFERES_TRANSPORTE")]
    public class ChoferesTransporte
    {
        
        [Key]
        [Column("ID_CHOFER_TRANSPORTE")]
        public int IdChoferTransporte { get; set; }
        
        [Column("NOMBRES")]
        public string Nombres { get; set; } = null!;
        
        [Column("APELLIDOS")]
        public string Apellidos { get; set; } = null!;
        
        [Column("TIPO_DOCUMENTO")]
        public string? TipoDocumento { get; set; }
        
        [Column("NUMERO_DOCUMENTO")]
        public string? NumeroDocumento { get; set; }
        
        [Column("LICENCIA_CONDUCIR")]
        public string LicenciaConducir { get; set; } = null!;
        
        [Column("CATEGORIA_LICENCIA")]
        public string? CategoriaLicencia { get; set; }
        
        [Column("FECHA_VENCIMIENTO_LICENCIA")]
        public DateTime FechaVencimientoLicencia { get; set; }
        
        [Column("TELEFONO")]
        public string? Telefono { get; set; }
        
        [Column("EMAIL")]
        public string? Email { get; set; }
        
        [Column("FECHA_CONTRATACION")]
        public DateTime? FechaContratacion { get; set; }
        
        [Column("EMPRESA_CONTRATANTE")]
        public string? EmpresaContratante { get; set; }
        
        [Column("CERTIFICACIONES")]
        public string? Certificaciones { get; set; }
        
        [Column("IDIOMAS")]
        public string? Idiomas { get; set; }
        
        [Column("DISPONIBLE")]
        public decimal? Disponible { get; set; }
        
        [Column("ACTIVO")]
        public decimal? Activo { get; set; }
    }
}
