using System.ComponentModel.DataAnnotations;
using EgyptMart.Services.AdsManagmentAPI.Validations;

namespace EgyptMart.Services.AdsManagmentAPI.DTO
{
    public class UserSubscriptionsCreateDTO
    {
        [Required(ErrorMessage = "Required")]
        [MinValidator(0)]
        public long UserID { get; set; }
        [Required(ErrorMessage = "Required")]
        [MinValidator(0)]
        public long PlanID { get; set; }
        [Required(ErrorMessage = "Required")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Required")]
        [RangeDateValidator]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Required")]
        [MinValidator(0)]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Required")]
        public string TargetURL { get; set; }

        public byte[] ImageFile { get; set; }
    }
}
