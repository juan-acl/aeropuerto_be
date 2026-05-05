using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("CLAUSULAS_CONTRATO")]
    public class ClausulasContrato
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
    }
}

