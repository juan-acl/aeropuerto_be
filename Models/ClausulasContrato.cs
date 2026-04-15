using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("CLAUSULAS_CONTRATO")]
    public class ClausulasContrato
    {
        
        [Key]
        [Column("ID_CLAUSULA_CONTRATO")]
        public int IdClausulaContrato { get; set; }
        
        [Column("ID_CONTRATO")]
        public decimal IdContrato { get; set; }
        
        [Column("NUMERO_CLAUSULA")]
        public decimal NumeroClausula { get; set; }
        
        [Column("TITULO_CLAUSULA")]
        public string? TituloClausula { get; set; }
        
        [Column("TEXTO_CLAUSULA")]
        public string TextoClausula { get; set; } = null!;
        
        [Column("TIPO_CLAUSULA")]
        public string? TipoClausula { get; set; }
        
        [Column("VIGENTE")]
        public decimal? Vigente { get; set; }
        
        [Column("FOREIGN")]
        public decimal? Foreign { get; set; }
    }
}
