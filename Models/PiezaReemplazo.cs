using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("PIEZA_REEMPLAZO")]
    public class PiezaReemplazo
    {
        [Key]
        [Column("ID_PIEZA")]
        public int IdPieza { get; set; }
        [Column("NOMBRE_PIEZA")]
        public string NombrePieza { get; set; } = null!;
        [Column("NUMERO_PARTE")]
        public string NumeroParte { get; set; } = null!;
        [Column("STOCK")]
        public int Stock { get; set; }
        [Column("STOCK_MINIMO")]
        public int StockMinimo { get; set; }
        [Column("PRECIO_UNITARIO")]
        public decimal PrecioUnitario { get; set; }
    }
}