using EgyptMart.Services.CMSAPI.DTOS.Widgets_FixedPages;
using EgyptMart.Services.CMSAPI.Models.Widgets_FixedPages;

namespace EgyptMart.Services.CMSAPI.IRepository
{
    public interface IWidgets_FixedPagesRepository
    {

        public Task<int> Create(FixedPages_CreateDto model);

        public Task<int> Edit(FixedPages_EditDto model);
        public Task<int> ChangeStatus(FixedPages_ChangeStatusDto model);

        public Task<WidgetsFixedPageModel> GetByID(int PageID);


        public Task<List<WidgetsFixedPageModel>> GetList(byte LangID = 1);



        public Task<int> Translate(WidgetsFixedPagesTranslateDto model);
        public Task<List<WidgetsFixedPageModel>> GetByLang(int BaseID, byte LangeID);


    }

}
