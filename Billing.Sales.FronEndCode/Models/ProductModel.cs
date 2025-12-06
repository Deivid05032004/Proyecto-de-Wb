using System.ComponentModel.DataAnnotations;

namespace Billing.Sales.FrontEndCode.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "La marca es obligatoria.")]
        public string Brand { get; set; } = "";

        [Required(ErrorMessage = "La presentación es obligatoria.")]
        public string Presentation { get; set; } = "";

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
        public double Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
        public int Stock { get; set; }
    }
}
