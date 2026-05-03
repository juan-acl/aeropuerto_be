using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("TASAS_AEROPORTUARIAS")]
    public class TasaAeroportuaria
    {
        [Key]
        [Column("ID_TASA")]
        public int id_tasa { get; set; }

        [Column("NOMBRE_TASA")]
        public string? nombre_tasa { get; set; }

        [Column("TIPO_TASA")]
        public string? tipo_tasa { get; set; } // INTERNACIONAL, NACIONAL, SEGURIDAD, COMBUSTIBLE, ESTACIONAMIENTO

        [Column("MONTO")]
        public decimal? monto { get; set; }

        [Column("MONEDA")]
        public string? moneda { get; set; }

        [Column("CALCULO_PORCENTAJE")]
        public decimal? calculo_porcentaje { get; set; }

        [Column("APLICA_A")]
        public string? aplica_a { get; set; } // PASAJERO, AEROLINEA, CARGA, AVION

        [Column("ACTIVA")]
        public int? activa { get; set; }

        [Column("FECHA_ACTUALIZACION")]
        public DateTime? fecha_actualizacion { get; set; }
    }
}