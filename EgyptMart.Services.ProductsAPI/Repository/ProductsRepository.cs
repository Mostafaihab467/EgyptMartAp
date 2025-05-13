using EgyptMart.Services.ProductsAPI.Data;
using EgyptMart.Services.ProductsAPI.IRepository;
using EgyptMart.Services.ProductsAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.ProductsAPI.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DBMasterContext _context;
        public ProductsRepository(DBMasterContext context)
        {
            _context = context;
        }
        public Task<List<ProductListModelView>> Create(long OwnerID, string ProductTitle, int CategoryID, string SEOKey, string SKU, string GSCode, string ShortDesc, string FullDesc, string MinimumOrder, decimal CostBefore, decimal CostAfter, bool StockStatus, int StockSimpleCounter)
        {
            try
            {
                SqlParameter OwnerIDParam = new("@OwnerID", System.Data.SqlDbType.BigInt) { Value = OwnerID };
                SqlParameter ProductTitleParam = new("@ProductTitle", System.Data.SqlDbType.NVarChar) { Value = (object)ProductTitle ?? DBNull.Value };
                SqlParameter CategoryIDParam = new("@CategoryID", System.Data.SqlDbType.Int) { Value = CategoryID };
                SqlParameter SEOKeyParam = new("@SEOKey", System.Data.SqlDbType.NVarChar) { Value = (object)SEOKey ?? DBNull.Value };
                SqlParameter SKUParam = new("@SKU", System.Data.SqlDbType.NVarChar) { Value = (object)SKU ?? DBNull.Value };
                SqlParameter GSCodeParam = new("@GSCode", System.Data.SqlDbType.NVarChar) { Value = (object)GSCode ?? DBNull.Value };
                SqlParameter ShortDescParam = new("@ShortDesc", System.Data.SqlDbType.NVarChar) { Value = (object)ShortDesc ?? DBNull.Value };
                SqlParameter FullDescParam = new("@FullDesc", System.Data.SqlDbType.NVarChar) { Value = (object)FullDesc ?? DBNull.Value };
                SqlParameter MinimumOrderParam = new("@MinimumOrder", System.Data.SqlDbType.NVarChar) { Value = (object)MinimumOrder ?? DBNull.Value };
                SqlParameter CostBeforeParam = new("@CostBefore", System.Data.SqlDbType.Decimal) { Value = (object)CostBefore ?? DBNull.Value };
                SqlParameter CostAfterParam = new("@CostAfter", System.Data.SqlDbType.Decimal) { Value = (object)CostAfter ?? DBNull.Value };
                SqlParameter StockStatusParam = new("@StockStatus", System.Data.SqlDbType.Bit) { Value = (object)StockStatus ?? DBNull.Value };
                SqlParameter StockSimpleCounterParam = new("@StockSimpleCounter", System.Data.SqlDbType.Int) { Value = (object)StockSimpleCounter ?? DBNull.Value };




                return _context.ProductListModelView.FromSqlRaw("EXEC Products_Basic_Create @OwnerID, @ProductTitle, @CategoryID, @SEOKey, @SKU, @GSCode, @ShortDesc, @FullDesc, @MinimumOrder, @CostBefore, @CostAfter, @StockStatus, @StockSimpleCounter",
                    OwnerIDParam, ProductTitleParam, CategoryIDParam, SEOKeyParam, SKUParam, GSCodeParam, ShortDescParam, FullDescParam, MinimumOrderParam, CostBeforeParam, CostAfterParam, StockStatusParam, StockSimpleCounterParam).ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public Task<int> Translate(long ProductsID, byte LangID, string ProductTitle, string SEOKey, string ShortDesc, string FullDesc)
        {
            try
            {
                SqlParameter ProductsIDParam = new("@ProductsID", System.Data.SqlDbType.BigInt) { Value = ProductsID };
                SqlParameter LangIDParam = new("@LangID", System.Data.SqlDbType.TinyInt) { Value = LangID };
                SqlParameter ProductTitleParam = new("@ProductTitle", System.Data.SqlDbType.NVarChar) { Value = (object)ProductTitle ?? DBNull.Value };
                SqlParameter SEOKeyParam = new("@SEOKey", System.Data.SqlDbType.NVarChar) { Value = (object)SEOKey ?? DBNull.Value };
                SqlParameter ShortDescParam = new("@ShortDesc", System.Data.SqlDbType.NVarChar) { Value = (object)ShortDesc ?? DBNull.Value };
                SqlParameter FullDescParam = new("@FullDesc", System.Data.SqlDbType.NVarChar) { Value = (object)FullDesc ?? DBNull.Value };

                return _context.Database.ExecuteSqlRawAsync("EXEC Products_Basic_Translate @ProductsID, @LangID, @ProductTitle, @SEOKey, @ShortDesc, @FullDesc",
                    ProductsIDParam, LangIDParam, ProductTitleParam, SEOKeyParam, ShortDescParam, FullDescParam);
            }
            catch (Exception ex)
            {

                throw;
            }


        }


        public Task<int> Edit(int ProductID, string ProductTitle, int CategoryID, string SEOKey, string SKU, string GSCode, string ShortDesc, string FullDesc, string MinimumOrder, decimal CostBefore, decimal CostAfter)
        {
            List<SqlParameter> parameters =
                [
                    new("@ProductID", System.Data.SqlDbType.BigInt) { Value = ProductID },
                    new("@ProductTitle", System.Data.SqlDbType.NVarChar) { Value = ProductTitle },
                    new("@CategoryID", System.Data.SqlDbType.Int) { Value = CategoryID },
                    new("@SEOKey", System.Data.SqlDbType.NVarChar) { Value = SEOKey },
                    new("@SKU", System.Data.SqlDbType.NVarChar) { Value = SKU },
                    new("@GSCode", System.Data.SqlDbType.NVarChar) { Value = GSCode },
                    new("@ShortDesc", System.Data.SqlDbType.NVarChar) { Value = ShortDesc },
                    new("@FullDesc", System.Data.SqlDbType.NVarChar) { Value = FullDesc },
                    new("@MinimumOrder", System.Data.SqlDbType.NVarChar){Value = (object)MinimumOrder ?? DBNull.Value},
                    new("@CostBefore", System.Data.SqlDbType.Decimal){Value = (object)CostBefore ?? DBNull.Value},
                    new("@CostAfter", System.Data.SqlDbType.Decimal){Value = (object)CostAfter ?? DBNull.Value},
                ];

            return _context.Database.ExecuteSqlRawAsync("Execute Products_Basic_Edit @ProductID, @ProductTitle, @CategoryID, @SEOKey, @SKU, @GSCode, @ShortDesc, @FullDesc, @MinimumOrder, @CostBefore, @CostAfter", [.. parameters]);
        }

        public Task<List<ProductListPaginatedModelView>> GetMyProduct(long OwnerID, byte RepType, int PageNumber = 1, int SizePerPage = 50)
        {
            SqlParameter OwnerIDParam = new("@OwnerID", System.Data.SqlDbType.BigInt) { Value = OwnerID };
            SqlParameter RepTypeParam = new("@RepType", System.Data.SqlDbType.TinyInt) { Value = RepType };

            SqlParameter pageNumberParam = new("@PageNumber", System.Data.SqlDbType.Int) { Value = PageNumber };
            SqlParameter sizePerPageParam = new("@SizePerPage", System.Data.SqlDbType.Int) { Value = SizePerPage };


            return _context.ProductListPaginatedModelView
                .FromSqlRaw("EXEC Products_Basic_GetMyProduct @OwnerID, @RepType,  @PageNumber ,  @SizePerPage",
                OwnerIDParam, RepTypeParam, pageNumberParam, sizePerPageParam).ToListAsync();
        }

        public Task<List<ProductListPaginatedModelView>> GetMyProductByCategoryID(long OwnerID, byte RepType, int CategoryID, int PageNumber = 1, int SizePerPage = 50)
        {
            List<SqlParameter> parameters =
                [
                    new("@OwnerID", System.Data.SqlDbType.BigInt) { Value = OwnerID },
                    new("@RepType", System.Data.SqlDbType.TinyInt) { Value = RepType },
                    new("@CategoryID", System.Data.SqlDbType.Int) { Value = CategoryID },
                    new("@PageNumber", System.Data.SqlDbType.Int) { Value = PageNumber },
                 new("@SizePerPage", System.Data.SqlDbType.Int) { Value = SizePerPage }
                ];
            return _context.ProductListPaginatedModelView
                .FromSqlRaw("EXEC Products_Basic_GetMyProductByCategoryID @OwnerID, @RepType, @CategoryID, @PageNumber ,  @SizePerPage",
                [.. parameters]).ToListAsync();
        }

        public Task<List<ProductListModelView>> GetProductByID(long ProductsID)
        {
            SqlParameter ProductsIDParam = new("@ProductsID", System.Data.SqlDbType.BigInt) { Value = ProductsID };
            return _context.ProductListModelView.FromSqlRaw("EXEC Products_Basic_GetByID @ProductsID", ProductsIDParam).ToListAsync();
        }

        public Task<int> ChangeStatus(long ProductsID, bool NewProductStatus)
        {
            List<SqlParameter> parameters =
                [
                    new("@ProductsID", System.Data.SqlDbType.BigInt) { Value = ProductsID },
                    new("@NewProductStatus", System.Data.SqlDbType.Bit) { Value = NewProductStatus },
                ];
            return _context.Database.ExecuteSqlRawAsync("EXEC Products_Basic_ChangeStatus @ProductsID, @NewProductStatus", [.. parameters]);
        }

        public Task<int> ChangeStockStatus(long ProductsID, bool StockStatus, int StockSimpleCounter)
        {
            List<SqlParameter> parameters =
                [
                    new("@ProductsID", System.Data.SqlDbType.BigInt) { Value = ProductsID },
                    new("@StockStatus", System.Data.SqlDbType.Bit) { Value = StockStatus },
                    new("@StockSimpleCounter", System.Data.SqlDbType.Int) { Value = StockSimpleCounter }
                ];
            return _context.Database.ExecuteSqlRawAsync("EXEC Products_Basic_ChangeStockStatus @ProductsID, @StockStatus, @StockSimpleCounter", [.. parameters]);
        }

        public Task<List<ProductListPaginatedModelView>> GetFilteredProductsByCategory(long OwnerID, byte RepType, int CategoryID, byte LangID = 1, int PageNumber = 1, int SizePerPage = 50)
        {
            List<SqlParameter> parameters =
                [
                    new("@OwnerID", System.Data.SqlDbType.BigInt) { Value = OwnerID },
                    new("@RepType", System.Data.SqlDbType.TinyInt) { Value = RepType },
                    new("@CategoryID", System.Data.SqlDbType.Int) { Value = CategoryID },
                    new("@LangID", System.Data.SqlDbType.TinyInt) { Value = LangID },
                       new("@PageNumber", System.Data.SqlDbType.Int) { Value = PageNumber },
                 new("@SizePerPage", System.Data.SqlDbType.Int) { Value = SizePerPage }
                ];
            return _context.ProductListPaginatedModelView.FromSqlRaw("EXEC Products_Filter_ByCategory_V2 @OwnerID, @CategoryID, @RepType , @LangID , @PageNumber ,  @SizePerPage", [.. parameters]).ToListAsync();
        }

        public Task<List<ProductListModelView>> GetProductByLang(long ProductID, byte LangID)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter> {

            new("@ProductsID", System.Data.SqlDbType.BigInt) { Value = ProductID },
            new("@LangID", System.Data.SqlDbType.TinyInt) { Value = LangID },
            };
            return _context.ProductListModelView.FromSqlRaw("EXEC Products_Basic_GetSingle_ByLang @ProductsID , @LangID", sqlParameters[0], sqlParameters[1]).ToListAsync();

        }

        public Task<List<ProductListPaginatedModelView>> GetMyProductTranslated(long OwnerID, byte RepType, byte LangID, int PageNumber = 1, int SizePerPage = 50)
        {
            SqlParameter OwnerIDParam = new("@OwnerID", System.Data.SqlDbType.BigInt) { Value = OwnerID };
            SqlParameter RepTypeParam = new("@RepType", System.Data.SqlDbType.TinyInt) { Value = RepType };
            SqlParameter LangIDParam = new("@LangID", System.Data.SqlDbType.TinyInt) { Value = LangID };
            SqlParameter pageNumberParam = new("@PageNumber", System.Data.SqlDbType.Int) { Value = PageNumber };
            SqlParameter sizePerPageParam = new("@SizePerPage", System.Data.SqlDbType.Int) { Value = SizePerPage };

            return _context.ProductListPaginatedModelView.FromSqlRaw("EXEC [Products_Basic_GetMyProduct_Translation] @OwnerID, @RepType , @LangID, @PageNumber ,  @SizePerPage",
                OwnerIDParam, RepTypeParam, LangIDParam, pageNumberParam, sizePerPageParam).ToListAsync();
        }

        public Task<List<ProductListPaginatedModelView>> GetFilteredProductsByTitle(string title, byte LangID = 1, int PageNumber = 1, int SizePerPage = 50, long OwnerID = 0)
        {
            List<SqlParameter> parameters =
               [
                   new("@ProductTitle", System.Data.SqlDbType.NVarChar , 250) { Value = title.Trim() },
                    new("@LangID", System.Data.SqlDbType.TinyInt) { Value = LangID },
                             new("@PageNumber", System.Data.SqlDbType.Int) { Value = PageNumber },
            new("@SizePerPage", System.Data.SqlDbType.Int) { Value = SizePerPage },
            new("@OwnerID", System.Data.SqlDbType.BigInt) { Value = OwnerID }
                ];
            return _context.ProductListPaginatedModelView.FromSqlRaw("EXEC Products_Filter_ByTitle @ProductTitle, @LangID , @PageNumber ,  @SizePerPage , @OwnerID", [.. parameters]).ToListAsync();
        }
    }
}
