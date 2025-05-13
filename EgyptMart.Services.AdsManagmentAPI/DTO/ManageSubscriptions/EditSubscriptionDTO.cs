using System.ComponentModel.DataAnnotations;
using EgyptMart.Services.AdsManagmentAPI.Validations;

namespace EgyptMart.Services.AdsManagmentAPI.DTO
{
    public class EditSubscriptionDTO
    {
        [Required(ErrorMessage = "Required")]
        public string PlanTitle { get; set; }
        [Required(ErrorMessage = "Required")]
        [MinValidator(0)]
        public short LocationID { get; set; }
        [Required(ErrorMessage = "Required")]
        [Range(0, 255)]
        public byte DurationDays { get; set; }
        [Required(ErrorMessage = "Required")]
        [MinValidator(0)]
        public decimal CostBefore { get; set; }
        [Required(ErrorMessage = "Required")]
        [MinValidator(0)]
        [GreaterThanValidator]
        public decimal Cost { get; set; }
        [Required(ErrorMessage = "Required")]
        public string PlanDescription { get; set; }

    }
}
