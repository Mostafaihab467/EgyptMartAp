using System.Data;
using EgyptMart.Services.Auth.Data;
using EgyptMart.Services.Auth.DTO;
using EgyptMart.Services.Auth.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.Auth.Repository
{
    public class RegisterRepository(DBMasterContext context) : IRegisterRepository
    {
        public Task<int> RegisterCustomer(RegisterDTO dto)
        {
            List<SqlParameter> parameters = _registerParameters(dto);
            return context.Database.ExecuteSqlRawAsync(
                "EXEC Pre_Register_Customer @CompanyName, @userName, @Password, @BusinessTypeID, @LocationID",
                                             parameters[0], parameters[1], parameters[2], parameters[3], parameters[4]
                ); ;
        }

        public Task<int> RegisterSupplier(RegisterSupplierDTO dto)
        {
            SqlParameter taxRgisNumberParam = new SqlParameter("@TaxRegistrationNo", SqlDbType.NVarChar) { Value = dto.TaxRegistrationNo };
            List<SqlParameter> parameters = _registerParameters(dto);
            return context.Database.ExecuteSqlRawAsync(
                "EXEC Pre_Register_Supplier @CompanyName, @userName, @Password, @BusinessTypeID, @TaxRegistrationNo, @LocationID",
                  parameters[0], parameters[1], parameters[2], parameters[3], taxRgisNumberParam, parameters[4]
                );
        }

        private List<SqlParameter> _registerParameters(RegisterDTO dto) => [
                new SqlParameter("@CompanyName"  ,SqlDbType.NVarChar ) {Value = dto.CompanyName},
                new SqlParameter("@userName"  ,SqlDbType.NVarChar ) {Value = dto.UserName , Size  = 100},
                new SqlParameter("@Password"  ,SqlDbType.NVarChar ) {Value = dto.Password , Size  = 50},
                new SqlParameter("@BusinessTypeID"  ,SqlDbType.SmallInt ) {Value = dto.BusinessTypeID },
                new SqlParameter("@LocationID"  ,SqlDbType.BigInt ) {Value = dto.LocationID },
                ];
    }
}
