using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.AdsManagmentAPI.DTO
{
    public class SetSubscriptionStatusDTO
    {
        [Required(ErrorMessage = "Required")]
        public bool IsActive { get; set; }
    }
}
