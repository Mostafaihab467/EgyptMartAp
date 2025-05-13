using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.DTOS.CMS;
using EgyptMart.Services.CMSAPI.Models;
namespace EgyptMart.Services.CMSAPI.IRepository
{
    public interface ICMSListRepository
    {
        Task<int> Create(SupplierDto supplierDto);
        Task<CompanyProfileModelView> SuppliersByID(int userId);
        Task<int> SuppliersEdit(SuppliersEditDto planEditDto);
        Task<int> SuppliersEditImage(SupplierImgDto SupplierImgDto, string ProfileImage);

        Task<List<CompantTranslatedGetModel>> GetByLang(long UserID, byte LangID);
        Task<int> CreateTranslation(PreUsersExtSuppliersExtTranslationDto preUsersExtSuppliersExtTranslationDto);


        public Task<int> uploadPdf(string base64String, int OwnerId);
        public Task<FileDataResponse> downloadFile(int fileName);
    }
}
