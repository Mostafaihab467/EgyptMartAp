using EgyptMart.Services.CMSAPI.Data;
using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.IRepository;
using EgyptMart.Services.CMSAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.CMSAPI.Repository
{
    public class ContactCustomerRepository(DBMasterContext context) : IContactCustomerRepository
    {
        public Task<int> AddMessage(AddContactCustomerMessageDTO dto)
        {
            List<SqlParameter> sqlParameters = [
                new SqlParameter("@ContactID", System.Data.SqlDbType.BigInt)
                {
                    Value = dto.ContactID
                },

                new SqlParameter("@CustomerID", System.Data.SqlDbType.BigInt)
                {
                    Value = dto.CustomerID
                },

                new SqlParameter("@Body", System.Data.SqlDbType.NVarChar)
                {
                    Value = dto.Body.Trim()
                }
                ];

            return context.Database.ExecuteSqlRawAsync("EXEC Cus_AddContactMessage @ContactID, @CustomerID , @Body", [.. sqlParameters]);
        }

        public Task<List<CreateContactCustomerModel>> Create(CreateContactCustomerDTO dto)
        {
            List<SqlParameter> sqlParameters = [
                        new SqlParameter("@CustomerID", System.Data.SqlDbType.BigInt)
                        {
                            Value = dto.CustomerID
                        },

                        new SqlParameter("@SupplierID", System.Data.SqlDbType.BigInt)
                        {
                            Value = dto.SupplierID
                        },

                        new SqlParameter("@Title", System.Data.SqlDbType.NVarChar, 255)
                        {
                            Value = dto.Title.Trim()
                        },

                        new SqlParameter("@Body", System.Data.SqlDbType.NVarChar)
                        {
                            Value = dto.Body.Trim()
                        }
                ];

            return context.Set<CreateContactCustomerModel>().FromSqlRaw(
                "EXEC Cus_CreateCustomerContact @CustomerID , @SupplierID ,  @Title , @Body",
                [.. sqlParameters]
                ).ToListAsync();
        }

        public Task<List<ContactCustomerListModel>> GetList(long userID)
        {
            List<SqlParameter> sqlParameters = [
                new ("@UserID" , System.Data.SqlDbType.BigInt) { Value = userID }
                ];
            return context.Set<ContactCustomerListModel>().FromSqlRaw("EXEC Cus_GetList_ByUserID @UserID", [.. sqlParameters]).ToListAsync();
        }

        public Task<List<ContactCustomerReplysModel>> GetSingleReplys(long contactID, long userID)
        {
            List<SqlParameter> sqlParameters = [
                     new SqlParameter("@ContactID", System.Data.SqlDbType.BigInt)         {    Value = contactID  },

                     new SqlParameter("@UserID", System.Data.SqlDbType.BigInt)         {     Value = userID }


             ];
            return context.Set<ContactCustomerReplysModel>()
                .FromSqlRaw("EXEC Cus_GetSignle_ByContactID @ContactID , @UserID", [.. sqlParameters])
                .ToListAsync();
        }

        public Task<int> SupplierReply(ReplyContactCustomerDTO dto)
        {
            List<SqlParameter> sqlParameters = [
                      new SqlParameter("@ContactID", System.Data.SqlDbType.BigInt)
                        {
                            Value = dto.ContactID
                        },

                        new SqlParameter("@MessageID", System.Data.SqlDbType.BigInt)
                        {
                            Value = dto.MessageID
                        },

                new SqlParameter("@SupplierID", System.Data.SqlDbType.BigInt)
                        {
                            Value = dto.SupplierID
                        },


                        new SqlParameter("@ReplyBody", System.Data.SqlDbType.NVarChar)
                        {
                            Value = dto.ReplyBody.Trim()
                        }
              ];

            return context.Database.ExecuteSqlRawAsync(
                "EXEC Cus_SupplierReply @ContactID , @MessageID , @SupplierID ,  @ReplyBody",
                [.. sqlParameters]
                );
        }
    }
}
