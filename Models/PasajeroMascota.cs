using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("PASAJEROS_MASCOTAS")]
    public class PasajeroMascota
    {
        [Key]
        [Column("ID_MASCOTA")]
        public int id_mascota { get; set; }

        [Column("ID_PASAJERO")]
        public int? id_pasajero { get; set; }

        [Column("ID_RESERVA")]
        public int? id_reserva { get; set; }

        [Column("NOMBRE_MASCOTA")]
        public string? nombre_mascota { get; set; }

        [Column("TIPO_MASCOTA")]
        public string? tipo_mascota { get; set; } // PERRO, GATO, AVE

        [Column("RAZA")]
        public string? raza { get; set; }

        [Column("PESO_KG")]
        public decimal? peso_kg { get; set; }

        [Column("CERTIFICADO_SALUD")]
        public byte[]? certificado_salud { get; set; }

        [Column("VACUNAS")]
        public string? vacunas { get; set; }

        [Column("TRANSPORTADORA_DIMENSIONES")]
        public string? transportadora_dimensiones { get; set; }

        [Column("AUTORIZADO")]
        public int? autorizado { get; set; }
    }
}