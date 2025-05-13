using EgyptMart.Services.CMSAPI.DTOS.WidgetsHeaderMenu;
using EgyptMart.Services.CMSAPI.Models;
using EgyptMart.Services.CMSAPI.Models.WidgetHeaderMenue;

namespace EgyptMart.Services.CMSAPI.IRepository
{
    public interface IWidgets_HeaderMenu_Repository
    {
        Task<int> CreateHeaderMenuAsync(WidgetsHeaderMenuCreateDto headerMenuDto);
        Task<int> EditHeaderMenuAsync(WidgetsHeaderMenuEditDto headerMenuDto);
        Task<List<WidgetsHeaderMenuGetTopLevelModel>> GetTopLevelHeaderMenusAsync(int repType, int langID);
        Task<List<WidgetsHeaderMenuModel>> GetChildWidgetsHeaderMenuAsync(WidgetsHeaderMenuGetChildDtos request);
        Task<int> ChangeStatus(WidgetsHeaderMenueChangeStatusDto widgetsHeaderMenueChangeStatusDto);
        public Task<int> TranslateHeaderMenuItem(int BasID, string MenuItemTitle, short LangID);
        public Task<List<HeaderMenuModel>> HeaderMenu_GetByID(long MenuItemID);
        public Task<List<WidgetsHeaderModel>> GetByLang(long MenuItemID, byte LangID);
    }
}
