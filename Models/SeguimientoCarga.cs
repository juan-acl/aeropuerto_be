using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("SEGUIMIENTO_CARGA")]
    public class SeguimientoCarga
    {
        [Key]
        [Column("ID_SEGUIMIENTO")]
        public int id_seguimiento { get; set; }

        [Column("ID_ENVIO")]
        public int? id_envio { get; set; }

        [Column("FECHA_HORA")]
        public DateTime? fecha_hora { get; set; }

        [Column("UBICACION")]
        public string? ubicacion { get; set; }

        [Column("ESTADO")]
        public string? estado { get; set; }

        [Column("RESPONSABLE")]
        public string? responsable { get; set; }

        [Column("OBSERVACIONES")]
        public string? observaciones { get; set; }

        [Column("TEMPERATURA_REGISTRADA")]
        public decimal? temperatura_registrada { get; set; }

        [Column("INCIDENTE")]
        public int? incidente { get; set; }
    }
}