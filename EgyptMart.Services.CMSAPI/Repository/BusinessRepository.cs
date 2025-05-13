using System.Data;
using EgyptMart.Services.CMSAPI.Data;
using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.DTOS.CMS;
using EgyptMart.Services.CMSAPI.IRepository;
using EgyptMart.Services.CMSAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.CMSAPI.Repository
{
    public class BusinessRepository(DBMasterContext context) : IBusinessRepository
    {

        public async Task<BusinessTypeTranslationModel> GetBusinessTypeTranslationAsync(short businessTypeID, byte langID)
        {
            var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@BusinessTypeID", SqlDbType.SmallInt) { Value = businessTypeID },
                    new SqlParameter("@LangID", SqlDbType.TinyInt) { Value = langID }
                };

            var result = await context.Set<BusinessTypeTranslationModel>()
                .FromSqlRaw("EXEC sp_Get_BusinessTypeListTranslation @BusinessTypeID, @LangID", parameters.ToArray())
                .AsNoTracking()
                .ToListAsync();

            return result.FirstOrDefault();
        }


        public async Task<int> CreateBuisnessType(BusinessTypeTranslationDto businessTypeTranslationDto)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@BusinessTypeID", SqlDbType.SmallInt) { Value = businessTypeTranslationDto.BusinessTypeID },
                new SqlParameter("@BusinessTypeTitle", SqlDbType.NVarChar) { Value = (object)businessTypeTranslationDto.BusinessTypeTitle ?? DBNull.Value },
                new SqlParameter("@IsActive", SqlDbType.Bit) { Value = businessTypeTranslationDto.IsActive },
                new SqlParameter("@LangID", SqlDbType.TinyInt) { Value = businessTypeTranslationDto.LangID },
                new SqlParameter("@BaseTypeID", SqlDbType.SmallInt) { Value = (object)businessTypeTranslationDto.BaseTypeID ?? DBNull.Value }
            };

            var result = await context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertOrUpdate_BusinessTypeListTranslation @BusinessTypeID, @BusinessTypeTitle, @IsActive, @LangID, @BaseTypeID",
                parameters.ToArray()
            );

            return result;
        }



        public async Task<List<BusinessTypeTranslationModel>> GetBuissnessTypeByList(byte LangID)
        {
            var parameters = new List<SqlParameter>
            {
            new SqlParameter("@LangID", LangID)
            };
            // Execute the stored procedure and retrieve data
            var result = await context.Set<BusinessTypeTranslationModel>()
                .FromSqlRaw("EXEC [dbo].[sp_Get_BusinessTypeListTranslation_GETLIST]  @LangID", parameters.ToArray())
                .ToListAsync();

            // Return the first result if it exists
            return result;
        }


        public async Task<int> BussnissTypeChangeStatus(byte BusinessTypeID, bool isActive)
        {
            var parameters = new List<SqlParameter>
            {
            new SqlParameter("@BusinessTypeID", BusinessTypeID),
            new SqlParameter("@IsActive", isActive)
            };
            var result = await context.Database.ExecuteSqlRawAsync("exec sp_BusinessTypeChangetatus @BusinessTypeID , @IsActive",
                parameters.ToArray());
            return result;

        }

        public async Task<int> BussnissTypeCreate(buissnessTypeCreateDto model)
        {
            var parameters = new List<SqlParameter>
    {
        new SqlParameter("@BusinessTypeID", model.BusinessTypeID),
        new SqlParameter("@BusinessTypeTitle", model.BusinessTypeTitle),
        new SqlParameter("@IsActive", SqlDbType.Bit) { Value = 1 }, // Ensure it's a BIT type
        new SqlParameter("@LangID", SqlDbType.TinyInt) { Value = 1 }, // Ensure it's a TinyInt
        new SqlParameter("@BaseTypeID", SqlDbType.SmallInt) { Value = 0 } // Fix: Define as SmallInt
    };
            var result = await context.Database.ExecuteSqlRawAsync("exec BusinessType_Create @BusinessTypeID, @BusinessTypeTitle , @IsActive , @LangID, @BaseTypeID",
                parameters.ToArray());
            return result;

        }



    }
}
