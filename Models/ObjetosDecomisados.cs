using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("OBJETOS_DECOMISADOS")]
    public class ObjetosDecomisadosModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_DECOMISO")]
        public int IdDecomiso { get; set; }

        [Column("ID_CONTROL")]
        public int? IdControl { get; set; }

        [Column("ID_PASAJERO")]
        public int? IdPasajero { get; set; }

        [Column("TIPO_OBJETO")]
        public string? TipoObjeto { get; set; }

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }

        [Column("CANTIDAD")]
        public int Cantidad { get; set; }

        [Column("MOTIVO_DECOMISO")]
        public string? MotivoDecomiso { get; set; }

        [Column("DESTINO_FINAL")]
        public string? DestinoFinal { get; set; } // Ejemplo: DESTRUIDO, DONADO, ALMACENADO

        [Column("FECHA_REGISTRO")]
        public DateTime? FechaRegistro { get; set; }

        [Column("REGISTRADO_POR")]
        public string? RegistradoPor { get; set; }
    }
}
