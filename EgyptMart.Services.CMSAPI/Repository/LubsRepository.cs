using EgyptMart.Services.CMSAPI.Data;
using EgyptMart.Services.CMSAPI.DTOS.FooterLink;
using EgyptMart.Services.CMSAPI.IRepository;
using EgyptMart.Services.CMSAPI.Models.Lup_Lang;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EgyptMart.Services.CMSAPI.Repository
{
    public class LubsRepository : ILubsRepository
    {
        private DBMasterContext _context;


        public LubsRepository(DBMasterContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Lup_LangModel>> GetLubsAsync()
        {


            var result = await _context.Set<Lup_LangModel>().FromSqlRaw(
                "EXEC [dbo].[Lup_LangList_Get] "

            ).ToListAsync();
            return result;
        }



        public async Task<IEnumerable<Lup_LangModel>> TranslateTo(byte LangID)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@LangID", SqlDbType.BigInt) { Value = LangID },

            };

            var result = await _context.Set<Lup_LangModel>().FromSqlRaw(
                "EXEC [dbo].[Lup_LangList_TranslateTo] @LangID", parameters.ToArray()

            ).ToListAsync();
            return result;
        }
    }
}