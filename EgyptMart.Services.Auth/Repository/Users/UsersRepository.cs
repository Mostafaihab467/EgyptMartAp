using System.Data;
using EgyptMart.Services.Auth.Data;
using EgyptMart.Services.Auth.DTO;
using EgyptMart.Services.Auth.IRepository;
using EgyptMart.Services.Auth.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.Auth.Repository
{
    public class UsersRepository(DBMasterContext context) : IUsersRepository
    {
        public Task<List<UserModel>> GetListByType(byte TypeID, int PageNumber = 1, int SizePerPage = 50)
        {
            List<SqlParameter> sqlParameters = [
                new ("@TypeID" , System.Data.SqlDbType.TinyInt ) {Value = TypeID},
                new ("@PageNumber" , System.Data.SqlDbType.Int ) {Value = PageNumber},
                new ("@SizePerPage" , System.Data.SqlDbType.Int ) {Value = SizePerPage},
                ];
            return context.Set<UserModel>().FromSqlRaw("EXEC Usm_Get_Users_ByTypeID @TypeID, @PageNumber  , @SizePerPage", [.. sqlParameters]).ToListAsync();
        }

        public Task<int> BlockOrUnBlock(long UserID, bool Active = false)
        {
            List<SqlParameter> sqlParameters = [
                new ("@UserID" , System.Data.SqlDbType.BigInt ) {Value = UserID},
                new ("@Active" , System.Data.SqlDbType.Bit ) {Value = Active}
                ];
            return context.Database.ExecuteSqlRawAsync("EXEC Usm_BlockUser @UserID, @Active", [.. sqlParameters]);
        }

        public Task<List<decimal>> CreateUser(CreateUserDTO dto)
        {
            List<SqlParameter> sqlParameters =
            [
                new ("@DisplayName", System.Data.SqlDbType.NVarChar) { Value = dto.DisplayName.Trim() },
                new ("@UserName", System.Data.SqlDbType.VarChar, 100) { Value = dto.UserName.Trim()},
                new ("@Password", System.Data.SqlDbType.VarChar, 50) { Value = dto.Password },
                new ("@UserTypeID", System.Data.SqlDbType.TinyInt) { Value = dto.UserTypeID },
                new ("@FirstLogin", System.Data.SqlDbType.Bit) { Value = dto.FirstLogin}
            ];

            return context.Database.SqlQueryRaw<decimal>(
                    "EXEC Usm_CreateUser @DisplayName ,  @UserName  ,  @Password ,  @UserTypeID ,   @FirstLogin ",
                    [.. sqlParameters]
            ).ToListAsync();
        }

        public Task<List<UserModel>> GetUserById(long UserID)
        {
            List<SqlParameter> sqlParameters = [
             new ("@UserID" , System.Data.SqlDbType.BigInt ) {Value = UserID}

                ];
            return context.Set<UserModel>().FromSqlRaw("EXEC Usm_Get_UserDetails @UserID", [.. sqlParameters]).ToListAsync();
        }



        public Task<int> StoreCode(string UserName, string Code)
        {
            List<SqlParameter> parameters = new()
            {
                new ("@ActivationCode", SqlDbType.VarChar ) { Value = Code.Trim() },
                new ("@UserName", SqlDbType.VarChar , 100) { Value = UserName.Trim() }
            };
            return context.Database.ExecuteSqlRawAsync("EXEC Pre_Users_CreateResetCode @ActivationCode,  @UserName", parameters[0], parameters[1]);
        }

        public Task<List<UserTypeModel>> GetSomeTypes()
        {
            return context.Set<UserTypeModel>().FromSqlRaw("EXEC Usm_Get_UserTypes").ToListAsync();
        }

        public Task<List<UserTypesCountModel>> GetWithCount()
        {
            return context.Set<UserTypesCountModel>().FromSqlRaw("EXEC Usm_Get_UserTypesWithCount").ToListAsync();
        }

        public Task<int> SetFirstLogin(long UserID, bool FirstLogin = true)
        {
            List<SqlParameter> sqlParameters = [
                new ("@UserID" , System.Data.SqlDbType.BigInt ) {Value = UserID},
                new ("@FirstLogin" , System.Data.SqlDbType.Bit ) {Value = FirstLogin}
                ];
            return context.Database.ExecuteSqlRawAsync("EXEC Usm_SetFirstLogin @UserID, @FirstLogin", [.. sqlParameters]);
        }
    }
}
