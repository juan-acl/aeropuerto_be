using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Aeropuerto.Backend.Models
{
    [Table("AVIONES")]
    public class AvionModel
    {
        [Key][Column("MATRICULA_AVION")][StringLength(20)]
        public string MatriculaAvion { get; set; } = null!;
        [Column("ID_MODELO")][Required]
        public int IdModelo { get; set; }
        [Column("ID_AEROLINEA")][Required]
        public int IdAerolinea { get; set; }
        [Column("ANIO_FABRICACION")]
        public int? AnioFabricacion { get; set; }
        [Column("FECHA_ULTIMA_REVISION")]
        public DateTime? FechaUltimaRevision { get; set; }
        [Column("HORAS_VUELO_TOTAL")]
        public decimal? HorasVueloTotal { get; set; }
        [Column("CICLOS_TOTAL")]
        public int? CiclosTotal { get; set; }
        [Column("ESTADO_OPERACIONAL")][StringLength(20)]
        public string EstadoOperacional { get; set; } = "OPERATIVO";
        // OPERATIVO|EN_MANTENIMIENTO|FUERA_SERVICIO|RETIRADO
        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}
