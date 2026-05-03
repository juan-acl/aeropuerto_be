using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("CHECKLISTS_MANTENIMIENTO")]
    public class ChecklistMantenimiento
    {
        [Key]
        [Column("ID_CHECKLIST")]
        public int id_checklist { get; set; }

        [Column("ID_MODELO_AVION")]
        public int? id_modelo_avion { get; set; }

        [Column("CODIGO_CHECKLIST")]
        public string? codigo_checklist { get; set; }

        [Column("NOMBRE_CHECKLIST")]
        public string? nombre_checklist { get; set; }

        [Column("TIPO_MANTENIMIENTO")]
        public string? tipo_mantenimiento { get; set; } // PREVENTIVO, PREDICTIVO, CORRECTIVO, MAYOR

        [Column("FRECUENCIA_HORAS_VUELO")]
        public int? frecuencia_horas_vuelo { get; set; }

        [Column("FRECUENCIA_DIAS")]
        public int? frecuencia_dias { get; set; }

        [Column("TIEMPO_ESTIMADO_MINUTOS")]
        public int? tiempo_estimado_minutos { get; set; }

        [Column("REQUIERE_HERRAMIENTAS_ESPECIALES")]
        public int? requiere_herramientas_especiales { get; set; }

        [Column("REQUIERE_CERTIFICACION")]
        public int? requiere_certificacion { get; set; }

        [Column("ACTIVO")]
        public int? activo { get; set; }
    }
}