using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS.Subscription
{
    public class SubscribtionList_CreateDTOS
    {
        [EmailAddress]
        public string EMailAddress { get; set; }
    }
}
