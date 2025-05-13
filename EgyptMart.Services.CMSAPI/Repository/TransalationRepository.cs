using EgyptMart.Services.CMSAPI.Data;
using EgyptMart.Services.CMSAPI.DTOS.LangTranslate;
using EgyptMart.Services.CMSAPI.IRepository;
using EgyptMart.Services.CMSAPI.Models.LangTranslate;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EgyptMart.Services.CMSAPI.Repository
{
    public class TransalationRepository : ITransalationRepository
    {
        private DBMasterContext _context;

        public TransalationRepository(DBMasterContext context)
        {
            _context = context;
        }

        public async Task<List<langTranslateModel>> LangList_Get()
        {
            var result = await _context.Set<langTranslateModel>().FromSqlRaw(
                "EXEC [dbo].[Lup_LangList_Get]"
            ).ToListAsync();

            return result;
        }

        public async Task<List<langTranslateModel>> LangList_TranslateTo(LangList_TranslateToDto model)
        {
            var parameters = new List<SqlParameter>{
            new SqlParameter("@LangID", SqlDbType.TinyInt) { Value = model.LangID }
            };


            var result = await _context.Set<langTranslateModel>().FromSqlRaw(
                  "EXEC [dbo].[Lup_LangList_TranslateTo] @LangID",
                  parameters.ToArray()
              ).ToListAsync();


            return result;
        }
    }
}
