using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.Models;

namespace EgyptMart.Services.CMSAPI.IRepository
{
    public interface IContactCustomerRepository
    {
        public Task<List<CreateContactCustomerModel>> Create(CreateContactCustomerDTO dto);
        public Task<List<ContactCustomerListModel>> GetList(long userID);
        public Task<List<ContactCustomerReplysModel>> GetSingleReplys(long contactID, long userID);
        public Task<int> SupplierReply(ReplyContactCustomerDTO dto);
        public Task<int> AddMessage(AddContactCustomerMessageDTO dto);
    }
}
