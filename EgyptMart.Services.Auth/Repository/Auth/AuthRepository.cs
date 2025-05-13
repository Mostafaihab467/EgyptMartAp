using System.Data;
using EgyptMart.Services.Auth.Data;
using EgyptMart.Services.Auth.IRepository;
using EgyptMart.Services.Auth.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.Auth.Repository
{
    public class AuthRepository(DBMasterContext context) : IAuthRepository
    {
        public Task<List<string>> GetIpAddress(long userID)
        {
            List<SqlParameter> sqlParams = [
                new ("@UserID" , SqlDbType.BigInt ) {Value = userID},
                ];
            return context.Database.SqlQueryRaw<string>("EXEC Pre_Get_CurrentIpAddress @UserID", [.. sqlParams]).ToListAsync();
        }

        public Task<List<RefreshTokenModel>> GetRefreshToken(long userId, string refreshToken)
        {


            return context.Set<RefreshTokenModel>()
                .FromSqlRaw(
                "EXEC Pre_Users_GetRefreshToken @UserID, @RefreshToken",
                [.. _GetSqlParamsRefreshToken(userId, refreshToken)])
                .ToListAsync();


        }

        public Task<int> SaveIpAddress(long userID, string ipAddress)
        {

            List<SqlParameter> sqlParams = [
                new ("@UserID" , SqlDbType.BigInt ) {Value = userID},
                new ("@LoginIpAdderess" , SqlDbType.VarChar , 45 ) {Value = ipAddress},
                ];
            return context.Database.
                ExecuteSqlRawAsync("EXEC Pre_Save_CurrentIpAddress @UserID , @LoginIpAdderess", [.. sqlParams]);


        }

        public Task<int> StoreRefreshToken(long userId, string refreshToken)
        {

            return context.Database.ExecuteSqlRawAsync(
                "EXEC Pre_Users_StoreRefreshToken @UserID, @RefreshToken",
                [.. _GetSqlParamsRefreshToken(userId, refreshToken)]);

        }


        private List<SqlParameter> _GetSqlParamsRefreshToken(long userID, string refreshToken) =>
                [
                    new ("@UserID", SqlDbType.BigInt) { Value = userID },
                    new ("@RefreshToken", SqlDbType.NVarChar, 500) { Value = refreshToken }
                ];
    }
}
