using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("OBJETOS_PERDIDOS")]
    public class ObjetosPerdidosModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_OBJETO")]
        public int IdObjeto { get; set; }

        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = null!;

        [Column("CATEGORIA_OBJETO")]
        public string? CategoriaObjeto { get; set; }

        [Column("FECHA_REPORTE")]
        public DateTime? FechaReporte { get; set; }

        [Column("HORA_REPORTE")]
        public DateTime? HoraReporte { get; set; }

        [Column("LUGAR_ENCONTRADO")]
        public string? LugarEncontrado { get; set; } // AEROPUERTO, VUELO, etc.

        [Column("UBICACION_DETALLADA")]
        public string? UbicacionDetallada { get; set; }

        [Column("ID_VUELO")]
        public int? IdVuelo { get; set; }

        [Column("CODIGO_AEROPUERTO")]
        public string? CodigoAeropuerto { get; set; }

        [Column("COLOR")]
        public string? Color { get; set; }

        [Column("MARCA")]
        public string? Marca { get; set; }

        [Column("MODELO")]
        public string? Modelo { get; set; }

        [Column("NUMERO_SERIE")]
        public string? NumeroSerie { get; set; }

        [Column("VALOR_ESTIMADO")]
        public decimal? ValorEstimado { get; set; }

        [Column("ENCONTRADO_POR")]
        public string? EncontradoPor { get; set; }

        [Column("UBICACION_ACTUAL")]
        public string? UbicacionActual { get; set; }

        [Column("ESTADO")]
        public string Estado { get; set; } = "ENCONTRADO"; // ENCONTRADO, ENTREGADO, etc.

        [Column("FECHA_ENTREGA")]
        public DateTime? FechaEntrega { get; set; }

        [Column("ID_PASAJERO_ENTREGA")]
        public int? IdPasajeroEntrega { get; set; }

        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }

        [Column("FOTO_OBJETO")]
        public byte[]? FotoObjeto { get; set; }
    }
}
