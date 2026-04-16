using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("GRUPOS_VIAJE")]
    public class GruposViajeModel
    {
        [Key]
        [Column("ID_GRUPO")]
        public int IdGrupo { get; set; }

        [Column("NOMBRE_GRUPO")]
        public string? NombreGrupo { get; set; }

        [Column("TIPO_GRUPO")]
        public string TipoGrupo { get; set; } = null!; // FAMILIA, EMPRESA, ESCOLAR, etc.

        [Column("CANTIDAD_PASAJEROS")]
        public int CantidadPasajeros { get; set; }

        [Column("CONTACTO_RESPONSABLE")]
        public string? ContactoResponsable { get; set; }

        [Column("TELEFONO_RESPONSABLE")]
        public string? TelefonoResponsable { get; set; }

        [Column("EMAIL_RESPONSABLE")]
        public string? EmailResponsable { get; set; }

        [Column("OBSERVACIONES")]
        public string? Observaciones { get; set; }
    }
}