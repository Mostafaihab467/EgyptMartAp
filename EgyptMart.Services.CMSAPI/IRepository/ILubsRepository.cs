using EgyptMart.Services.CMSAPI.Models.Lup_Lang;

namespace EgyptMart.Services.CMSAPI.IRepository
{
    public interface ILubsRepository
    {
        public Task<IEnumerable<Lup_LangModel>> GetLubsAsync();


        public  Task<IEnumerable<Lup_LangModel>> TranslateTo(byte LangID);

    }
}
