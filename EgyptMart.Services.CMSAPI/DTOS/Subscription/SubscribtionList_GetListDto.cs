using EgyptMart.Services.CMSAPI.Validation;
using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS.Subscription
{
    public class SubscribtionList_GetListDto
    {
        /// <summary>
        /// The start date for the query.
        /// </summary>
        [Required]
        [DateValidation()]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The end date for the query.
        /// </summary>
        [Required]
        public DateTime EndDate { get; set;}
    }
}
