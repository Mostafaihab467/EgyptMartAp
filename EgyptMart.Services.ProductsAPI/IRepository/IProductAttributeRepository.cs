using EgyptMart.Services.ProductsAPI.DTO;
using EgyptMart.Services.ProductsAPI.Models;

namespace EgyptMart.Services.ProductsAPI.IRepository
{
    public interface IProductAttributeRepository
    {
        Task<int> PullInitial(Int64 ProductID);
        Task<int> CreateAttributes(long ProductID, int AttributeID, string Value, byte LangID, short DisplayOrder);
        Task<int> EditAtributes(long LinkID, string Value, short DisplayOrder);
        Task<int> DeleteAttributes(long LinkID);
        Task<List<ProductAttibutesListModelView>> GetAttributes(long ProductID);
        Task<int> TranslateAttributeValue(TranslateProductAttributeValueDTO dto);
        public Task<List<ProductAttributesTranslatedModel>> GetAttributesByLang(long ProductID, byte LangID);
    }
}
