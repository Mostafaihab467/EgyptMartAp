using EgyptMart.Services.CMSAPI.Data;
using EgyptMart.Services.CMSAPI.IRepository;
using EgyptMart.Services.CMSAPI.ViewModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.CMSAPI.Repository
{
    public class WishListRepository : IWishListRepository
    {
        private DBMasterContext _context;

        public WishListRepository(DBMasterContext context)
        {
            _context = context;
        }

        public Task<int> Create(Int64 ProductID, Int64 UserID)
        {
            SqlParameter ProductIDP = new("@ProductID", System.Data.SqlDbType.BigInt) { Value = ProductID };
            SqlParameter UserIDP = new("@UserID", System.Data.SqlDbType.BigInt) { Value = UserID };


            return _context.Database.ExecuteSqlRawAsync("Execute Pre_Users_WishListProducts_Create @UserID, @ProductID", UserIDP, ProductIDP);
        }

        public Task<int> Remove(Int64 ProductID, long UserID)
        {
            SqlParameter ProductIDP = new("@ProductID", System.Data.SqlDbType.BigInt) { Value = ProductID };
            SqlParameter UserIDP = new("@UserID", System.Data.SqlDbType.BigInt) { Value = UserID };


            return _context.Database.ExecuteSqlRawAsync("Execute Pre_Users_WishListProducts_Remove @ProductID, @UserID", ProductIDP, UserIDP);
        }

        public Task<List<WishListViewModel>> GetMyWishList(Int64 UserID, byte LangID)
        {
            SqlParameter UserIDP = new("@UserID", System.Data.SqlDbType.BigInt) { Value = UserID };
            SqlParameter LangIDP = new("@LangID", System.Data.SqlDbType.TinyInt) { Value = LangID };


            return _context.WishListViewModel.FromSqlRaw("Execute Pre_Users_WishListProducts_GetMyWishList @UserID, @LangID", UserIDP, LangIDP).ToListAsync();
        }

    }
}
