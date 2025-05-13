using EgyptMart.Services.CMSAPI.Models;

namespace EgyptMart.Services.CMSAPI.IRepository
{
    public interface IProductYouMayLikeTRepository
    {

        Task<IEnumerable<ProductYouMayLikeViewModel>> GetProductsYouMayLikeAsync(byte langID);
    }
}
