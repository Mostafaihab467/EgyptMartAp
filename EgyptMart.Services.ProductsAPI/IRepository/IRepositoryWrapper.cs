using EgyptMart.Services.ProductsAPI.Repository;

namespace EgyptMart.Services.ProductsAPI.IRepository
{
    public interface IRepositoryWrapper
    {
        ICategoryListRepository CategoryListRepository { get; }
        IAttributeRepository AttributeRepository { get; }
        IProductsRepository ProductsRepository { get; }
        IProductAttributeRepository ProductAttributeRepository { get; }
        IProductsRatingsRepository ProductsRatingsRepository { get; }
        IProductImagesRepository ProductImagesRepository { get; }
    }
}
