using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aeropuerto.Backend.Models
{
    [Table("ENVIOS_CARGA")]
    public class EnvioCarga
    {
        [Key]
        [Column("ID_ENVIO")]
        public int id_envio { get; set; }

        [Column("CODIGO_ENVIO")]
        public string? codigo_envio { get; set; }

        [Column("ID_VUELO")]
        public int? id_vuelo { get; set; }

        [Column("ID_TIPO_CARGA")]
        public int? id_tipo_carga { get; set; }

        [Column("PESO_KG")]
        public decimal? peso_kg { get; set; }

        [Column("VOLUMEN_M3")]
        public decimal? volumen_m3 { get; set; }

        [Column("CANTIDAD_BULTOS")]
        public int? cantidad_bultos { get; set; }

        [Column("CONTENIDO")]
        public string? contenido { get; set; }

        [Column("VALOR_DECLARADO")]
        public decimal? valor_declarado { get; set; }

        [Column("MONEDA")]
        public string? moneda { get; set; }

        [Column("CONSIGNADOR_NOMBRE")]
        public string? consignador_nombre { get; set; }

        [Column("CONSIGNADOR_DOCUMENTO")]
        public string? consignador_documento { get; set; }

        [Column("CONSIGNATARIO_NOMBRE")]
        public string? consignatario_nombre { get; set; }

        [Column("CONSIGNATARIO_DOCUMENTO")]
        public string? consignatario_documento { get; set; }

        [Column("INSTRUCCIONES_ESPECIALES")]
        public string? instrucciones_especiales { get; set; }

        [Column("FECHA_RECEPCION")]
        public DateTime? fecha_recepcion { get; set; }

        [Column("FECHA_EMBARQUE")]
        public DateTime? fecha_embarque { get; set; }

        [Column("ESTADO")]
        public string? estado { get; set; } // RECIBIDO, EN_BODEGA, CARGADO, EN_VUELO, DESCARGADO, ENTREGADO, ADUANA

        [Column("UBICACION_ACTUAL")]
        public string? ubicacion_actual { get; set; }
    }
}