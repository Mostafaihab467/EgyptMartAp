using EgyptMart.Services.ProductsAPI.DTO;
using EgyptMart.Services.ProductsAPI.DTO.AttributeList;
using EgyptMart.Services.ProductsAPI.Models;
using EgyptMart.Services.ProductsAPI.Models.Attribute;

namespace EgyptMart.Services.ProductsAPI.IRepository
{
    public interface IAttributeRepository
    {
        Task<int> CreateAttribute(string AttributeTitle, byte AttributeTypeID, bool ShowAcrossAllCategory, long RcBy);
        Task<int> EditAttribute(long AttributeID, string AttributeTitle, byte AttributeTypeID, bool ShowAcrossAllCategory);
        Task<int> SetLinkAttribute(long AttributeID, long CategoryID);
        Task<int> ChangeStatusAttribute(long AttributeID, bool IsActive);
        Task<int> BreakLinkAttribute(long LinkID);
        Task<int> TranslateAttribute(TranslateAttributeDTO dto);
        Task<List<AttributeByID>> GetProductAttributeTrabslatedById(long AttributeID, byte LangID);
        Task<List<AttributeModel>> GetList();

        Task<List<AttributeLinkMatrixModel>> GetLinkMatrix(int AttributeID);

    }
}
