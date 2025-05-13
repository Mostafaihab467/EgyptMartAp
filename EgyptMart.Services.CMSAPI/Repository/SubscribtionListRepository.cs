using EgyptMart.Services.CMSAPI.Data;
using EgyptMart.Services.CMSAPI.DTOS.Subscription;
using EgyptMart.Services.CMSAPI.IRepository;
using EgyptMart.Services.CMSAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EgyptMart.Services.CMSAPI.Repository
{
    public class SubscribtionListRepository : ISubscribtionListRepository
    {


        private DBMasterContext _context;

        public SubscribtionListRepository(DBMasterContext context)
        {
            _context = context;
        }




        public async Task<int> Create(string EMailAddress) {

            var parameters = new List<SqlParameter>{
            new SqlParameter("@EMailAddress", SqlDbType.NVarChar) { Value = EMailAddress },

            };


        var result = await _context.Database.ExecuteSqlRawAsync(
              "EXEC [dbo].[Widgets_SubscribtionList_Create] @EMailAddress",
              parameters.ToArray()
          );

            return result;

        }


        public async Task<List<SubscribtionList_GetListModel>> GetList(SubscribtionList_GetListDto subscribtionList_Get)
        {
            var parameters = new List<SqlParameter>()
            {
                  new SqlParameter("@StartDate ", SqlDbType.Date) { Value = subscribtionList_Get.StartDate },
                  new SqlParameter("@EndDate", SqlDbType.Date) { Value = subscribtionList_Get.EndDate },
            };

            // Example usage with Dapper or Entity Framework
            var results = await _context.Set<SubscribtionList_GetListModel>().FromSqlRaw(
                "EXEC [dbo].[Widgets_SubscribtionList_GetList] @StartDate , @EndDate",
                parameters.ToArray()

            ).ToListAsync();

            return results;
        }

    }
}
