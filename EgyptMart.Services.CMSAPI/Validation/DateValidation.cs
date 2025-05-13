using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.Validation
{
    public class DateValidation : ValidationAttribute     
    {

        public int MinimumDays { get; set; } = 0;
        public int MinmumMonth { get; set; } = 0;
        public int MinmumYear { get; set; } = 0;

        public DateValidation(int MinimumDays = 0 ,int MinmumMonth = 0,int MinmumYear = 0)
        {
            this.MinimumDays = MinimumDays;
            this.MinmumMonth = MinmumMonth;
            this.MinmumYear = MinmumYear;
        }



        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var objType = validationContext.ObjectType;

            var startDateProperty = objType.GetProperty("StartDate");
            var endDateProperty = objType.GetProperty("EndDate");

            if (startDateProperty == null || endDateProperty == null)
            {
                return new ValidationResult("The object does not contain StartDate and EndDate properties.");
            }

            var startDateValue = (DateTime)startDateProperty.GetValue(validationContext.ObjectInstance);
            var endDateValue = (DateTime)endDateProperty.GetValue(validationContext.ObjectInstance);

            if (startDateValue.AddYears(MinmumYear).AddMonths(MinmumMonth).AddDays(MinimumDays) >= endDateValue)
            {
                return new ValidationResult("StartDate must be less than EndDate.");
            }

            return ValidationResult.Success;
        }
    }

}
