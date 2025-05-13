using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.ViewModel
{
    public class ProfileModel
    {



        [Required(ErrorMessage = "LinkID is required")]
        public long LinkID { get; set; }

        public long? UserID { get; set; } // Nullable since IsNullable = YES

        [MaxLength(int.MaxValue)] // -1 indicates max length for nvarchar(max)
        public string? CompanyTitle { get; set; }

        public short? BusinessTypeID { get; set; } // Nullable since IsNullable = YES

        [MaxLength(int.MaxValue)]
        public string? BusinessRange { get; set; }

        [MaxLength(int.MaxValue)]
        public string? BusinessProducts { get; set; }

        [MaxLength(int.MaxValue)]
        public string? RegisterdCapital { get; set; }
        

        [MaxLength(int.MaxValue)]
        public string? NumberOfEmployee { get; set; }

        [MaxLength(int.MaxValue)]
        public string? TaxRegistrationNo { get; set; }

        [MaxLength(int.MaxValue)]
        public string? CompanyBIO { get; set; }

        [MaxLength(int.MaxValue)]
        public string? TradeCapacity { get; set; }

        [MaxLength(int.MaxValue)] // varchar(max)
        public string? ProfileImage { get; set; }
    }
}



