using System.Data;
using EgyptMart.Services.Auth.Data;
using EgyptMart.Services.Auth.DTO;
using EgyptMart.Services.Auth.IRepository;
using EgyptMart.Services.Auth.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.Auth.Repository
{
    public class AccountsRepository(DBMasterContext context) : IAccountsRepository
    {
        /// <summary>
        /// This will use for checking user
        /// Not create api for it
        /// Used as assistant method in workflow reset password
        /// </summary>
        public Task<List<byte>> CheckExistEmail(string username)
        {
            return context.Database
                    .SqlQueryRaw<byte>("EXEC Pre_Users_ChkMailExsist @UserName",
                                    new SqlParameter("@UserName", SqlDbType.VarChar, 100) { Value = username })
                    .ToListAsync();
        }


        public Task<List<FindExistUserModel>> FindExistUser(string? username = null, long? userID = 0)
        {
            List<SqlParameter> sqlParams = [
                new SqlParameter("@UserName"  , SqlDbType.VarChar , 100) { Value = (object?)username ??DBNull.Value },
                new SqlParameter("@UserID"  , SqlDbType.BigInt) { Value = userID },
                ];
            return context.FindExistUserModel
                .FromSqlRaw("EXEC Pre_Users_FindExistUser @UserName , @UserID", [.. sqlParams])
                .ToListAsync();
        }
        public Task<List<LoginResponseModel>> CheckPassword(long userID, string password)
        {
            List<SqlParameter> parameters = [
              new SqlParameter("@UserID", SqlDbType.BigInt) { Value = userID},
              new SqlParameter("@Password", SqlDbType.VarChar) { Value = password}

          ];
            return context.LoginResponseModel.FromSqlRaw("EXEC Pre_Users_CheckPassword @UserID , @Password", [.. parameters]).ToListAsync();
        }

        public Task<int> IncreaseResetFailLoginCounter(long userID, bool reset = false)
        {
            List<SqlParameter> parameters = [
                new SqlParameter("@UserID", SqlDbType.BigInt) { Value = userID},
                new SqlParameter("@Reset", SqlDbType.Bit) { Value = reset}

            ];
            return context.Database.ExecuteSqlRawAsync("EXEC Pre_Users_IncreaseFailCounter @UserID , @Reset", [.. parameters]);
        }

        public Task<List<LoginResponseModel>> Login(LoginDTO dto)
        {
            List<SqlParameter> parameters = [
                new SqlParameter("@UserName" , SqlDbType.VarChar , 100) {Value = dto.UserName},
                new SqlParameter("@Password" , SqlDbType.VarChar , 100) {Value = dto.Password},
                new SqlParameter("@PortalType" , SqlDbType.TinyInt ) {Value = dto.PortalType},
                ];

            return context.LoginResponseModel.FromSqlRaw("EXEC Usr_Login_ByType @UserName, @Password , @PortalType", [.. parameters]).ToListAsync();
        }



    }
}
