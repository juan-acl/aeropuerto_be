using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("PIEZAS_REEMPLAZO")]
    public class PiezaReemplazo
    {
        [Key]
        [Column("ID_PIEZA")]
        public int id_pieza { get; set; }

        [Column("CODIGO_PIEZA")]
        public string? codigo_pieza { get; set; }

        [Column("NOMBRE_PIEZA")]
        public string? nombre_pieza { get; set; }

        [Column("DESCRIPCION")]
        public string? descripcion { get; set; }

        [Column("ID_MODELO_AVION")]
        public int? id_modelo_avion { get; set; }

        [Column("ID_FABRICANTE")]
        public int? id_fabricante { get; set; }

        [Column("NUMERO_PARTE_FABRICANTE")]
        public string? numero_parte_fabricante { get; set; }

        [Column("STOCK_ACTUAL")]
        public int? stock_actual { get; set; }

        [Column("STOCK_MINIMO")]
        public int? stock_minimo { get; set; }

        [Column("STOCK_MAXIMO")]
        public int? stock_maximo { get; set; }

        [Column("UBICACION_ALMACEN")]
        public string? ubicacion_almacen { get; set; }

        [Column("PRECIO_UNITARIO")]
        public decimal? precio_unitario { get; set; }

        [Column("MONEDA")]
        public string? moneda { get; set; }

        [Column("TIEMPO_REORDEN_DIAS")]
        public int? tiempo_reorden_dias { get; set; }

        [Column("ACTIVO")]
        public int? activo { get; set; }
    }
}