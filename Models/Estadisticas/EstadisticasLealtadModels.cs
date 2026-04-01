using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models.Estadisticas
{
    [Table("ESTADISTICAS_VUELO")]
    public class EstadisticaVuelo
    {
        [Key]
        [Column("ID_ESTADISTICA")]
        public int IdEstadistica { get; set; }

        [Column("PERIODO")]
        public string Periodo { get; set; } = string.Empty;

        [Column("FECHA_INICIO")]
        public DateTime FechaInicio { get; set; }

        [Column("FECHA_FIN")]
        public DateTime FechaFin { get; set; }

        [Column("TOTAL_VUELOS")]
        public int TotalVuelos { get; set; }

        [Column("VUELOS_PUNTUAL")]
        public int VuelosPuntual { get; set; }

        [Column("VUELOS_RETRASADOS")]
        public int VuelosRetrasados { get; set; }

        [Column("VUELOS_CANCELADOS")]
        public int VuelosCancelados { get; set; }

        [Column("TOTAL_PASAJEROS")]
        public int TotalPasajeros { get; set; }

        [Column("OCUPACION_PROMEDIO")]
        public decimal? OcupacionPromedio { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }

    [Table("REPORTES_OPERACIONALES")]
    public class ReporteOperacional
    {
        [Key]
        [Column("ID_REPORTE")]
        public int IdReporte { get; set; }

        [Column("NOMBRE_REPORTE")]
        public string NombreReporte { get; set; } = string.Empty;

        [Column("TIPO_REPORTE")]
        public string TipoReporte { get; set; } = string.Empty;

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }

        [Column("FECHA_GENERACION")]
        public DateTime FechaGeneracion { get; set; }

        [Column("GENERADO_POR")]
        public string? GeneradoPor { get; set; }

        [Column("PERIODO_DESDE")]
        public DateTime? PeriodoDesde { get; set; }

        [Column("PERIODO_HASTA")]
        public DateTime? PeriodoHasta { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}

namespace Aeropuerto.Backend.Models.Lealtad
{
    [Table("PROGRAMA_LEALTAD")]
    public class ProgramaLealtad
    {
        [Key]
        [Column("ID_PROGRAMA")]
        public int IdPrograma { get; set; }

        [Column("NOMBRE_PROGRAMA")]
        public string NombrePrograma { get; set; } = string.Empty;

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }

        [Column("PUNTOS_POR_VUELO")]
        public int PuntosPorVuelo { get; set; }

        [Column("PUNTOS_CANJE_MINIMO")]
        public int PuntosCanjeMinimo { get; set; }

        [Column("VIGENTE")]
        public int Vigente { get; set; } = 1;
    }

    [Table("MIEMBROS_LEALTAD")]
    public class MiembroLealtad
    {
        [Key]
        [Column("ID_MIEMBRO")]
        public int IdMiembro { get; set; }

        [Column("NOMBRE_MIEMBRO")]
        public string NombreMiembro { get; set; } = string.Empty;

        [Column("EMAIL")]
        public string? Email { get; set; }

        [Column("NIVEL")]
        public string Nivel { get; set; } = "Bronce";

        [Column("PUNTOS_ACUMULADOS")]
        public int PuntosAcumulados { get; set; }

        [Column("PUNTOS_CANJEADOS")]
        public int PuntosCanjeados { get; set; }

        [Column("FECHA_INGRESO")]
        public DateTime FechaIngreso { get; set; }

        [Column("ID_PROGRAMA")]
        public int? IdPrograma { get; set; }

        [NotMapped]
        public string? NombrePrograma { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}
