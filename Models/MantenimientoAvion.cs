using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("MANTENIMIENTO_AVIONES")]
    public class MantenimientoAvionModel
    {
        [Key][Column("ID_MANTENIMIENTO")]
        public int IdMantenimiento { get; set; }
        
        [Column("MATRICULA_AVION")][StringLength(20)]
        public string? MatriculaAvion { get; set; }
        
        [Column("ID_MODELO")]
        public int? IdModelo { get; set; }
        
        [Column("FECHA_MANTENIMIENTO")]
        public DateTime? FechaMantenimiento { get; set; }
        
        [Column("TIPO_MANTENIMIENTO")][StringLength(50)]
        public string? TipoMantenimiento { get; set; }
        
        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }
        
        [Column("HORAS_VUELO_ACTUALES")]
        public decimal? HorasVueloActuales { get; set; }
        
        [Column("PROXIMO_MANTENIMIENTO")]
        public DateTime? ProximoMantenimiento { get; set; }
        
        [Column("COSTO")]
        public decimal? Costo { get; set; }
        
        [Column("TALLER")][StringLength(100)]
        public string? Taller { get; set; }
        
        [Column("TECNICO_RESPONSABLE")][StringLength(100)]
        public string? TecnicoResponsable { get; set; }
    }
}
