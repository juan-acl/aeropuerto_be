using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("PROGRAMAS_VUELO")]
    public class ProgramaVueloModel
    {
        [Key]
        [Column("ID_PROGRAMA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPrograma { get; set; }

        [Column("NUMERO_VUELO")]
        [Required]
        [StringLength(10)]
        public string NumeroVuelo { get; set; } = null!;

        [Column("ID_AEROLINEA")]
        [Required]
        public int IdAerolinea { get; set; }

        [Column("AEROPUERTO_ORIGEN")]
        [Required]
        [StringLength(10)]
        public string AeropuertoOrigen { get; set; } = null!;

        [Column("AEROPUERTO_DESTINO")]
        [Required]
        [StringLength(10)]
        public string AeropuertoDestino { get; set; } = null!;

        [Column("TIPO_VUELO")]
        [StringLength(15)]
        public string? TipoVuelo { get; set; }  // NACIONAL | INTERNACIONAL

        [Column("DIAS_SEMANA")]
        [StringLength(20)]
        public string? DiasSemana { get; set; }

        [Column("FRECUENCIA_SEMANAL")]
        public int? FrecuenciaSemanal { get; set; }

        [Column("DURACION_ESTIMADA_MINUTOS")]
        public int? DuracionEstimadaMinutos { get; set; }

        [Column("DISTANCIA_KM")]
        public decimal? DistanciaKm { get; set; }

        [Column("CLASE_SERVICIO")]
        [StringLength(20)]
        public string? ClaseServicio { get; set; }  // ECONOMICA|EJECUTIVA|PRIMERA_CLASE|MIXTA

        [Column("ACTIVO")]
        public int Activo { get; set; } = 1;

        [Column("FECHA_INICIO")]
        public DateTime? FechaInicio { get; set; }

        [Column("FECHA_FIN")]
        public DateTime? FechaFin { get; set; }
    }
}
