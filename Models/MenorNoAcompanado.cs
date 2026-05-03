using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("MENORES_NO_ACOMPANADOS")]
    public class MenorNoAcompanado
    {
        [Key]
        [Column("ID_MENOR")]
        public int id_menor { get; set; }

        [Column("ID_RESERVA")]
        public int? id_reserva { get; set; }

        [Column("EDAD")]
        public int? edad { get; set; }

        [Column("NOMBRE_ENTREGA_ORIGEN")]
        public string? nombre_entrega_origen { get; set; }

        [Column("RELACION_ORIGEN")]
        public string? relacion_origen { get; set; }

        [Column("TELEFONO_ORIGEN")]
        public string? telefono_origen { get; set; }

        [Column("NOMBRE_RECOGE_DESTINO")]
        public string? nombre_recoge_destino { get; set; }

        [Column("RELACION_DESTINO")]
        public string? relacion_destino { get; set; }

        [Column("TELEFONO_DESTINO")]
        public string? telefono_destino { get; set; }

        [Column("OBSERVACIONES")]
        public string? observaciones { get; set; }
    }
}