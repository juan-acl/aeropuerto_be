using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Aeropuerto.Backend.Models
{
    [Table("CONDICIONES_METEOROLOGICAS")]
    public class CondicionMeteorologicaModel
    {
        [Key][Column("ID_CONDICION")][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCondicion { get; set; }
        [Column("CODIGO_AEROPUERTO")][StringLength(10)]
        public string? CodigoAeropuerto { get; set; }
        [Column("FECHA_HORA")]
        public DateTime? FechaHora { get; set; }
        [Column("TEMPERATURA")]
        public decimal? Temperatura { get; set; }
        [Column("HUMEDAD")]
        public decimal? Humedad { get; set; }
        [Column("PRESION_ATMOSFERICA")]
        public decimal? PresionAtmosferica { get; set; }
        [Column("VIENTO_VELOCIDAD")]
        public decimal? VientoVelocidad { get; set; }
        [Column("VIENTO_DIRECCION")][StringLength(10)]
        public string? VientoDireccion { get; set; }
        [Column("VISIBILIDAD_KM")]
        public decimal? VisibilidadKm { get; set; }
        [Column("CONDICION_GENERAL")][StringLength(30)]
        public string? CondicionGeneral { get; set; }
        // DESPEJADO|NUBLADO|LLUVIA|TORMENTA|NIEBLA|NIEVE|GRANIZO
        [Column("FENOMENOS_ESPECIALES")][StringLength(200)]
        public string? FenomenosEspeciales { get; set; }
        [Column("FUENTE_DATOS")][StringLength(50)]
        public string? FuenteDatos { get; set; }
    }
}
