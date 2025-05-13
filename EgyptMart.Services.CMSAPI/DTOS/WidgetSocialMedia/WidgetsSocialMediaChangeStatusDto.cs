using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS.WidgetSocialMedia
{
    public class WidgetsSocialMediaChangeStatusDto
    {
        [Required(ErrorMessage = "LinkID Must Be Included")]
        public short LinkID { get; set; } // short because the procedure takes a smallint

        [Required(ErrorMessage = "NewStatus Must Be Included")]
        public bool NewStatus { get; set; } // bit value (true or false)
    }
}
