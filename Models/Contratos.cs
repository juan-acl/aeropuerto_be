using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("CONTRATOS")]
    public class Contratos
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_CONTRATO")]
        public int IdContrato { get; set; }
        
        [Column("NUMERO_CONTRATO")]
        public string NumeroContrato { get; set; } = null!;
        
        [Column("NOMBRE_CONTRATO")]
        public string NombreContrato { get; set; } = null!;
        
        [Column("TIPO_CONTRATO")]
        public string? TipoContrato { get; set; }
        
        [Column("CONTRAPARTE_NOMBRE")]
        public string ContraparteNombre { get; set; } = null!;
        
        [Column("CONTRAPARTE_DOCUMENTO")]
        public string? ContraparteDocumento { get; set; }
        
        [Column("FECHA_FIRMA")]
        public DateTime FechaFirma { get; set; }
        
        [Column("FECHA_INICIO")]
        public DateTime FechaInicio { get; set; }
        
        [Column("FECHA_FIN")]
        public DateTime FechaFin { get; set; }
        
        [Column("FECHA_TERMINACION_ANTICIPADA")]
        public DateTime? FechaTerminacionAnticipada { get; set; }
        
        [Column("MONTO_TOTAL")]
        public decimal? MontoTotal { get; set; }
        
        [Column("MONEDA")]
        public string? Moneda { get; set; }
        
        [Column("FORMA_PAGO")]
        public string? FormaPago { get; set; }
        
        [Column("OBJETO_CONTRACTUAL")]
        public string? ObjetoContractual { get; set; }
        
        [Column("CLAUSULAS_PRINCIPALES")]
        public string? ClausulasPrincipales { get; set; }
        
        [Column("DOCUMENTO_CONTRATO")]
        public byte[]? DocumentoContrato { get; set; }
        
        [Column("RENOVACION_AUTOMATICA")]
        public decimal? RenovacionAutomatica { get; set; }
        
        [Column("NOTIFICAR_VENCIMIENTO_DIAS")]
        public decimal? NotificarVencimientoDias { get; set; }
        
        [Column("ESTADO")]
        public string? Estado { get; set; }
        
        [Column("ADMINISTRADOR_CONTRATO")]
        public decimal? AdministradorContrato { get; set; }
        
        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
    }
}

