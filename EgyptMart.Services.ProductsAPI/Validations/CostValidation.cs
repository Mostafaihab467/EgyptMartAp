using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EgyptMart.Services.ProductsAPI.Validations
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;

    public class CostValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var objType = validationContext.ObjectType;

            // Get the properties dynamically
            var costBeforeProperty = objType.GetProperty("CostBefore", BindingFlags.Public | BindingFlags.Instance);
            var costAfterProperty = objType.GetProperty("CostAfter", BindingFlags.Public | BindingFlags.Instance);

            if (costBeforeProperty == null || costAfterProperty == null)
            {
                return new ValidationResult("The object does not contain CostBefore and CostAfter properties.");
            }

            var costBeforeValue = (decimal)costBeforeProperty.GetValue(validationContext.ObjectInstance);
            var costAfterValue = (decimal)costAfterProperty.GetValue(validationContext.ObjectInstance);

            if (costBeforeValue <= costAfterValue)
            {
                return new ValidationResult("CostBefore cannot be greater than CostAfter.");
            }

            return ValidationResult.Success;
        }
    }

}
