using System.Data;
using EgyptMart.Services.Auth.Data;
using EgyptMart.Services.Auth.IRepository;
using EgyptMart.Services.Auth.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.Auth.Repository
{
    public class VerifyRepository : IVerifyRepository
    {
        private readonly DBMasterContext context;

        public VerifyRepository(DBMasterContext context, IConfiguration configuration)
        {
            this.context = context;


        }
        public Task<List<PendingVerifyCustomerModel>> PendingVerifyCustomer()
        {
            return context.PendingVerifyCustomerModel.FromSqlRaw("Pre_Register_PendingVerfiyCustomer").ToListAsync();
        }

        public Task<List<PendingVerifySupplierModel>> PendingVerifySupplier()
        {
            return context.PendingVerifySupplierModel.FromSqlRaw("Pre_Register_PendingVerfiySupplier").ToListAsync();
        }

        public Task<int> VerifyCustomerRegister(long userID, long verifiedBy)
        {

            return context.Database.ExecuteSqlRawAsync("EXEC Pre_Register_VerfiyCustomer @UserID, @VerfiedBy", _verifyParams(userID, verifiedBy));
        }

        public Task<int> VerifySupplierRegister(long userID, long verifiedBy, byte status)
        {
            List<SqlParameter> listparams = [.. _verifyParams(userID, verifiedBy), new("@Status", SqlDbType.TinyInt) { Value = status }];
            return context.Database.ExecuteSqlRawAsync("EXEC Pre_Register_VerfiySupplier_V2 @UserID, @VerfiedBy, @Status", [.. listparams]);
        }

        private List<SqlParameter> _verifyParams(long userID, long verifiedBy) => [
              new SqlParameter("@UserID" , SqlDbType.BigInt) { Value = userID },
              new SqlParameter("@VerfiedBy" , SqlDbType.BigInt) { Value = verifiedBy },
        ];



    }
}
