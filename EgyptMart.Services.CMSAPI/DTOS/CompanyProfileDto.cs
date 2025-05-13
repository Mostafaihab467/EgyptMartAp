using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS
{
    public class CompanyProfileDto
    {
        [Required(ErrorMessage = "UserID Must Be Included")]
        public long UserID { get; set; } // Matches bigint

        [Required(ErrorMessage = "CompanyTitle Must Be Included")]
        public string CompanyTitle { get; set; } // Matches nvarchar(max)

        [Required(ErrorMessage = "BusinessTypeID Must Be Included")]
        public short BusinessTypeID { get; set; } // Matches smallint

        [Required(ErrorMessage = "BusinessRange Must Be Included")]
        public string BusinessRange { get; set; } // Matches nvarchar(max)

        [Required(ErrorMessage = "BusinessProducts Must Be Included")]
        public string BusinessProducts { get; set; } // Matches nvarchar(max)

        [Required(ErrorMessage = "RegisteredCapital Must Be Included")]
        public string RegisteredCapital { get; set; } // Matches nvarchar(max)

        [Required(ErrorMessage = "NumberOfEmployee Must Be Included")]
        public int NumberOfEmployee { get; set; } // Matches int

        [Required(ErrorMessage = "TaxRegistrationNo Must Be Included")]
        public string TaxRegistrationNo { get; set; } // Matches nvarchar(max)

        [Required(ErrorMessage = "CompanyBIO Must Be Included")]
        public string CompanyBIO { get; set; } // Matches nvarchar(max)

        [Required(ErrorMessage = "TradeCapacity Must Be Included")]
        public string TradeCapacity { get; set; } // Matches nvarchar(max)
    }
}
