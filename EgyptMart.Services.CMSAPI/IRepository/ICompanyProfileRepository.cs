using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.Models;

namespace EgyptMart.Services.CMSAPI.IRepository
{
    public interface ICompanyProfileRepository
    {
        Task<int> Create(CompanyProfileDto supplierDto);
        Task<List<CompanyProfileModelView>> GetCompanyProfileByID(int UserID);
    }
}
