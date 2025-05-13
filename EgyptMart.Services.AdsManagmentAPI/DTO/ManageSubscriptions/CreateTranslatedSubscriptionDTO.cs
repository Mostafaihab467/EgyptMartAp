using System.ComponentModel.DataAnnotations;
using EgyptMart.Services.AdsManagmentAPI.Validations;

namespace EgyptMart.Services.AdsManagmentAPI.DTO
{
    public class CreateTranslatedSubscriptionDTO
    {
        [Required(ErrorMessage = "Required")]
        public string PlanTitle { get; set; }
        [Required(ErrorMessage = "Required")]
        public string PlanDescription { get; set; }
        [Required(ErrorMessage = "Required")]
        [Range(0, 255)]
        public byte LangID { get; set; }
        [Required(ErrorMessage = "Required")]
        [MinValidator(0)]
        public long BasePlanID { get; set; }
    }
}
