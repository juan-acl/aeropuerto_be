using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("ESTACIONAMIENTO")]
    public class EstacionamientoModel
    {
        [Key]
        [Column("ID_ESTACIONAMIENTO")]
        public int IdEstacionamiento { get; set; }

        [Column("CODIGO_AEROPUERTO")]
        public string? CodigoAeropuerto { get; set; }

        [Column("NUMERO_ESPACIO")]
        public string? NumeroEspacio { get; set; }

        [Column("TIPO_ESPACIO")]
        public string TipoEspacio { get; set; } = null!; // AUTOMOVIL, MOTOCICLETA, DISCAPACITADO, ELECTRICO, CARGA

        [Column("TERMINAL_CERCANA")]
        public string? TerminalCercana { get; set; }

        [Column("TARIFA_POR_HORA")]
        public decimal? TarifaPorHora { get; set; }

        [Column("TARIFA_DIARIA")]
        public decimal? TarifaDiaria { get; set; }

        [Column("DISPONIBLE")]
        public int Disponible { get; set; } = 1;

        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
    }
}