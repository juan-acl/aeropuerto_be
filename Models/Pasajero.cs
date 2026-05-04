using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    [Table("PASAJEROS")]
    public class PasajeroModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_PASAJERO")]
        public int IdPasajero { get; set; }

        [Column("NOMBRES")]
        public string Nombres { get; set; } = null!;

        [Column("APELLIDOS")]
        public string Apellidos { get; set; } = null!;

        [Column("TIPO_DOCUMENTO")]
        public string? TipoDocumento { get; set; }

        [Column("NUMERO_DOCUMENTO")]
        public string NumeroDocumento { get; set; } = null!;

        [Column("NACIONALIDAD")]
        public string? Nacionalidad { get; set; }

        [Column("FECHA_NACIMIENTO")]
        public DateTime? FechaNacimiento { get; set; }

        [Column("GENERO")]
        public string? Genero { get; set; }

        [Column("TELEFONO")]
        public string? Telefono { get; set; }

        [Column("EMAIL")]
        public string? Email { get; set; }

        [Column("DIRECCION")]
        public string? Direccion { get; set; }

        [Column("CIUDAD_RESIDENCIA")]
        public string? CiudadResidencia { get; set; }

        [Column("PAIS_RESIDENCIA")]
        public string? PaisResidencia { get; set; }

        [Column("CODIGO_POSTAL")]
        public string? CodigoPostal { get; set; }

        [Column("OCUPACION")]
        public string? Ocupacion { get; set; }

        [Column("ESTADO_CIVIL")]
        public string? EstadoCivil { get; set; }

        [Column("FECHA_REGISTRO")]
        public DateTime FechaRegistro { get; set; }

        [Column("USUARIO_REGISTRO")]
        public string? UsuarioRegistro { get; set; }
    }
}
