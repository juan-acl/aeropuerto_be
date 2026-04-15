using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("ENCUESTAS_POST_VUELO")]
    public class EncuestasPostVuelo
    {
        
        [Key]
        [Column("ID_ENCUESTA_POST_VUELO")]
        public int IdEncuestaPostVuelo { get; set; }
        
        [Column("ID_VUELO")]
        public decimal IdVuelo { get; set; }
        
        [Column("ID_PASAJERO")]
        public decimal IdPasajero { get; set; }
        
        [Column("FECHA_ENCUESTA")]
        public DateTime? FechaEncuesta { get; set; }
        
        [Column("CANAL_RESPUESTA")]
        public string? CanalRespuesta { get; set; }
        
        [Column("PUNTUACION_GENERAL")]
        public decimal? PuntuacionGeneral { get; set; }
        
        [Column("PUNTUACION_CHECKIN")]
        public decimal? PuntuacionCheckin { get; set; }
        
        [Column("PUNTUACION_ABORDAJE")]
        public decimal? PuntuacionAbordaje { get; set; }
        
        [Column("PUNTUACION_TRIPULACION")]
        public decimal? PuntuacionTripulacion { get; set; }
        
        [Column("PUNTUACION_COMIDA")]
        public decimal? PuntuacionComida { get; set; }
        
        [Column("PUNTUACION_CONFORT")]
        public decimal? PuntuacionConfort { get; set; }
        
        [Column("PUNTUACION_PUNTUALIDAD")]
        public decimal? PuntuacionPuntualidad { get; set; }
        
        [Column("COMENTARIOS")]
        public string? Comentarios { get; set; }
        
        [Column("RECOMENDARIA")]
        public decimal? Recomendaria { get; set; }
        
        [Column("NPS_GENERADO")]
        public decimal? NpsGenerado { get; set; }
        
        [Column("PROCESADA")]
        public decimal? Procesada { get; set; }
        
     
    }
}
