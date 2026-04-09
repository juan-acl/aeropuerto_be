using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("PASAJEROS_REDES_SOCIALES")]
    public class PasajerosRedesSocialesModel
    {
        [Key]
        [Column("ID_RED_SOCIAL")]
        public int IdRedSocial { get; set; }

        [Column("ID_PASAJERO")]
        public int IdPasajero { get; set; }

        [Column("RED_SOCIAL")]
        public string RedSocial { get; set; } = null!; // FACEBOOK, TWITTER, etc.

        [Column("USUARIO")]
        public string? Usuario { get; set; }

        [Column("URL_PERFIL")]
        public string? UrlPerfil { get; set; }

        [Column("PUBLICO")]
        public int Publico { get; set; } // 0 o 1
    }
}