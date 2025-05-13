using EgyptMart.Services.CMSAPI.Data;
using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.IRepository;
using EgyptMart.Services.CMSAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.CMSAPI.Repository
{
    public class WidgetContactUsRepository(DBMasterContext context) : IWidgetContactUsRepository
    {
        public Task<int> Create(CreateWidgetContactUsDTO dto)
        {


            return context.Database.ExecuteSqlRawAsync(
                    "EXEC Widget_Create_ContactUs @EmailAddress, @PhoneNumber,  @Address, @Website, @Longitude , @Latitude ",
                    [.. GetContactUsParams(dto)]
                );
        }

        public Task<List<GetWidgetContactUsModel>> GetList(byte LangID = 1)
        {
            SqlParameter langIdParam = new("@LangID", System.Data.SqlDbType.TinyInt) { Value = LangID };
            return context.Set<GetWidgetContactUsModel>().FromSqlRaw("EXEC Widget_Get_ContactUs @LangID", langIdParam).ToListAsync();
        }

        public Task<int> Translate(TranslateContactUsDTO dto)
        {
            List<SqlParameter> sqlParameters = [
                    new SqlParameter("@BaseID", dto.BaseID),
                    new SqlParameter("@Address", dto.Address),
                    new SqlParameter("@LangID", dto.LangID),
               ];

            return context.Database.ExecuteSqlRawAsync(
                    "EXEC Widget_Translate_ContactUS @BaseID,  @Address, @LangID",
                    [.. sqlParameters]
                );
        }

        public Task<int> Update(byte ContactUsID, CreateWidgetContactUsDTO dto)
        {
            List<SqlParameter> sqlParameters = [
                new ("@ContactUsID" , System.Data.SqlDbType.TinyInt  ) {Value = ContactUsID},
                .. GetContactUsParams(dto)
                ];
            return context.Database.ExecuteSqlRawAsync(
                 "EXEC Widget_Update_ContactUs @ContactUsID, @EmailAddress, @PhoneNumber,  @Address, @Website, @Longitude , @Latitude ",
                 [.. sqlParameters]
             );
        }


        private List<SqlParameter> GetContactUsParams(CreateWidgetContactUsDTO dto) => [
                    new SqlParameter("@EmailAddress", dto.EmailAddress ?? (object)DBNull.Value),
                    new SqlParameter("@PhoneNumber", dto.PhoneNumber ?? (object)DBNull.Value),
                    new SqlParameter("@Address", dto.Address ?? (object)DBNull.Value),
                    new SqlParameter("@Website", dto.Website ?? (object)DBNull.Value),
                    new SqlParameter("@Longitude", dto.Longitude ?? (object)DBNull.Value),
                    new SqlParameter("@Latitude", dto.Latitude ?? (object)DBNull.Value)
                ];
    }
}
