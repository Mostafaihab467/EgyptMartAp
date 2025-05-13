using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.AdsManagmentAPI.Validations
{
    public class GreaterThanValidator : ValidationAttribute
    {
        public string GreaterPropName { get; set; } = "CostBefore";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var greaterProp = validationContext.ObjectType.GetProperty(GreaterPropName);
            if (greaterProp != null && value != null)
            {
                decimal greaterValue = ((decimal)greaterProp.GetValue(validationContext.ObjectInstance)!);
                if (greaterValue <= (decimal)value)
                {
                    return new ValidationResult($"{GreaterPropName} must be greater than {validationContext.DisplayName}");
                }
            }
            return ValidationResult.Success;
        }
    }
}
