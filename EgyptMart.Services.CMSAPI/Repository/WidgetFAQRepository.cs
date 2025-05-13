using System;
using System.Data;
using EgyptMart.Services.CMSAPI.Data;
using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.IRepository;
using EgyptMart.Services.CMSAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.CMSAPI.Repository
{
    public class WidgetFAQRepository(DBMasterContext context) : IWidgetFAQRepositroy
    {
        public Task<int> ChangeWidgetFAQStatus(int QID, bool IsActive)
        {
            List<SqlParameter> parameters = [
                 new SqlParameter("@QID", SqlDbType.Int) { Value = QID },
                new SqlParameter("@IsActive", SqlDbType.Bit) { Value = IsActive },
            ];
            return context.Database.ExecuteSqlRawAsync("EXEC Widgets_FAQ_ChangeStatus @QID, @IsActive ", parameters);
        }

        public Task<int> CreateWidgetFAQ(CreateWidgetFAQDTO dto)
        {
            List<SqlParameter> parameters = [
                 new SqlParameter("@QTitle", SqlDbType.NVarChar) { Value = dto.QTitle },
                new SqlParameter("@QAnswer", SqlDbType.NVarChar) { Value = dto.QAnswer },
                new SqlParameter("@DisplayOrder", SqlDbType.SmallInt) { Value = dto.DisplayOrder }
                ];
            return context.Database.ExecuteSqlRawAsync("EXEC Widgets_FAQ_Create @QTitle, @QAnswer, @DisplayOrder ", parameters);
        }

        public Task<int> EditWidgetFAQ(int QID, CreateWidgetFAQDTO dto)
        {
            List<SqlParameter> parameters = [
                 new SqlParameter("@QID", SqlDbType.Int) { Value = QID },
                new SqlParameter("@QTitle", SqlDbType.NVarChar) { Value = dto.QTitle },
                new SqlParameter("@QAnswer", SqlDbType.NVarChar) { Value = dto.QAnswer },
                new SqlParameter("@DisplayOrder", SqlDbType.SmallInt) { Value = dto.DisplayOrder }
              ];
            return context.Database.ExecuteSqlRawAsync("EXEC Widgets_FAQ_Edit @QID,  @QTitle, @QAnswer, @DisplayOrder ", parameters);
        }

        public Task<List<WidgetFAQModel>> GetWidgetFAQById(int QID)
        {
            List<SqlParameter> parameters = [
               new SqlParameter("@QID", SqlDbType.Int) { Value = QID },
            ];
            return context.WidgetFAQModel.FromSqlRaw("EXEC Widgets_FAQ_GeByID @QID", parameters[0]).ToListAsync();
        }

        public Task<List<WidgetFAQModel>> GetWidgetFAQForAdmin()
        {
            return context.WidgetFAQModel.FromSqlRaw("EXEC Widgets_FAQ_GetAdmin").ToListAsync();
        }

        public Task<List<WidgetFAQModel>> GetWidgetFAQForFront(byte LangID)
        {
            List<SqlParameter> parameters = [
            new SqlParameter("@LangID", SqlDbType.TinyInt) { Value = LangID },
            ];
            return context.WidgetFAQModel.FromSqlRaw("EXEC Widgets_FAQ_GetFront @LangID", parameters[0]).ToListAsync();
        }
        public Task<List<WidgetFAQModel>> GetWidgetFAQByLang(int baseID, byte langID)
        {
            var parameters = new List<SqlParameter>
            {
                new ("@BaseID", SqlDbType.Int) { Value = baseID },
                new ("@Langid", SqlDbType.TinyInt) { Value = langID },

            };

            return context.WidgetFAQModel.FromSqlRaw("EXEC Widgets_FAQ_GetByLang @BaseID, @Langid", parameters[0], parameters[1]).ToListAsync();
        }

        public Task<int> TranslateWidgetFAQ(TranslateWidgetFAQDTO dto)
        {
            var parameters = new List<SqlParameter>
            {
                new ("@BaseID", SqlDbType.Int) { Value = dto.BaseID },
                new ("@Langid", SqlDbType.TinyInt) { Value = dto.LangID },
                new ("@QTitle", SqlDbType.NVarChar ) { Value = dto.QTitle },
                new ("@QAnswer", SqlDbType.NVarChar) { Value = dto.QAnswer }
            };

            return context.Database.ExecuteSqlRawAsync("EXEC Widgets_FAQ_Translate @BaseID, @Langid, @QTitle, @QAnswer ", parameters);
        }

        public Task<List<WidgetFAQModel>> GetWidgetFAQByLangActived(int baseID, byte langID)
        {
            var parameters = new List<SqlParameter>
            {
                new ("@BaseID", SqlDbType.Int) { Value = baseID },
                new ("@Langid", SqlDbType.TinyInt) { Value = langID },
        };

            return context.WidgetFAQModel.FromSqlRaw("EXEC Widgets_FAQ_GetByLang_Actived @BaseID, @Langid", parameters[0], parameters[1]).ToListAsync();
        }
    }
}
