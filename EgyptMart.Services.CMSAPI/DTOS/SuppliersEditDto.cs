using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS
{
    public class SuppliersEditDto
    {
        [Required(ErrorMessage = "LinkID is required.")]
        public long LinkID { get; set; } // Matches bigint

        [Required(ErrorMessage = "CompanyTitle is required.")]

        public string CompanyTitle { get; set; } // Matches nvarchar(max)

        [Required(ErrorMessage = "BusinessTypeID is required.")]
        public short BusinessTypeID { get; set; } // Matches nvarchar(max)

        [Required(ErrorMessage = "BusinessRange is required.")]
        [MaxLength(int.MaxValue, ErrorMessage = "BusinessRange exceeds maximum length.")]
        public string BusinessRange { get; set; } // Matches nvarchar(max)

        [Required(ErrorMessage = "BusinessProducts is required.")]
        public string BusinessProducts { get; set; } // Matches nvarchar(max)

        [Required(ErrorMessage = "RegisteredCapital is required.")]
        public string RegisterdCapital { get; set; } // Matches nvarchar(max)

        [Required(ErrorMessage = "NumberOfEmployee is required.")]
        public string NumberOfEmployee { get; set; } // Matches nvarchar(max)

        [Required(ErrorMessage = "TaxRegistrationNo is required.")]
        public string TaxRegistrationNo { get; set; } // Matches nvarchar(max)

        [Required(ErrorMessage = "CompanyBIO is required.")]
        public string CompanyBIO { get; set; } // Matches nvarchar(max)

        [Required(ErrorMessage = "TradeCapacity is required.")]
        public string TradeCapacity { get; set; } // Matches nvarchar(max)
    }
}