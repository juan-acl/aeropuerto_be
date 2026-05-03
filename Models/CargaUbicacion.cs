using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("CARGA_UBICACION")]
    public class CargaUbicacion
    {
        [Key]
        [Column("ID_UBICACION")]
        public int id_ubicacion { get; set; }

        [Column("ID_ENVIO")]
        public int? id_envio { get; set; }

        [Column("ID_BODEGA")]
        public int? id_bodega { get; set; }

        [Column("FECHA_INGRESO")]
        public DateTime? fecha_ingreso { get; set; }

        [Column("FECHA_SALIDA")]
        public DateTime? fecha_salida { get; set; }

        [Column("POSICION_ESTANTE")]
        public string? posicion_estante { get; set; }

        [Column("POSICION_FILA")]
        public int? posicion_fila { get; set; }

        [Column("POSICION_COLUMNA")]
        public int? posicion_columna { get; set; }

        [Column("RESPONSABLE_INGRESO")]
        public int? responsable_ingreso { get; set; }

        [Column("RESPONSABLE_SALIDA")]
        public int? responsable_salida { get; set; }
    }
}