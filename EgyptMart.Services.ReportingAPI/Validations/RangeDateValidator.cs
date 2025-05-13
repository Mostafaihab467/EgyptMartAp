using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ReportingAPI.Validations
{
    public class RangeDateValidator : ValidationAttribute
    {
        public string StartDatePropName { get; set; } = "StartDate";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var startProp = validationContext.ObjectType.GetProperty(StartDatePropName);
            if (startProp == null) return new ValidationResult($"{StartDatePropName} Required First");
            DateTime? startdate = (DateTime?)startProp.GetValue(validationContext.ObjectInstance);
            DateTime? enddate = (DateTime?)value;
            if (!startdate.HasValue && value == null) return new ValidationResult($"{StartDatePropName} and {validationContext.DisplayName} requried");
            if (startdate!.Value >= enddate) return new ValidationResult($"{validationContext.DisplayName} must be greater than {StartDatePropName}");
            return ValidationResult.Success;
        }
    }
}
