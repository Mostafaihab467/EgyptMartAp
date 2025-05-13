using EgyptMart.Services.Auth.Data;
using EgyptMart.Services.Auth.IRepository;
using EgyptMart.Services.Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.Auth.Repository
{
    public class AuthLupsRepository(DBMasterContext context) : IAuthLupsRepository
    {
        public Task<List<LupBusinessTypeListModel>> GetLupBusinessTypeLists()
        {
            return context.LupBusinessTypeListModel.FromSqlRaw("Lup_BusinessType_Get").ToListAsync();
        }

        public Task<List<LupCountryListModel>> GetLupCountryList()
        {
            return context.LupCountryListModel.FromSqlRaw("Lup_CountryList_Get").ToListAsync();
        }
    }
}
