using EgyptMart.Services.ProductsAPI.DTO;
using EgyptMart.Services.ProductsAPI.Models;

namespace EgyptMart.Services.ProductsAPI.IRepository
{
    public interface ICategoryListRepository
    {
        Task<int> Create(string CategoryTitle, int? ParentID, int? LangID, int? DisplayOrder, string CategoryImageURL);
        Task<int> Edit(int CategoryID, string CategoryTitle, short DisplayOrder);
        Task<int> Delete(int CategoryID);
        Task<List<CategoryListModelView>> GetChildCategory(int ParentID, byte RepType, byte LangID = 1);
        Task<List<CategoryListModelView>> GetParentByChild(int ChildID);
        Task<List<CategoryListModelView>> GetChildList(byte LangID);
        Task<List<CategoryListModelView>> GetTopLevel(byte LagID, byte RepType);
        Task<int> ChangeStatus(long CategoryID, bool IsActive);
        Task<List<CategoryListTranslateModel>> Translate(TranslateCategoryDTO dto);
        Task<List<CategoryListTranslateModel>> GetByLang(int BaseID, short langID);
    }
}
