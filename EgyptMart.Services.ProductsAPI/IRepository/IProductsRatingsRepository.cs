using EgyptMart.Services.ProductsAPI.Models;

namespace EgyptMart.Services.ProductsAPI.IRepository
{
    public interface IProductsRatingsRepository
    {
        Task<int> CreateRating(long ProductID, long UserID, byte RatingScore, string RatingTitle, long LinkedPO, string RatingDesc);
        Task<int> EditRating(long RatingID, byte RatingScore, string RatingTitle, string RatingDesc);
        Task<int> ApproveRating(long RatingID, byte ApprovalStatu, long ActionBy);
        Task<List<ProductReviewPaginationModelView>> GetProductReviews(long ProductsID, byte RepType, int PageNumber = 1, int SizePerPage = 50);
    }
}
