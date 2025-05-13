namespace EgyptMart.Services.CMSAPI.Models
{
    public class SubscribtionList_GetListModel
    {
        /// <summary>
        /// The unique identifier for the subscription.
        /// </summary>
        public long SubscribeID { get; set; }

        /// <summary>
        /// The email address of the subscriber.
        /// </summary>
        public string? EMailAddress { get; set; }

        /// <summary>
        /// The date and time when the subscription was added.
        /// </summary>
        public DateTime? AddDate { get; set; }
    }
}
