using EgyptMart.Services.CMSAPI.DTOS.Subscription;
using EgyptMart.Services.CMSAPI.Models;

namespace EgyptMart.Services.CMSAPI.IRepository
{
    public interface ISubscribtionListRepository
    {


        Task<int> Create(string EMailAddress);


        Task<List<SubscribtionList_GetListModel>> GetList(SubscribtionList_GetListDto subscribtionList_Get);

    }
}
