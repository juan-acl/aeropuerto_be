using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("OBJETOS_ENTREGADOS")]
    public class ObjetosEntregadosModel
    {
        [Key]
        [Column("ID_ENTREGA")]
        public int IdEntrega { get; set; }

        [Column("ID_OBJETO")]
        public int? IdObjeto { get; set; }

        [Column("ID_PASAJERO")]
        public int? IdPasajero { get; set; }

        [Column("FECHA_ENTREGA")]
        public DateTime? FechaEntrega { get; set; }

        [Column("DOCUMENTO_IDENTIFICACION")]
        public string? DocumentoIdentificacion { get; set; }

        [Column("FIRMA_DIGITAL")]
        public byte[]? FirmaDigital { get; set; }

        [Column("ENTREGADO_POR")]
        public string? EntregadoPor { get; set; }

        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
    }
}