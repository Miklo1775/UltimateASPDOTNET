using System.ComponentModel.DataAnnotations;
using SimpleEcommerceApp.CustomValidators;

namespace SimpleEcommerceApp.Models
{
    public class Order : IValidatableObject
    {
        public int? OrdeNo { get; set; }
        [Required(ErrorMessage = "{0} can not be blank.")]
        [DateCheckValidator(ErrorMessage = "Date should be greater than or equal to 2001-01-01")]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "{0} can not be blank.")]
        [Display(Name ="Invoice Price")]
        public double InvoicePrice { get; set; }
        [Required]
        public List<Product> Products { get; set; } = new List<Product>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Products.Count == 0)
            {
                yield return new ValidationResult("Every order needs a minimum of 1 product");
            }

            if(InvoicePrice != CalculateTotalProductPrice())
            {
                yield return new ValidationResult("Invoice Price does not match the total cost of the specified products in the order");
            }

        }

        private double CalculateTotalProductPrice()
        {
            double total = 0;
            foreach (Product product in Products)
            {
                total += product.Price * product.Quantity;
            }

            return total;
        }
    }
}
