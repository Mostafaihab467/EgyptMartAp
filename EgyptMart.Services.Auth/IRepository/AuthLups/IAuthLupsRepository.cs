using EgyptMart.Services.Auth.Models;

namespace EgyptMart.Services.Auth.IRepository
{
    public interface IAuthLupsRepository
    {
        public Task<List<LupBusinessTypeListModel>> GetLupBusinessTypeLists();
        public Task<List<LupCountryListModel>> GetLupCountryList();
    }
}
