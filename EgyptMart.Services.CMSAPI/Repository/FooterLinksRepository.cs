using EgyptMart.Services.CMSAPI.Data;
using EgyptMart.Services.CMSAPI.DTOS.FooterLink;
using EgyptMart.Services.CMSAPI.IRepository;
using EgyptMart.Services.CMSAPI.Models.FooterLink;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EgyptMart.Services.CMSAPI.Repository
{
    public class FooterLinksRepository : IFooterLinksRepository
    {
        private DBMasterContext _context;

        public FooterLinksRepository(DBMasterContext context)
        {
            _context = context;
        }

        public async Task<int> ChangeFooterLinkStatus(FooterLinkStatusDto model)
        {
            var parameters = new List<SqlParameter>
    {
        new SqlParameter("@FooterItemID", SqlDbType.Int) { Value = model.FooterItemID },
        new SqlParameter("@IsActive", SqlDbType.Bit) { Value = model.IsActive }
    };

           var result = await _context.Database.ExecuteSqlRawAsync(
                "EXEC [dbo].[Widgets_FooterLinks_ChangeStatus] @FooterItemID, @IsActive",
                parameters.ToArray()
            );

            return result;
        }

        public async Task<int> Create(WidgetsFooterLinksCreateRequestDto widgetsFooterLinksCreate)
        {

            var parameters = new List<SqlParameter>{
            new SqlParameter("@FooterItemTitle", SqlDbType.NVarChar) { Value = widgetsFooterLinksCreate.FooterItemTitle },
            new SqlParameter("@TargetUrl", SqlDbType.NVarChar) { Value = widgetsFooterLinksCreate.TargetUrl },
            new SqlParameter("@DisplayOrder", SqlDbType.SmallInt) { Value = widgetsFooterLinksCreate.DisplayOrder },
            new SqlParameter("@ColumnIndex", SqlDbType.TinyInt) { Value = widgetsFooterLinksCreate.ColumnIndex },



            };


            var result = await _context.Database.ExecuteSqlRawAsync(
                  "EXEC [dbo].[Widgets_FooterLinks_Create] @FooterItemTitle ,@TargetUrl , @DisplayOrder ,@ColumnIndex",
                  parameters.ToArray()
              );

            return result;

        }

        public async Task<int> Widgets_FooterLinks_Edit(FooterLinkEditDto model)
        {
            var parameters = new List<SqlParameter>
    {
        new SqlParameter("@FooterItemID", SqlDbType.Int) { Value = model.FooterItemID },
        new SqlParameter("@FooterItemTitle", SqlDbType.NVarChar, 50) { Value = model.FooterItemTitle },
        new SqlParameter("@TargetUrl", SqlDbType.NVarChar, -1) { Value = model.TargetUrl },
        new SqlParameter("@DisplayOrder", SqlDbType.SmallInt) { Value = model.DisplayOrder },
        new SqlParameter("@ColumnIndex", SqlDbType.TinyInt) { Value = model.ColumnIndex }
    };

          var result =  await _context.Database.ExecuteSqlRawAsync(
                "EXEC [dbo].[Widgets_FooterLinks_Edit] @FooterItemID, @FooterItemTitle, @TargetUrl, @DisplayOrder, @ColumnIndex",
                parameters.ToArray()
            );

            return result;
        }



        public async Task<FooterLinkModel> GetFooterLinkByID(int footerItemID)
        {
            var parameter = new SqlParameter("@FooterItemID", SqlDbType.Int) { Value = footerItemID };

            var result = await _context.Set<FooterLinkModel>()
                .FromSqlRaw("EXEC [dbo].[Widgets_FooterLinks_GetByID] @FooterItemID", parameter)
                .ToListAsync();

            return result.FirstOrDefault();
        }


        public async Task<List<FooterLinkModel>> GetAllFooterLinks()
        {
            var result = await _context.Set<FooterLinkModel>()
                .FromSqlRaw("EXEC [dbo].[Widgets_FooterLinks_Get]")
                .ToListAsync();

            return result;
        }


        public async Task<int> TranslateFooterLink(FooterLinkTranslateDto footerLinkTranslateDto)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@BasID", SqlDbType.BigInt) { Value = footerLinkTranslateDto.BasID },
                new SqlParameter("@FooterItemTitle", SqlDbType.NVarChar, 50) { Value = footerLinkTranslateDto.FooterItemTitle },
                new SqlParameter("@LangID", SqlDbType.TinyInt) { Value = footerLinkTranslateDto.LangID }
            };

         var result =   await _context.Database.ExecuteSqlRawAsync("EXEC [dbo].[Widgets_FooterLinks_Translate] @BasID, @FooterItemTitle, @LangID", parameters.ToArray());

            return result;
        }

        public async Task<List<FooterLinkModel>> GetFront(byte LangID)
        {

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@LangID", SqlDbType.BigInt) { Value = LangID},
               
            };

            var result = await _context.Set<FooterLinkModel>()
              .FromSqlRaw("EXEC [dbo].[Widgets_FooterLinks_GetFront] @LangID",parameters.ToArray())
              .ToListAsync();

            return result;
        }

        public async Task<List<FooterLinkModel>> GetChild(int FooterItemID, byte LangID)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@FooterItemId", SqlDbType.Int) { Value = FooterItemID },
                new SqlParameter("@LangID", SqlDbType.TinyInt) { Value = LangID },

            };


            var result = await _context.Set<FooterLinkModel>().FromSqlRaw("exec  [SDA_WidgetFooterLink_GetChild] @FooterItemId , @LangID", parameters.ToArray()).ToListAsync();

            return result;
        }

        public async Task<List<FooterLinkModel>> GetTranslated(byte ColumnIndex, byte LangID)
        {

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@ColumnIndex", SqlDbType.TinyInt) { Value = ColumnIndex},
                new SqlParameter("@LangID", SqlDbType.TinyInt) { Value = LangID},

            };

            var result = await _context.Set<FooterLinkModel>()
              .FromSqlRaw("EXEC [dbo].[sp_Get_FooterLinks_By_ColumnIndex] @ColumnIndex , @LangID", parameters.ToArray())
              .ToListAsync();

            return result;
        }
    }
}
