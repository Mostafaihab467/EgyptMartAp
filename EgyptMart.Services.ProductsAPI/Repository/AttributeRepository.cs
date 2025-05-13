using EgyptMart.Services.ProductsAPI.Data;
using EgyptMart.Services.ProductsAPI.DTO;
using EgyptMart.Services.ProductsAPI.DTO.AttributeList;
using EgyptMart.Services.ProductsAPI.IRepository;
using EgyptMart.Services.ProductsAPI.Models;
using EgyptMart.Services.ProductsAPI.Models.Attribute;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.ProductsAPI.Repository
{
    public class AttributeRepository : IAttributeRepository
    {
        private readonly DBMasterContext _context;
        public AttributeRepository(DBMasterContext context)
        {
            _context = context;
        }

        public Task<List<AttributeLinkMatrixModel>> GetLinkMatrix(int AttributeID)
        {
            List<SqlParameter> parameters =
                [
                    new("@AttributeID", System.Data.SqlDbType.Int) { Value = AttributeID },
        ];
            return _context.AttributeLinkMatrixModel.FromSqlRaw("EXEC Bsk_AttributeList_LinkMatrix @AttributeID", [.. parameters]).ToListAsync();
        }

        public Task<int> BreakLinkAttribute(long LinkID)
        {
            List<SqlParameter> parameters =
                [
                    new("@LinkID", System.Data.SqlDbType.BigInt) { Value = LinkID },
                ];
            return _context.Database.ExecuteSqlRawAsync("EXEC Bsk_AttributeList_BreakLink @LinkID", [.. parameters]);
        }

        public Task<int> ChangeStatusAttribute(long AttributeID, bool IsActive)
        {
            List<SqlParameter> parameters =
                [
                    new("@AttributeID", System.Data.SqlDbType.BigInt) { Value = AttributeID },
                    new("@IsActive", System.Data.SqlDbType.BigInt) { Value = IsActive },
                ];
            return _context.Database.ExecuteSqlRawAsync("EXEC Bsk_AttributeList_ChangeStatus @AttributeID, @IsActive", [.. parameters]);
        }

        public Task<int> CreateAttribute(string AttributeTitle, byte AttributeTypeID, bool ShowAcrossAllCategory, long RcBy)
        {
            List<SqlParameter> parameters =
                [
                    new("@AttributeTitle", System.Data.SqlDbType.NVarChar) { Value = AttributeTitle },
                    new("@AttributeTypeID", System.Data.SqlDbType.TinyInt) { Value = AttributeTypeID },
                    new("@ShowAcrossAllCategory", System.Data.SqlDbType.Bit) { Value = ShowAcrossAllCategory },
                    new("@RcBy", System.Data.SqlDbType.BigInt) { Value = RcBy },
                ];
            return _context.Database.ExecuteSqlRawAsync("EXEC Bsk_AttributeList_Create @AttributeTitle, @AttributeTypeID, @ShowAcrossAllCategory, @RcBy", [.. parameters]);
        }

        public Task<int> EditAttribute(long AttributeID, string AttributeTitle, byte AttributeTypeID, bool ShowAcrossAllCategory)
        {
            List<SqlParameter> parameters =
                [
                    new("@AttributeID", System.Data.SqlDbType.BigInt) { Value = AttributeID },
                    new("@AttributeTitle", System.Data.SqlDbType.NVarChar) { Value = AttributeTitle },
                    new("@AttributeTypeID", System.Data.SqlDbType.TinyInt) { Value = AttributeTypeID },
                    new("@ShowAcrossAllCategory", System.Data.SqlDbType.Bit) { Value = ShowAcrossAllCategory },
                ];
            return _context.Database.ExecuteSqlRawAsync("EXEC Bsk_AttributeList_Edit @AttributeID, @AttributeTitle, @AttributeTypeID, @ShowAcrossAllCategory", [.. parameters]);
        }

        public Task<int> SetLinkAttribute(long AttributeID, long CategoryID)
        {
            List<SqlParameter> parameters =
                [
                    new("@AttributeID", System.Data.SqlDbType.BigInt) { Value = AttributeID },
                    new("@CategoryID", System.Data.SqlDbType.BigInt) { Value = CategoryID },
                ];
            return _context.Database.ExecuteSqlRawAsync("EXEC Bsk_AttributeList_SetLink @AttributeID, @CategoryID", [.. parameters]);
        }

        public Task<int> TranslateAttribute(TranslateAttributeDTO dto)
        {
            List<SqlParameter> parameters =
              [
                  new("@AttributeID", System.Data.SqlDbType.Int) { Value = dto.AttributeID },
                  new("@AttributeTitle", System.Data.SqlDbType.NVarChar) { Value = dto.AttributeTitle },
                  new("@LangID", System.Data.SqlDbType.TinyInt) { Value = dto.LangID },

              ];
            return _context.Database.ExecuteSqlRawAsync("EXEC Bsk_AttributeList_Translate @AttributeID, @AttributeTitle ,@LangID", [.. parameters]);
        }

        public Task<List<AttributeByID>> GetProductAttributeTrabslatedById(long AttributeID, byte LangID)
        {
            List<SqlParameter> parameters =
                [
                    new("@AttributeID", System.Data.SqlDbType.BigInt) { Value = AttributeID },
                    new("@LangID", System.Data.SqlDbType.TinyInt) { Value = LangID },
                ];
            return _context.Set<AttributeByID>().FromSqlRaw("EXEC GetAttributeTrabslatedById @AttributeID , @LangID", [.. parameters]).ToListAsync();


        }

        public Task<List<AttributeModel>> GetList()
        {
            return _context.Set<AttributeModel>().FromSqlRaw("EXEC Bsk_Get_Attributes_V2").ToListAsync();
        }
    }
}
