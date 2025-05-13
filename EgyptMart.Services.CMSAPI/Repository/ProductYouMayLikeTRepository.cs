using EgyptMart.Services.CMSAPI.Data;
using EgyptMart.Services.CMSAPI.IRepository;
using EgyptMart.Services.CMSAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EgyptMart.Services.CMSAPI.Repository
{
    public class ProductYouMayLikeTRepository : IProductYouMayLikeTRepository
    {
        private DBMasterContext _context;

        public ProductYouMayLikeTRepository(DBMasterContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductYouMayLikeViewModel>> GetProductsYouMayLikeAsync(byte langID)
        {
            var parameters = new List<SqlParameter>() { 
            new SqlParameter("@LangID",  DbType.Byte){ Value = langID}
            };
            

            var result = await _context.Set<ProductYouMayLikeViewModel>().FromSqlRaw(
                "EXEC [dbo].[Widgets_Front_ProductYouMayLike] @LangID",
                parameters.ToArray()
               
            ).ToListAsync();
            return result;
        }
    }
}
