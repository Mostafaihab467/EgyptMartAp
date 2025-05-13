using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.DTOS.CMS;
using EgyptMart.Services.CMSAPI.Models;

namespace EgyptMart.Services.CMSAPI.IRepository
{
    public interface IBusinessRepository
    {
        Task<int> CreateBuisnessType(BusinessTypeTranslationDto businessTypeTranslationDto);
        Task<BusinessTypeTranslationModel> GetBusinessTypeTranslationAsync(short businessTypeID, byte langID);
        Task<int> BussnissTypeCreate(buissnessTypeCreateDto model);
        Task<int> BussnissTypeChangeStatus(byte BusinessTypeID, bool isActive);
        Task<List<BusinessTypeTranslationModel>> GetBuissnessTypeByList(byte LangID);
    }
}
