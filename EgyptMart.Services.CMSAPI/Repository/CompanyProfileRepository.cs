using EgyptMart.Services.CMSAPI.Data;
using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.IRepository;
using EgyptMart.Services.CMSAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.CMSAPI.Repository
{
    public class CompanyProfileRepository : ICompanyProfileRepository
    {
        private DBMasterContext _context;

        public CompanyProfileRepository(DBMasterContext context)
        {
            _context = context;
        }
        public Task<int> Create(CompanyProfileDto CompanyProfiledto)
        {
            var userIdParam = new SqlParameter("@UserID", CompanyProfiledto.UserID);
            var companyTitleParam = new SqlParameter("@CompanyTitle", CompanyProfiledto.CompanyTitle);
            var businessTypeIdParam = new SqlParameter("@BusinessTypeID", CompanyProfiledto.BusinessTypeID);
            var businessRangeParam = new SqlParameter("@BusinessRange", CompanyProfiledto.BusinessRange);
            var businessProductsParam = new SqlParameter("@BusinessProducts", CompanyProfiledto.BusinessProducts);
            var registeredCapitalParam = new SqlParameter("@RegisterdCapital", CompanyProfiledto.RegisteredCapital);
            var numberOfEmployeeParam = new SqlParameter("@NumberOfEmployee", CompanyProfiledto.NumberOfEmployee);
            var taxRegistrationNoParam = new SqlParameter("@TaxRegistrationNo", CompanyProfiledto.TaxRegistrationNo);
            var companyBioParam = new SqlParameter("@CompanyBIO", CompanyProfiledto.CompanyBIO);
            var tradeCapacityParam = new SqlParameter("@TradeCapacity", CompanyProfiledto.TradeCapacity);

            var result = _context.Database.ExecuteSqlRawAsync(
                "EXEC [dbo].[Pre_UsersExt_SuppliersExt_Create] @UserID, @CompanyTitle, @BusinessTypeID, @BusinessRange, @BusinessProducts, @RegisterdCapital, @NumberOfEmployee, @TaxRegistrationNo, @CompanyBIO, @TradeCapacity",
                userIdParam, companyTitleParam, businessTypeIdParam, businessRangeParam, businessProductsParam,
                registeredCapitalParam, numberOfEmployeeParam, taxRegistrationNoParam, companyBioParam, tradeCapacityParam
            );
            return result;

        }

        public Task<List<CompanyProfileModelView>> GetCompanyProfileByID(int userId)
        {
            SqlParameter UserIDParam = new("@UserID", System.Data.SqlDbType.BigInt) { Value = userId };
            return _context.CompanyProfileModelView.FromSqlRaw("EXEC Pre_UsersExt_SuppliersExt_GetByID @UserID", UserIDParam).ToListAsync();
        }



    }
}
