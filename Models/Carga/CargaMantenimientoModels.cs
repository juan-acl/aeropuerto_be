using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models.Carga
{
    [Table("TIPOS_CARGA")]
    public class TipoCarga
    {
        [Key]
        [Column("ID_TIPO_CARGA")]
        public int IdTipoCarga { get; set; }

        [Column("NOMBRE_TIPO")]
        public string NombreTipo { get; set; } = string.Empty;

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }

        [Column("REQUIERE_REFRIGERACION")]
        public int RequiereRefrigeracion { get; set; } = 0;

        [Column("ES_PELIGROSA")]
        public int EsPeligrosa { get; set; } = 0;

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }

    [Table("BODEGAS_CARGA")]
    public class BodegaCarga
    {
        [Key]
        [Column("ID_BODEGA")]
        public int IdBodega { get; set; }

        [Column("NOMBRE_BODEGA")]
        public string NombreBodega { get; set; } = string.Empty;

        [Column("UBICACION")]
        public string? Ubicacion { get; set; }

        [Column("CAPACIDAD_KG")]
        public decimal? CapacidadKg { get; set; }

        [Column("CAPACIDAD_M3")]
        public decimal? CapacidadM3 { get; set; }

        [Column("TIENE_REFRIGERACION")]
        public int TieneRefrigeracion { get; set; } = 0;

        [Column("ESTADO")]
        public string Estado { get; set; } = "Operativa";

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}

namespace Aeropuerto.Backend.Models.Mantenimiento
{
    [Table("SENSORES_AVION")]
    public class SensorAvion
    {
        [Key]
        [Column("ID_SENSOR")]
        public int IdSensor { get; set; }

        [Column("NOMBRE_SENSOR")]
        public string NombreSensor { get; set; } = string.Empty;

        [Column("TIPO_SENSOR")]
        public string TipoSensor { get; set; } = string.Empty;

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }

        [Column("UNIDAD_MEDIDA")]
        public string? UnidadMedida { get; set; }

        [Column("VALOR_MINIMO")]
        public decimal? ValorMinimo { get; set; }

        [Column("VALOR_MAXIMO")]
        public decimal? ValorMaximo { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }

    [Table("CHECKLISTS_MANTENIMIENTO")]
    public class ChecklistMantenimiento
    {
        [Key]
        [Column("ID_CHECKLIST")]
        public int IdChecklist { get; set; }

        [Column("NOMBRE_CHECKLIST")]
        public string NombreChecklist { get; set; } = string.Empty;

        [Column("TIPO_MANTENIMIENTO")]
        public string TipoMantenimiento { get; set; } = string.Empty;

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }

        [Column("PERIODICIDAD")]
        public string? Periodicidad { get; set; }

        [Column("DURACION_ESTIMADA_HORAS")]
        public decimal? DuracionEstimadaHoras { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }

    [Table("PIEZAS_REEMPLAZO")]
    public class PiezaReemplazo
    {
        [Key]
        [Column("ID_PIEZA")]
        public int IdPieza { get; set; }

        [Column("CODIGO_PIEZA")]
        public string CodigoPieza { get; set; } = string.Empty;

        [Column("NOMBRE_PIEZA")]
        public string NombrePieza { get; set; } = string.Empty;

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }

        [Column("FABRICANTE")]
        public string? Fabricante { get; set; }

        [Column("STOCK_ACTUAL")]
        public int StockActual { get; set; }

        [Column("STOCK_MINIMO")]
        public int StockMinimo { get; set; }

        [Column("PRECIO_UNITARIO")]
        public decimal? PrecioUnitario { get; set; }

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}
