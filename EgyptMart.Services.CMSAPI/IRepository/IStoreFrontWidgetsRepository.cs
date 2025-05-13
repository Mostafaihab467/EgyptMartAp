using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.Models;

namespace EgyptMart.Services.CMSAPI.IRepository
{
    public interface IStoreFrontWidgetsRepository
    {

        Task<List<ProductBasicViewModel>> GetTrendingProducts(byte langId);


        Task<List<ProductBasicViewModel>> GetSpecialOffers(byte langId);


        Task<List<UserProfileImageModel>> SuccessPartners();



    }
}
