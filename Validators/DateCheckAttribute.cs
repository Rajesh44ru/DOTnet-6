using System.ComponentModel.DataAnnotations;

namespace TestWEBAPI.Validators
{
    public class DateCheckAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //return base.IsValid(value, validationContext);
            var date = (DateTime?)value;
            if(date<DateTime.Now)
            {
                return new ValidationResult("Date Must be Greater or equals to Today date");
            }
            return ValidationResult.Success;
        }

    }
}
