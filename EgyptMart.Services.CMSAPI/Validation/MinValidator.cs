using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.Validations
{
    public class MinValidator : ValidationAttribute
    {
        public double Min { get; }

        // Constructor to set the minimum value for validation
        public MinValidator(double min)
        {
            Min = min;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            double numericValue;

            // Handle different numeric types
            switch (value)
            {
                case byte byteValue:
                    numericValue = byteValue;
                    break;
                case short shortValue:
                    numericValue = shortValue;
                    break;
                case int intValue:
                    numericValue = intValue;
                    break;
                case long longValue:
                    numericValue = longValue;
                    break;
                case decimal decimalValue:
                    numericValue = (double)decimalValue;
                    break;
                case float floatValue:
                    numericValue = floatValue;
                    break;
                case double doubleValue:
                    numericValue = doubleValue;
                    break;
                default:
                    // Return an error if the value is not a numeric type
                    return new ValidationResult("The field must be a numeric type (byte, short, int, long, float, decimal, or double).");
            }

            // Check if the numeric value is less than the minimum value
            if (numericValue < Min)
            {
                return new ValidationResult($"The {validationContext.DisplayName} field must be greater than or equal to {Min}.");
            }

            // Return success if validation passes
            return ValidationResult.Success;
        }
    }
}
