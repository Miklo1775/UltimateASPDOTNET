using System.ComponentModel.DataAnnotations;

namespace SimpleEcommerceApp.Models
{
    public class Order
    {
        public int? OrdeNo { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public double InvoicePrice { get; set; }
        [Required]
        public List<Product>? Products { get; set; }
    }
}
