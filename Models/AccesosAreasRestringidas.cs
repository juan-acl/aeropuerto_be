using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("ACCESOS_AREAS_RESTRINGIDAS")]
    public class AccesosAreasRestringidasModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_ACCESO")]
        public int IdAcceso { get; set; }

        [Column("ID_EMPLEADO")]
        public int? IdEmpleado { get; set; }

        [Column("AREA_ACCESO")]
        public string? AreaAcceso { get; set; }

        [Column("FECHA_HORA_ACCESO")]
        public DateTime? FechaHoraAcceso { get; set; }

        [Column("TIPO_ACCESO")]
        public string TipoAcceso { get; set; } = null!; // ENTRADA, SALIDA

        [Column("METODO_AUTENTICACION")]
        public string? MetodoAutenticacion { get; set; } // HUELLA, TARJETA, CODIGO

        [Column("AUTORIZADO")]
        public int Autorizado { get; set; } = 1; // 1 = Sí, 0 = No (Intento denegado)

        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
    }
}
