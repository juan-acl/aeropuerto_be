using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("ADUANAS_CARGA")]
    public class AduanaCarga
    {
        [Key]
        [Column("ID_REGISTRO_ADUANAL")]
        public int id_registro_aduanal { get; set; }

        [Column("ID_ENVIO")]
        public int? id_envio { get; set; }

        [Column("TIPO_OPERACION")]
        public string? tipo_operacion { get; set; } // IMPORTACION, EXPORTACION, TRANSITO

        [Column("FECHA_REVISION")]
        public DateTime? fecha_revision { get; set; }

        [Column("ESTADO_ADUANAL")]
        public string? estado_aduanal { get; set; } // EN_TRAMITE, LIBERADO, RETENIDO, INCAUTADO

        [Column("INSPECTOR_ASIGNADO")]
        public int? inspector_asignado { get; set; }

        [Column("DOCUMENTOS_VERIFICADOS")]
        public int? documentos_verificados { get; set; }

        [Column("IMPUESTO_APLICADO")]
        public decimal? impuesto_aplicado { get; set; }

        [Column("MONEDA_IMPUESTO")]
        public string? moneda_impuesto { get; set; }

        [Column("FECHA_LIBERACION")]
        public DateTime? fecha_liberacion { get; set; }

        [Column("OBSERVACIONES")]
        public string? observaciones { get; set; }
    }
}