using System.ComponentModel.DataAnnotations;

public class WidgetsSocialMediaEditDto
{
    [Required(ErrorMessage = "LinkID is required.")]
    public short LinkID { get; set; } // smallint in the database

    [Required(ErrorMessage = "LinkTitle is required.")]
    [MaxLength(50, ErrorMessage = "LinkTitle must not exceed 50 characters.")]
    public string LinkTitle { get; set; } // nvarchar(50)

    [Required(ErrorMessage = "LinkTarget is required.")]
    [MaxLength(50, ErrorMessage = "LinkTarget must not exceed 50 characters.")]
    public string LinkTarget { get; set; } // nvarchar(50)

    [Required(ErrorMessage = "DisplayOrder is required.")]
    public short DisplayOrder { get; set; } // smallint in the database

    [Required(ErrorMessage = "LinkIcon is required.")]
    public string LinkIcon { get; set; } // nvarchar(max)
}
