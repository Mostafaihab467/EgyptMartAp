using EgyptMart.Services.CMSAPI.Data;
using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.DTOS.WidgetSocialMedia;
using EgyptMart.Services.CMSAPI.IRepository;
using EgyptMart.Services.CMSAPI.Models.WidgetsSocialMedia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EgyptMart.Services.CMSAPI.Repository
{
    public class Widgets_SocialMedia_Repository : IWidgets_SocialMediaRepository
    {

        private DBMasterContext _context;

        public Widgets_SocialMedia_Repository(DBMasterContext context)
        {
            _context = context;
        }

        public async Task<int> ChangeStatus(WidgetsSocialMediaChangeStatusDto widgetsSocialMediaChangeStatusDto)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@LinkID", SqlDbType.SmallInt) { Value = widgetsSocialMediaChangeStatusDto.LinkID },
                new SqlParameter("@NewStatus", SqlDbType.Bit) { Value = widgetsSocialMediaChangeStatusDto.NewStatus },
            };

            var result = await _context.Database.ExecuteSqlRawAsync(
              "EXEC [dbo].[Widgets_SocialMedia_ChangeStatus] @LinkID, @NewStatus",
              parameters.ToArray()
          );
            return result;
        }

        public async Task<int> Create(Widgets_SocialMedia_CreateDto widgets_SocialMedia)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@LinkTitle", SqlDbType.NVarChar) { Value = widgets_SocialMedia.LinkTitle },
                new SqlParameter("@LinkTarget", SqlDbType.NVarChar) { Value = widgets_SocialMedia.LinkTarget },
                new SqlParameter("@DisplayOrder", SqlDbType.SmallInt) { Value = widgets_SocialMedia.DisplayOrder },
                new SqlParameter("@LinkIcon", SqlDbType.NVarChar) { Value = widgets_SocialMedia.LinkIcon }
            };

            // Execute the stored procedure
            var result = await _context.Database.ExecuteSqlRawAsync(
                "EXEC [dbo].[Widgets_SocialMedia_Create] @LinkTitle, @LinkTarget, @DisplayOrder, @LinkIcon",
                parameters.ToArray()
            );


            return result;
        }

        public async Task<int> EditWidgetAsync(WidgetsSocialMediaEditDto dto)
        {
            var parameters = new List<SqlParameter>
        {
            new SqlParameter("@LinkID", SqlDbType.SmallInt) { Value = dto.LinkID },
            new SqlParameter("@LinkTitle", SqlDbType.NVarChar, 50) { Value = dto.LinkTitle },
            new SqlParameter("@LinkTarget", SqlDbType.NVarChar, 50) { Value = dto.LinkTarget },
            new SqlParameter("@DisplayOrder", SqlDbType.SmallInt) { Value = dto.DisplayOrder },
            new SqlParameter("@LinkIcon", SqlDbType.NVarChar) { Value = dto.LinkIcon }
        };

            var result = await _context.Database.ExecuteSqlRawAsync(
                "EXEC [dbo].[Widgets_SocialMedia_Edit] @LinkID, @LinkTitle, @LinkTarget, @DisplayOrder, @LinkIcon",
                parameters.ToArray()
            );

            return result; // Returns the number of affected rows
        }

      
        public async Task<List<WidgetsSocialMediaGetModel>> GetWidgetsSocialMediaAsync(int repType)
        {
            var parameters = new List<SqlParameter>
    {
        new SqlParameter("@RepType", SqlDbType.TinyInt) { Value = repType }
    };

            var result = await _context.Set<WidgetsSocialMediaGetModel>()
                .FromSqlRaw("EXEC [dbo].[Widgets_SocialMedia_Get] @RepType", parameters.ToArray())
                .ToListAsync();

            return result.Select(r => new WidgetsSocialMediaGetModel
            {
                LinkID = r.LinkID,
                LinkTitle = r.LinkTitle,
                LinkTarget = r.LinkTarget,
                DisplayOrder = r.DisplayOrder,
                LinkIcon = r.LinkIcon,
                IsActive = r.IsActive
            }).ToList();
        }


    }
}
