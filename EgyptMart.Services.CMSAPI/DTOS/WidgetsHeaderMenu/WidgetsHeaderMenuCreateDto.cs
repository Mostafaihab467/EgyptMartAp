
using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.Models
{
        public class WidgetsHeaderMenuCreateDto
        {
        [Required]
        public string MenuItemTitle { get; set; }
        [Required]
        public byte LangID { get; set; } // Tinyint maps to byte in C#
        [Required]
        public int BasID { get; set; }
        [Required]
        public int ParentID { get; set; }
        [Required]
        [Range(0,short.MaxValue)]
        public short DisplayOrder { get; set; } // Smallint maps to short in C#
        [Required]
        public string TargetUrl { get; set; }
        }
    }


