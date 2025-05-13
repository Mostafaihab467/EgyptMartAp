using EgyptMart.Services.CMSAPI.DTOS.FooterLink;
using EgyptMart.Services.CMSAPI.Models.FooterLink;

namespace EgyptMart.Services.CMSAPI.IRepository
{
    public interface IFooterLinksRepository
    {
        Task<int> Create(WidgetsFooterLinksCreateRequestDto widgetsFooterLinksCreateRequestDto);
        public Task<int> Widgets_FooterLinks_Edit(FooterLinkEditDto model);
        public Task<int> ChangeFooterLinkStatus(FooterLinkStatusDto model);
        public  Task<FooterLinkModel> GetFooterLinkByID(int footerItemID);
        public  Task<List<FooterLinkModel>> GetAllFooterLinks();
        public  Task<List<FooterLinkModel>> GetFront(byte LangID);
        public Task<int> TranslateFooterLink(FooterLinkTranslateDto footerLinkTranslateDto);

        Task<List<FooterLinkModel>> GetTranslated(byte ColumnIndex, byte LangID);
        Task<List<FooterLinkModel>> GetChild(int FooterItemID, byte LangID);

    }
}