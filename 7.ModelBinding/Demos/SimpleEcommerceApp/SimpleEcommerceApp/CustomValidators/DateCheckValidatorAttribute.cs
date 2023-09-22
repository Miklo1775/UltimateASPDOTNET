using System.ComponentModel.DataAnnotations;

namespace SimpleEcommerceApp.CustomValidators
{
    public class DateCheckValidatorAttribute : ValidationAttribute
    {
        //public DateTime Date { get; set; }


        //public DateCheckValidatorAttribute(DateTime date)
        //{
        //    this.Date = date;
        //}

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null) 
            {
                DateTime submittedDate = (DateTime)value;
                if(submittedDate < Convert.ToDateTime("2000-01-01"))
                {
                    return new ValidationResult(ErrorMessage);
                }

                return ValidationResult.Success;
            }
            return null;
        }
    }
}
