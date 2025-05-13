using EgyptMart.Services.CMSAPI.ViewModel;

namespace EgyptMart.Services.CMSAPI.IRepository
{
    public interface IWishListRepository
    {
        Task<int> Create(Int64 ProductID, Int64 UserID);
        Task<int> Remove(Int64 ProductID, long UserID);

        Task<List<WishListViewModel>> GetMyWishList(Int64 UserID, byte LangID);
    }
}
