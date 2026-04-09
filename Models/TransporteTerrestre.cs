using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("TRANSPORTE_TERRESTRE")]
    public class TransporteTerrestreModel
    {
        [Key]
        [Column("ID_TRANSPORTE")]
        public int IdTransporte { get; set; }

        [Column("CODIGO_AEROPUERTO")]
        public string? CodigoAeropuerto { get; set; }

        [Column("TIPO_TRANSPORTE")]
        public string TipoTransporte { get; set; } = null!; // TAXI, BUS, SHUTTLE, RENTA_AUTO, METRO

        [Column("EMPRESA")]
        public string? Empresa { get; set; }

        [Column("TELEFONO_CONTACTO")]
        public string? TelefonoContacto { get; set; }

        [Column("TARIFA_ESTIMADA")]
        public string? TarifaEstimada { get; set; }

        [Column("HORARIO_OPERACION")]
        public string? HorarioOperacion { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}