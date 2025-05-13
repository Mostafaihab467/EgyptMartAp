using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.Auth.Validations
{
    public class IsMatchValidator : ValidationAttribute
    {
        public string PropName { get; set; } = "NewPassword";
        public bool UnEqual { get; set; } = false;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var prop = validationContext.ObjectType.GetProperty(PropName);
            if (prop != null && value != null)
            {
                string propValue = ((string)prop.GetValue(validationContext.ObjectInstance)!).Trim().ToLower();


                if (UnEqual && propValue == ((string)value).Trim().ToLower())
                {
                    return new ValidationResult($"{PropName} must not equal {validationContext.DisplayName}");
                }

                if (!UnEqual && propValue != ((string)value).Trim().ToLower())
                {
                    return new ValidationResult($"{PropName} must equal {validationContext.DisplayName}");
                }



            }
            return ValidationResult.Success;
        }
    }
}
