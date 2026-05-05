using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("CONVENIOS_HOTELES_TRANSPORTE")]
    public class ConveniosHotelesTransporte
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_CONVENIO_HOTEL")]
        public int IdConvenioHotel { get; set; }
        
        [Column("ID_HOTEL_CERCANO")]
        public decimal IdHotelCercano { get; set; }
        
        [Column("ID_EMPRESA_TRANSPORTE")]
        public decimal IdEmpresaTransporte { get; set; }
        
        [Column("TIPO_CONVENIO")]
        public string? TipoConvenio { get; set; }
        
        [Column("TARIFA_ESPECIAL")]
        public decimal? TarifaEspecial { get; set; }
        
        [Column("CONDICIONES")]
        public string? Condiciones { get; set; }
        
        [Column("FECHA_INICIO")]
        public DateTime FechaInicio { get; set; }
        
        [Column("FECHA_FIN")]
        public DateTime? FechaFin { get; set; }
        
        [Column("ACTIVO")]
        public decimal? Activo { get; set; }

    }
}
