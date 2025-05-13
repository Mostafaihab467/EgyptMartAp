using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.Models;

namespace EgyptMart.Services.CMSAPI.IRepository
{
    public interface IWidgetContactUsRepository
    {
        public Task<int> Create(CreateWidgetContactUsDTO dto);
        public Task<int> Update(byte ContactUsID, CreateWidgetContactUsDTO dto);
        public Task<int> Translate(TranslateContactUsDTO dto);
        public Task<List<GetWidgetContactUsModel>> GetList(byte LangID = 1);
    }
}
