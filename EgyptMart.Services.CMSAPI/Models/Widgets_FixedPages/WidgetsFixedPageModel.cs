using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.Models.Widgets_FixedPages
{
    public class WidgetsFixedPageModel
    {

    
        public int PageID { get; set; }

        [MaxLength(150)]
        public string PageTitle { get; set; }

        public string PageBody { get; set; } // nvarchar(-1) means it stores large text (equivalent to nvarchar(MAX))

        public bool? IsActive { get; set; }

        public int? BaseID { get; set; }

        public byte? LangID { get; set; }
    }
}
