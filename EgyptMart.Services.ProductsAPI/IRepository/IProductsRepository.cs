using EgyptMart.Services.ProductsAPI.Models;

namespace EgyptMart.Services.ProductsAPI.IRepository
{
    public interface IProductsRepository
    {
        Task<List<ProductListModelView>> Create(long OwnerID, string ProductTitle, int CategoryID, string SEOKey, string SKU, string GSCode, string ShortDesc, string FullDesc, string MinimumOrder, decimal CostBefore, decimal CostAfter, bool StockStatus, int StockSimpleCounter);
        Task<int> Translate(long ProductsID, byte LangID, string ProductTitle, string SEOKey, string ShortDesc, string FullDesc);
        Task<int> Edit(int ProductID, string ProductTitle, int CategoryID, string SEOKey, string SKU, string GSCode, string ShortDesc, string FullDesc, string MinimumOrder, decimal CostBefore, decimal CostAfter);
        Task<List<ProductListModelView>> GetProductByID(long ProductID);
        Task<List<ProductListPaginatedModelView>> GetMyProduct(long OwnerID, byte RepType, int PageNumber = 1, int SizePerPage = 50);
        Task<List<ProductListPaginatedModelView>> GetMyProductByCategoryID(long OwnerID, byte RepType, int CategoryID, int PageNumber = 1, int SizePerPage = 50);
        Task<List<ProductListPaginatedModelView>> GetFilteredProductsByCategory(long OwnerID, byte RepType, int CategoryID, byte LangID = 1, int PageNumber = 1, int SizePerPage = 50);
        Task<List<ProductListPaginatedModelView>> GetFilteredProductsByTitle(string title, byte LangID = 1, int PageNumber = 1, int SizePerPage = 50, long ownerID = 0);
        Task<int> ChangeStatus(long ProductsID, bool NewProductStatus);
        Task<int> ChangeStockStatus(long ProductsID, bool StockStatus, int StockSimpleCounter);
        Task<List<ProductListModelView>> GetProductByLang(long ProductID, byte LangID);
        Task<List<ProductListPaginatedModelView>> GetMyProductTranslated(long OwnerID, byte RepType, byte LangID, int PageNumber = 1, int SizePerPage = 50);
    }
}
