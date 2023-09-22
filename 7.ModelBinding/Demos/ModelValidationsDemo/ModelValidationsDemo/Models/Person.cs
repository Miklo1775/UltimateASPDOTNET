using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ModelValidationsDemo.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationsDemo.Models
{
    public class Person : IValidatableObject
    {
        //ALONGSIDE DEFAULT ERROR MESSAGE, WE CAN USE OUR OWN ERROR MESSAGE SUCH AS BELOW.
        //THE DISPLAY ATTRIBUTE CAN DISPLAY THE VALUE INSTEAD OF THE PROPERTY.
        //SO THE {0} WILL BE "Person Name" and not "PersonName".
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} to {1} characters")]
        [RegularExpression("^[A-Za-z .]*$", ErrorMessage = "{0} should only be alphabetical characters.")]
        public string? PersonName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email should be a valid email format.")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "{0} must be a valid phone number")]
        //[ValidateNever]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Compare("Password", ErrorMessage = "{0} and {1} do not match")]
        [Display(Name = "Re-enter Password")]
        public string? ConfirmPassword { get; set; }
        [Range(0, 999.99, ErrorMessage = "{0} should be a value between {1} and {2}")]
        public double? Price { get; set; }

        //BINDNEVER WILL ALLOW TO BIND ALL PROPERTIES WITH THE EXCEPTION OF THE ONES YOU SPECIFY.
        //[BindNever]
        [MinimumYearValidator(2005, ErrorMessage = "Year should be less than {0}")]
        public DateTime? DateOfBirth { get; set; }

        public DateTime? FromDate {  get; set; }

        [DateRangeValidator("FromDate", ErrorMessage = "From date should be older than To Date.")]
        public DateTime? ToDate { get; set; }

        public int? Age { get; set; }

        public override string ToString()
        {
            return $"Person Data Received:\nName: {this.PersonName}\nEmail: {this.Email}\nPhone: {this.Phone}\nPassword: {this.Password}\nConfirmed Password: {this.ConfirmPassword}\nPrice: {this.Price}\nDate of Birth: {this.DateOfBirth}";
        }

        //THIS VALIDATE METHOD WILL ONLY RUN AFTER THE ABOVE VALIDATIONS ARE CLEARED
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(DateOfBirth.HasValue == false && Age.HasValue == false)
            {
               yield return new ValidationResult("Either Date of Birth or Age needs to be supplied.", new[] { nameof(Age) });
            }
        }
    }
}
