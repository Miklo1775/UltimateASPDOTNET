using System.ComponentModel.DataAnnotations;

namespace ModelValidationsDemo.Models
{
    public class Person
    {
        //ALONGSIDE DEFAULT ERROR MESSAGE, WE CAN USE OUR OWN ERROR MESSAGE SUCH AS BELOW.
        //THE DISPLAY ATTRIBUTE CAN DISPLAY THE VALUE INSTEAD OF THE PROPERTY.
        //SO THE {0} WILL BE "Person Name" and not "PersonName".
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} to {1} characters")]
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        [Range(0, 999.99, ErrorMessage = "{0} should be a value between {1} and {2}")]
        public double? Price { get; set; }

        public override string ToString()
        {
            return $"Person Data Received:\nName: {this.PersonName}\nEmail: {this.Email}\nPhone: {this.Phone}\nPassword: {this.Password}\nConfirmed Password: {this.ConfirmPassword}\nPrice: {this.Price}";
        }
    }
}
