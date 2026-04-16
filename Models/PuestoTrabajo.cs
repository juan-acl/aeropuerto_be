using System.ComponentModel.DataAnnotations;

namespace Aeropuerto.Backend.Models
{
    public class PuestoTrabajo
    {
        [Key]
        public int IdPuesto { get; set; }
        public string NombrePuesto { get; set; } = null!;
        public int IdDepartamento { get; set; }
        public int NivelJerarquico { get; set; }
        public decimal SalarioMinimo { get; set; }
        public decimal SalarioMaximo { get; set; }
        public string DescripcionFunciones { get; set; } = null!;
        public string Requisitos { get; set; } = null!;
        public int Activo { get; set; } = 1;
    }
}