using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("CAPACITACION")]
    public class Capacitacion
    {
        [Key]
        [Column("ID_CAPACITACION")]
        public int IdCapacitacion { get; set; }
        [Column("NOMBRE_CURSO")]
        public string NombreCurso { get; set; } = null!;
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = null!;
        [Column("TIPO_CAPACITACION")]
        public string TipoCapacitacion { get; set; } = null!; // SEGURIDAD, TECNICA, etc.
        [Column("DURACION_HORAS")]
        public int DuracionHoras { get; set; }
        [Column("COSTO")]
        public decimal Costo { get; set; }
        [Column("PROVEEDOR")]
        public string Proveedor { get; set; } = null!;
        [Column("FECHA_INICIO")]
        public DateTime FechaInicio { get; set; }
        [Column("FECHA_FIN")]
        public DateTime FechaFin { get; set; }
        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;
    }
}