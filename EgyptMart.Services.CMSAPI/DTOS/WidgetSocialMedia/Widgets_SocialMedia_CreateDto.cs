using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS.WidgetSocialMedia
{


    public class Widgets_SocialMedia_CreateDto
    {
        [Required(ErrorMessage = "LinkTitle must be included.")]
        [StringLength(50, ErrorMessage = "LinkTitle cannot be longer than 50 characters.")]
        public string LinkTitle { get; set; } // Matches nvarchar(50)

        [Required(ErrorMessage = "LinkTarget must be included.")]
        [StringLength(50, ErrorMessage = "LinkTarget cannot be longer than 50 characters.")]
        public string LinkTarget { get; set; } // Matches nvarchar(50)

        [Required(ErrorMessage = "DisplayOrder must be included.")]
        [Range(1, short.MaxValue, ErrorMessage = "DisplayOrder must be a positive number.")]
        public short DisplayOrder { get; set; } // Matches smallint

        [Required(ErrorMessage = "LinkIcon must be included.")]
        public string LinkIcon { get; set; } // Matches nvarchar(max)
    }
}


