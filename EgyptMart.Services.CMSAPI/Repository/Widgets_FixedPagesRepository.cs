using System.Data;
using EgyptMart.Services.CMSAPI.Data;
using EgyptMart.Services.CMSAPI.DTOS.Widgets_FixedPages;
using EgyptMart.Services.CMSAPI.IRepository;
using EgyptMart.Services.CMSAPI.Models.Widgets_FixedPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.CMSAPI.Repository
{
    public class Widgets_FixedPagesRepository : IWidgets_FixedPagesRepository
    {

        private DBMasterContext _context;
        public Widgets_FixedPagesRepository(DBMasterContext context)
        {
            _context = context;
        }



        public async Task<int> Create(FixedPages_CreateDto model)
        {

            // finish

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@PageTitle", SqlDbType.NVarChar) { Value = model.PageTitle },
                new SqlParameter("@PageBody", SqlDbType.NVarChar) { Value = model.PageBody },
            };

            var result = await _context.Database.ExecuteSqlRawAsync(
               "EXEC [dbo].[Widgets_FixedPages_Create]  @PageTitle , @PageBody", parameters.ToArray()
           );

            return result;

        }


        public async Task<int> Edit(FixedPages_EditDto model)
        {

            // finish

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@PageID", SqlDbType.Int) { Value = model.PageID },
                new SqlParameter("@PageTitle", SqlDbType.NVarChar) { Value = model.PageTitle },
                new SqlParameter("@PageBody", SqlDbType.NVarChar) { Value = model.PageBody },
            };

            var result = await _context.Database.ExecuteSqlRawAsync(
               "EXEC [dbo].[Widgets_FixedPages_Edit] @PageID , @PageTitle , @PageBody", parameters.ToArray()
           );

            return result;

        }



        public async Task<int> ChangeStatus(FixedPages_ChangeStatusDto model)
        {



            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@PageID", SqlDbType.Int) { Value = model.PageID },
                new SqlParameter("@IsActive", SqlDbType.Bit) { Value = model.IsActive },

            };

            var result = await _context.Database.ExecuteSqlRawAsync(
               "EXEC [dbo].[Widgets_FixedPages_ChangeStatus]  @PageID , @IsActive", parameters.ToArray()
           );

            return result;

        }



        public async Task<WidgetsFixedPageModel> GetByID(int PageID)
        {


            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@PageID", SqlDbType.Int) { Value = PageID },


            };
            var result = await _context.Set<WidgetsFixedPageModel>().FromSqlRaw(
               "EXEC [dbo].[Widgets_FixedPages_GetByID]  @PageID  ", parameters.ToArray()
           ).ToListAsync();

            return result.FirstOrDefault();

        }

        public async Task<List<WidgetsFixedPageModel>> GetList(byte LangID = 1)
        {
            List<SqlParameter> sqlParameters = [
                new("@LangID", SqlDbType.TinyInt) { Value = LangID }
                ];


            var result = await _context.Set<WidgetsFixedPageModel>().FromSqlRaw(
               "EXEC [dbo].[Widgets_FixedPages_GetAdmin] @LangID",
               sqlParameters.ToArray()
           ).ToListAsync();

            return result;

        }



        public async Task<int> Translate(WidgetsFixedPagesTranslateDto model)
        {

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@BaseID", SqlDbType.Int) { Value = model.BaseID },
                new SqlParameter("@LangID", SqlDbType.TinyInt) { Value = model.LangID },
                new SqlParameter("@PageTitle", SqlDbType.NVarChar) { Value = model.PageTitle },
                new SqlParameter("@PageBody", SqlDbType.NVarChar) { Value = model.PageBody },


            };

            var result = await _context.Database.ExecuteSqlRawAsync(
               "EXEC [dbo].[Widgets_FixedPages_Translate]   @BaseID , @LangID, @PageTitle , @PageBody  ", parameters.ToArray()
           );

            return result;

        }



        public async Task<List<WidgetsFixedPageModel>> GetByLang(int BaseID, byte LangeID)
        {

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@BaseID", SqlDbType.Int) { Value = BaseID },
                new SqlParameter("@LangID", SqlDbType.TinyInt) { Value = LangeID },


            };

            var result = await _context.Set<WidgetsFixedPageModel>().FromSqlRaw(
               "EXEC [dbo].[Widgets_FixedPages_GetByLang]  @BaseID , @LangID ", parameters.ToArray()
           ).ToListAsync();

            return result;

        }
    }

    //@PageID int, @LangID tinyint






}