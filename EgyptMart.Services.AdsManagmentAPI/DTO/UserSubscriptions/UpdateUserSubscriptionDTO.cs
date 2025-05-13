using System.ComponentModel.DataAnnotations;
using EgyptMart.Services.AdsManagmentAPI.Validations;

namespace EgyptMart.Services.AdsManagmentAPI.DTO
{
    public class UpdateUserSubscriptionDTO
    {
        [Required(ErrorMessage = "Required")]
        public string AdsImageUrl { get; set; }
        [Required(ErrorMessage = "Required")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Required")]
        [RangeDateValidator(StartDatePropName = "StartDate")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Required")]
        public string TargetURL { get; set; }
    }
}
