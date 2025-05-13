using EgyptMart.Services.ProductsAPI.Models;
using EgyptMart.Services.ProductsAPI.Models.ProductList;

namespace EgyptMart.Services.ProductsAPI.IRepository
{
    public interface IProductImagesRepository
    {
        Task<int> CreateImages(long ProductID, string ImageURL, bool IsThumbMain, bool IsMain);
        Task<int> EditImages(long ImageID, string ImageURL, bool IsThumbMain, bool IsMain);
        Task<int> DeleteImages(long ImageID);
        Task<List<ProductImagesListModelView>> GetImages(long ProductID);

        Task<List<Product3DModelView>> GetProduct3DModels(long ProductID);
        Task<int> Insert3DModel(long ProductID, string Model3D);
        Task<int> Remove3DModel(long ModelID);

    }
}
