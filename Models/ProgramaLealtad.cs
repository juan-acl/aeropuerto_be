using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("PROGRAMA_LEALTAD")]
    public class ProgramaLealtadModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_LEALTAD")]
        public int IdLealtad { get; set; }

        [Column("ID_PASAJERO")]
        public int? IdPasajero { get; set; }

        [Column("NIVEL_MEMBRESIA")]
        public string NivelMembresia { get; set; } = "BRONCE"; // BRONCE, PLATA, ORO, PLATINO

        [Column("PUNTOS_ACUMULADOS")]
        public int PuntosAcumulados { get; set; } = 0;

        [Column("PUNTOS_CANJEABLES")]
        public int PuntosCanjeables { get; set; } = 0;

        [Column("FECHA_INGRESO")]
        public DateTime? FechaIngreso { get; set; }

        [Column("FECHA_ULTIMA_ACTIVIDAD")]
        public DateTime? FechaUltimaActividad { get; set; }

        [Column("MILLAS_ACUMULADAS")]
        public int MillasAcumuladas { get; set; } = 0;

        [Column("BENEFICIOS_ACTIVOS")]
        public string? BeneficiosActivos { get; set; }

        [Column("TARJETA_NUMERO")]
        public string? TarjetaNumero { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}
