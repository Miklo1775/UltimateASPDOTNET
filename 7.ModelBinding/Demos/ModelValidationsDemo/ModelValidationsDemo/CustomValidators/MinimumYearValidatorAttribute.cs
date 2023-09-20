using System.ComponentModel.DataAnnotations;

namespace ModelValidationsDemo.CustomValidators
{
    public class MinimumYearValidatorAttribute : ValidationAttribute
    {
        public int MinimumYear { get; set; } = 2000;
        public string DefaultErrorMessage { get; set; } = "Year should not be less than {0}";
        //WE CAN ALSO ADD A CONSTRUCTOR TO TAKE THE VALUES FROM THE MODEL CLASS.
        public MinimumYearValidatorAttribute()
        {
        }

        public MinimumYearValidatorAttribute(int minimumYear)
        {
            this.MinimumYear = minimumYear;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                DateTime date = (DateTime)value;
                if(date.Year >= MinimumYear)
                {
                    //WE CAN ALSO PASS THE ErrorMessage VARIABLE AND SET THE VALUE WHERE WE USE THE CUSTOM ATTRIBUTE
                    //return new ValidationResult(ErrorMessage);
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumYear));
                }

                return ValidationResult.Success;
            }

            return null;
        }
    }
}
