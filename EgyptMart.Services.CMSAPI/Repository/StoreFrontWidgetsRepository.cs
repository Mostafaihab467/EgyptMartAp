using EgyptMart.Services.CMSAPI.Data;
using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.IRepository;
using EgyptMart.Services.CMSAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EgyptMart.Services.CMSAPI.Repository
{
    public class StoreFrontWidgetsRepository : IStoreFrontWidgetsRepository
    {

        
        private DBMasterContext _context;

        public StoreFrontWidgetsRepository(DBMasterContext context)
        {
            _context = context;
        }

        public async Task<List<ProductBasicViewModel>> GetSpecialOffers(byte langId)
        {
            var parameter = new SqlParameter("@LangID", langId);
            var query = "EXEC [dbo].[Widgets_Front_SpecialOffers] @LangID";

            var result = await _context.Set<ProductBasicViewModel>().FromSqlRaw(query, parameter).ToListAsync();


            return result;
        }

        public async Task<List<ProductBasicViewModel>> GetTrendingProducts(byte langId)
        {
            var parameter = new SqlParameter("@LangID", langId);
            var query = "EXEC [dbo].[Widgets_Front_TrendingProducts] @LangID";

            var result =  await _context.Set<ProductBasicViewModel>().FromSqlRaw(query, parameter).ToListAsync();


            return result;
        }


        public async Task<List<UserProfileImageModel>> SuccessPartners()
        {
       
            var query = "EXEC [dbo].[Widgets_Front_SuccessPartners]";

            var result = await _context.Set<UserProfileImageModel>().FromSqlRaw(query).ToListAsync();


            return result;
        }



    
    }
}
