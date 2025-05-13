using EgyptMart.Services.CMSAPI.Data;
using EgyptMart.Services.CMSAPI.DTOS.WidgetsHeaderMenu;
using EgyptMart.Services.CMSAPI.IRepository;
using EgyptMart.Services.CMSAPI.Models;
using EgyptMart.Services.CMSAPI.Models.WidgetHeaderMenue;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EgyptMart.Services.CMSAPI.Repository
{
    public class Widgets_HeaderMenu_Repository : IWidgets_HeaderMenu_Repository
    {
        private DBMasterContext _context;

        public Widgets_HeaderMenu_Repository(DBMasterContext context)
        {
            _context = context;
        }

        public async Task<int> CreateHeaderMenuAsync(WidgetsHeaderMenuCreateDto headerMenuDto)
        {
           
            var parameters = new List<SqlParameter>
    {
        new SqlParameter("@MenuItemTitle", SqlDbType.VarChar, 50) { Value = headerMenuDto.MenuItemTitle },
        new SqlParameter("@LangID", SqlDbType.TinyInt) { Value = headerMenuDto.LangID },
        new SqlParameter("@BasID", SqlDbType.Int) { Value = headerMenuDto.BasID },
        new SqlParameter("@ParentID", SqlDbType.Int) { Value = headerMenuDto.ParentID },
        new SqlParameter("@DisplayOrder", SqlDbType.SmallInt) { Value = headerMenuDto.DisplayOrder },
        new SqlParameter("@TargetUrl", SqlDbType.NVarChar) { Value = headerMenuDto.TargetUrl }
    };

            var result = await _context.Database.ExecuteSqlRawAsync(
                "EXEC [dbo].[Widgets_HeaderMenu_Create] @MenuItemTitle, @LangID, @BasID, @ParentID, @DisplayOrder, @TargetUrl",
                parameters.ToArray()
            );

            return result;
        }

        public async Task<int> EditHeaderMenuAsync(WidgetsHeaderMenuEditDto headerMenuDto)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@MenuItemID", SqlDbType.Int) { Value = headerMenuDto.MenuItemID },
                new SqlParameter("@MenuItemTitle", SqlDbType.VarChar, 50) { Value = headerMenuDto.MenuItemTitle },
                new SqlParameter("@DisplayOrder", SqlDbType.SmallInt) { Value = headerMenuDto.DisplayOrder },
                new SqlParameter("@TargetUrl", SqlDbType.NVarChar) { Value = headerMenuDto.TargetUrl }
            };

                var result = await _context.Database.ExecuteSqlRawAsync(
                        "EXEC [dbo].[Widgets_HeaderMenu_Edit] @MenuItemID, @MenuItemTitle, @DisplayOrder, @TargetUrl",
                        parameters.ToArray()
                );  

            return result;
        }

        public async Task<List<WidgetsHeaderMenuGetTopLevelModel>> GetTopLevelHeaderMenusAsync(int repType, int langID)

        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@RepType", SqlDbType.Int) { Value = repType },
                new SqlParameter("@LangID", SqlDbType.Int) { Value = langID }
            };

            var result = await _context.Set<WidgetsHeaderMenuGetTopLevelModel>()
                .FromSqlRaw("EXEC [dbo].[Widgets_HeaderMenu_GetTopLevel] @RepType, @LangID", parameters.ToArray())
                .ToListAsync();

            return result;
        }

        public async Task<List<WidgetsHeaderMenuModel>> GetChildWidgetsHeaderMenuAsync(WidgetsHeaderMenuGetChildDtos request)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@RepType", SqlDbType.TinyInt) { Value = request.RepType },
                new SqlParameter("@LangID", SqlDbType.SmallInt) { Value = request.LangID },
                new SqlParameter("@ParentID", SqlDbType.BigInt) { Value = request.ParentID }
            };

           
                return await _context.Set<WidgetsHeaderMenuModel>()
                    .FromSqlRaw("EXEC [dbo].[Widgets_HeaderMenu_GetChild] @RepType, @LangID, @ParentID", parameters.ToArray())
                    .ToListAsync();
            }

        public async Task<int> ChangeStatus(WidgetsHeaderMenueChangeStatusDto widgetsHeaderMenueChangeStatusDto)
        {

            var parameters = new List<SqlParameter>
            {
                 new SqlParameter("@MenuItemID" ,DbType.Int32) {Value =  widgetsHeaderMenueChangeStatusDto.MenuItemID },
                 new SqlParameter("@NewStatus" ,DbType.Boolean) {Value =  widgetsHeaderMenueChangeStatusDto.NewStatus}


            };

            var result = await _context.Database.ExecuteSqlRawAsync(
                "EXEC [dbo].[Widgets_HeaderMenu_ChangeStatus] @MenuItemID, @NewStatus",
                parameters.ToArray()
            );

            return result;
        }

        public async Task<int> TranslateHeaderMenuItem(int BasID, string MenuItemTitle, short LangID)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@BasID", SqlDbType.Int) { Value = BasID },
                new SqlParameter("@MenuItemTitle", SqlDbType.NVarChar, 50) { Value = MenuItemTitle },
                new SqlParameter("@LangID", SqlDbType.TinyInt) { Value = LangID }
            };

            var result = await _context.Database.ExecuteSqlRawAsync(
                 "EXEC [dbo].[Widgets_HeaderMenu_Translate] @BasID, @MenuItemTitle, @LangID", parameters.ToArray());

            return result;
        }

        public async Task<List<HeaderMenuModel>> HeaderMenu_GetByID(long MenuItemID)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@MenuItemID", SqlDbType.BigInt) { Value = MenuItemID },

            };

            var result = await _context.Set<HeaderMenuModel>().FromSqlRaw(
                 "EXEC [dbo].[Widgets_HeaderMenu_GetByID]  @MenuItemID ", parameters.ToArray()).ToListAsync();

            return result;
        }

        public async Task<List<WidgetsHeaderModel>> GetByLang(long MenuItemID, byte LangID)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@MenuItemID", SqlDbType.BigInt) { Value = MenuItemID },
                new SqlParameter("@LangID", SqlDbType.BigInt) { Value = LangID },

            };

            var result = await _context.Set<WidgetsHeaderModel>().FromSqlRaw(
                 "EXEC [dbo].[Widgets_HeaderMenu_GetByLang]  @MenuItemID , @LangID ", parameters.ToArray()).ToListAsync();

            return result;
        }
    }
}
