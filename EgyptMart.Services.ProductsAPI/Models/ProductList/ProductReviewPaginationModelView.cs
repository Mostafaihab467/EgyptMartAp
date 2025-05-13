namespace EgyptMart.Services.ProductsAPI.Models
{
    public class ProductReviewPaginationModelView
    {
        public long RatingID { get; set; }
        public long ProductID { get; set; }
        public long UserID { get; set; }
        public byte RatingScore { get; set; }
        public string? RatingTitle { get; set; }
        public string? RatingDesc { get; set; }
        public DateTime RatingDate { get; set; }
        public long LinkedPO { get; set; }
        public byte ApprovalStatu { get; set; }
        public string? ApprovalStatusTitle { get; set; }
        public string? DisplayName { get; set; }
        public string? ProfileImage { get; set; }
        public int TotalCount { get; set; }


        public ProductReviewModelView GetList()
        {

            return new ProductReviewModelView
            {
                RatingID = RatingID,
                ProductID = ProductID,
                UserID = UserID,
                RatingScore = RatingScore,
                RatingTitle = RatingTitle,
                RatingDesc = RatingDesc,
                RatingDate = RatingDate,
                LinkedPO = LinkedPO,
                ApprovalStatu = ApprovalStatu,
                ApprovalStatusTitle = ApprovalStatusTitle,
                DisplayName = DisplayName,
                ProfileImage = ProfileImage

            };
        }
    }
}
