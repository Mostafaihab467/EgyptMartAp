using EgyptMart.Services.CMSAPI.DTOS.LangTranslate;
using EgyptMart.Services.CMSAPI.Models.LangTranslate;

namespace EgyptMart.Services.CMSAPI.IRepository
{
    public interface ITransalationRepository
    {

        public Task<List<langTranslateModel>> LangList_TranslateTo(LangList_TranslateToDto model);
        public Task<List<langTranslateModel>> LangList_Get();
    }
}
