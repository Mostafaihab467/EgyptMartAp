using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.DTOS.WidgetSocialMedia;
using EgyptMart.Services.CMSAPI.Models.WidgetsSocialMedia;

namespace EgyptMart.Services.CMSAPI.IRepository
{
    public interface IWidgets_SocialMediaRepository
    {
        Task<int> Create(Widgets_SocialMedia_CreateDto widgets_SocialMedia);


        Task<int> EditWidgetAsync(WidgetsSocialMediaEditDto dto);

        Task<List<WidgetsSocialMediaGetModel>> GetWidgetsSocialMediaAsync(int reptype);

        Task<int> ChangeStatus(DTOS.WidgetSocialMedia.WidgetsSocialMediaChangeStatusDto widgetsSocialMediaChangeStatusDto);
    }
}
