using System.ComponentModel.DataAnnotations;

namespace Esthiber_Valentin_P1_AP1.Models
{
    public class Ingresos
    {
        [Key]
        public int IngresoId { get; set; }

        [Required(ErrorMessage = "Fecha es Requerida")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Concepto es Requerido")]
        [StringLength(maximumLength: 5000, ErrorMessage = "Concepto muy largo")]
        public string? Concepto { get; set; }

        [Required(ErrorMessage = "Monto es Requerido")]
        [Range(minimum: 0.01, maximum: double.MaxValue, ErrorMessage = "El Monto debe ser mayor a 0.01")]
        public double Monto { get; set; }
    }
}
