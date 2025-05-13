using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.Models;

namespace EgyptMart.Services.CMSAPI.IRepository
{
    public interface IWidgetFAQRepositroy
    {
        public Task<int> CreateWidgetFAQ(CreateWidgetFAQDTO dto);
        public Task<int> TranslateWidgetFAQ(TranslateWidgetFAQDTO dto);
        public Task<int> EditWidgetFAQ(int QID, CreateWidgetFAQDTO dto);
        public Task<int> ChangeWidgetFAQStatus(int QID, bool IsActive);
        public Task<List<WidgetFAQModel>> GetWidgetFAQById(int QID);
        public Task<List<WidgetFAQModel>> GetWidgetFAQByLang(int baseID, byte langID);
        public Task<List<WidgetFAQModel>> GetWidgetFAQForAdmin();
        public Task<List<WidgetFAQModel>> GetWidgetFAQForFront(byte LangID);
        Task<List<WidgetFAQModel>> GetWidgetFAQByLangActived(int baseID, byte langID);
    }
}
