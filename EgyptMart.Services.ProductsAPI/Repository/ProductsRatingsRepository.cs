using EgyptMart.Services.ProductsAPI.Data;
using EgyptMart.Services.ProductsAPI.IRepository;
using EgyptMart.Services.ProductsAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.ProductsAPI.Repository
{
    public class ProductsRatingsRepository : IProductsRatingsRepository
    {

        private readonly DBMasterContext _context;
        public ProductsRatingsRepository(DBMasterContext context)
        {
            _context = context;
        }

        public Task<int> ApproveRating(long RatingID, byte ApprovalStatu, long ActionBy)
        {
            List<SqlParameter> parameters =
                [
                    new("@RatingID", System.Data.SqlDbType.BigInt) { Value = RatingID },
                    new("@ApprovalStatu", System.Data.SqlDbType.TinyInt) { Value = ApprovalStatu },
                    new("@ActionBy", System.Data.SqlDbType.BigInt) { Value = ActionBy },
                ];
            return _context.Database.ExecuteSqlRawAsync("EXEC Products_Ratings_Approve @RatingID, @ApprovalStatu, @ActionBy", [.. parameters]);
        }

        public Task<int> CreateRating(long ProductID, long UserID, byte RatingScore, string RatingTitle, long LinkedPO, string RatingDesc)
        {
            List<SqlParameter> parameters =
                [
                    new("@ProductID", System.Data.SqlDbType.BigInt) { Value = ProductID },
                    new("@UserID", System.Data.SqlDbType.BigInt) { Value = UserID },
                    new("@RatingScore", System.Data.SqlDbType.TinyInt) { Value = RatingScore },
                    new("@RatingTitle", System.Data.SqlDbType.NVarChar) { Value = RatingTitle },
                    new("@LinkedPO", System.Data.SqlDbType.BigInt) { Value = LinkedPO },
                    new("@RatingDesc", System.Data.SqlDbType.NVarChar) { Value = RatingDesc },
                ];
            return _context.Database.ExecuteSqlRawAsync("EXEC Products_Ratings_Create @ProductID, @UserID, @RatingScore, @RatingTitle, @RatingDesc, @LinkedPO", [.. parameters]);
        }

        public Task<int> EditRating(long RatingID, byte RatingScore, string RatingTitle, string RatingDesc)
        {
            List<SqlParameter> parameters =
                [
                    new("@RatingID", System.Data.SqlDbType.BigInt) { Value = RatingID },
                    new("@RatingScore", System.Data.SqlDbType.TinyInt) { Value = RatingScore },
                    new("@RatingTitle", System.Data.SqlDbType.NVarChar) { Value = RatingTitle },
                    new("@RatingDesc", System.Data.SqlDbType.NVarChar) { Value = RatingDesc },
                ];
            return _context.Database.ExecuteSqlRawAsync("EXEC Products_Ratings_Edit @RatingID, @RatingScore, @RatingTitle, @RatingDesc", [.. parameters]);
        }

        public Task<List<ProductReviewPaginationModelView>> GetProductReviews(long ProductsID, byte RepType, int PageNumber = 1, int SizePerPage = 50)
        {
            SqlParameter ProductsIDParam = new("@ProductsID", System.Data.SqlDbType.BigInt) { Value = ProductsID };
            SqlParameter RepTypeParam = new("@RepType", System.Data.SqlDbType.TinyInt) { Value = RepType };
            SqlParameter pageNumberParam = new("@PageNumber", System.Data.SqlDbType.Int) { Value = PageNumber };
            SqlParameter sizePerPageParam = new("@SizePerPage", System.Data.SqlDbType.Int) { Value = SizePerPage };

            return _context.ProductReviewPaginationModelView.FromSqlRaw("EXEC Products_Ratings_GetByProductID @ProductsID, @RepType , @PageNumber ,  @SizePerPage",
                ProductsIDParam, RepTypeParam, pageNumberParam, sizePerPageParam).ToListAsync();
        }
    }
}
