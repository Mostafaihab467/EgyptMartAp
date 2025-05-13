

using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.Models;

namespace EgyptMart.Services.CMSAPI.IRepository
{
    public interface IWidgetSliderRepository
    {
        public Task<int> CreateWidgetSlider(CreateWidgetSliderDTO dto, string imageURL);
        public Task<int> TranslateWidgetSlider(TranslateWidgetSliderDTO dto);
        public Task<int> EditWidgetSlider(int sliderID, UpdateWidgetSliderDTO dto);
        public Task<int> EditWidgetSliderImage(int sliderID, string imageURL);
        public Task<int> ChangeWidgetSliderStatus(int sliderID, bool IsActive);
        public Task<List<WidgetSliderModel>> GetWidgetSliderById(int sliderID);
        public Task<List<WidgetSliderModel>> GetWidgetSliderByLang(int baseID, byte langID);
        public Task<List<WidgetSliderModel>> GetWidgetSliderForAdmin();
        public Task<List<WidgetSliderModel>> GetWidgetSliderForFront(byte LangID);
        Task<List<WidgetSliderModel>> GetWidgetSliderByLangForFront(int baseID, byte langID);
    }
}
