using System.ComponentModel.DataAnnotations;

namespace ModelValidationsDemo.Models
{
    public class Person
    {
        //ALONGSIDE DEFAULT ERROR MESSAGE, WE CAN USE OUR OWN ERROR MESSAGE SUCH AS BELOW.
        [Required(ErrorMessage = "Name of person is required")]
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public double? Price { get; set; }

        public override string ToString()
        {
            return $"Person Data Received:\nName: {this.PersonName}\nEmail: {this.Email}\nPhone: {this.Phone}\nPassword: {this.Password}\nConfirmed Password: {this.ConfirmPassword}\nPrice: {this.Price}";
        }
    }
}
