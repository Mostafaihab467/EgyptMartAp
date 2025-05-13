using System.Data;
using EgyptMart.Services.Auth.Data;
using EgyptMart.Services.Auth.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.Auth.Repository
{
    public class RecoveryRepository(DBMasterContext context) : IRecoveryRepository
    {
        public Task<int> RaisResetCode(string username, string activationCode)
        {
            List<SqlParameter> parameters = new()
            {
                new ("@ActivationCode", SqlDbType.VarChar ) { Value = activationCode },
                new ("@UserName", SqlDbType.VarChar , 100) { Value = username.Trim() }
            };
            return context.Database.ExecuteSqlRawAsync("EXEC Pre_Users_CreateResetCode @ActivationCode,  @UserName", parameters[0], parameters[1]);
        }

        public Task<int> ResetLoginFaildCounter(string username)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new ("@UserName", SqlDbType.VarChar , 100) { Value = username.Trim() }
            };
            return context.Database.ExecuteSqlRawAsync("EXEC Pre_Users_ResetLoginFailCounter @UserName", parameters[0]);
        }

        public Task<List<byte>> VerfiyActivationCode(string username, string activationCode)
        {
            List<SqlParameter> parameters = new()
            {
                new ("@ActivationCode", SqlDbType.VarChar ) { Value = activationCode },
                new ("@UserName", SqlDbType.VarChar , 100) { Value = username.Trim() }
            };

            return context.Database.SqlQueryRaw<byte>("EXEC Pre_Users_VerfiyActivationCode @ActivationCode,  @UserName", parameters[0], parameters[1]).ToListAsync();
        }

        public Task<List<byte>> CheckExistEmail(string username)
        {
            return context.Database
                    .SqlQueryRaw<byte>("EXEC Pre_Users_ChkMailExsist @UserName",
                                    new SqlParameter("@UserName", SqlDbType.VarChar, 100) { Value = username })
                    .ToListAsync();
        }

        public Task<int> ChangePassword(long userID, string newPassword)
        {
            List<SqlParameter> sqlParams = [
                new ("@UserID" , SqlDbType.BigInt ) { Value = userID },
                new ("@NewPassword" , SqlDbType.VarChar , 50) { Value = newPassword }
                ];
            return context.Database.ExecuteSqlRawAsync("EXEC Usm_ChangePassword @UserID, @NewPassword", [.. sqlParams]);
        }

        public Task<List<int>> CheckPassword(long userID, string password)
        {
            List<SqlParameter> sqlParams = [
                new ("@UserID" , SqlDbType.BigInt ) { Value = userID },
                new ("@Password" , SqlDbType.VarChar , 50) { Value = password }
             ];
            return context.Database.SqlQueryRaw<int>("EXEC Usm_CheckPassword @UserID, @Password", [.. sqlParams]).ToListAsync();
        }

        public Task<int> ForgotChangePassword(string username, string newPassword)
        {
            List<SqlParameter> sqlParams = [
                 new ("@UserName" , SqlDbType.VarChar , 100 ) { Value = username},
                new ("@NewPassword" , SqlDbType.VarChar , 50) { Value = newPassword }
              ];
            return context.Database.ExecuteSqlRawAsync("EXEC Usm_Forgot_ChangePassword @UserName, @NewPassword", [.. sqlParams]);
        }

        public Task<List<int>> ReplacePassword(long userID, string oldPassword, string newPassword)
        {
            List<SqlParameter> sqlParams = [
                new ("@UserID" , SqlDbType.BigInt ) { Value = userID },
                new ("@OldPassword" , SqlDbType.VarChar , 50) { Value = oldPassword } ,
                new ("@NewPassword" , SqlDbType.VarChar , 50) { Value = newPassword } ,
          ];
            return context.Database.SqlQueryRaw<int>("EXEC Pre_Replace_Password @UserID, @OldPassword ,@NewPassword ", [.. sqlParams]).ToListAsync();
        }
    }
}
