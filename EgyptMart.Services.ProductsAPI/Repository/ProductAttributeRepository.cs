using EgyptMart.Services.ProductsAPI.Data;
using EgyptMart.Services.ProductsAPI.DTO;
using EgyptMart.Services.ProductsAPI.IRepository;
using EgyptMart.Services.ProductsAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.ProductsAPI.Repository
{
    public class ProductAttributeRepository(DBMasterContext context) : IProductAttributeRepository
    {
        private readonly DBMasterContext _context = context;

        public Task<int> PullInitial(Int64 ProductID)
        {
            List<SqlParameter> parameters =
                [
                    new("@ProductID", System.Data.SqlDbType.BigInt) { Value = ProductID },
                ];
            return _context.Database.ExecuteSqlRawAsync("EXEC Products_Attributes_PullInitial @ProductID", [.. parameters]);
        }

        public Task<int> CreateAttributes(long ProductID, int AttributeID, string Value, byte LangID, short DisplayOrder)
        {
            List<SqlParameter> parameters =
                [
                    new("@ProductID", System.Data.SqlDbType.BigInt) { Value = ProductID },
                    new("@AttributeID", System.Data.SqlDbType.Int) { Value = AttributeID },
                    new("@Value", System.Data.SqlDbType.NVarChar) { Value = Value },
                    new("@LangID", System.Data.SqlDbType.TinyInt) { Value = LangID },
                    new("@DisplayOrder", System.Data.SqlDbType.SmallInt) { Value = DisplayOrder },
                ];
            return _context.Database.ExecuteSqlRawAsync("EXEC Products_Attributes_Create @ProductID, @AttributeID, @Value, @LangID, @DisplayOrder", [.. parameters]);
        }

        public Task<int> EditAtributes(long LinkID, string Value, short DisplayOrder)
        {
            List<SqlParameter> parameters =
                [
                    new("@LinkID", System.Data.SqlDbType.BigInt) { Value = LinkID },
                    new("@Value", System.Data.SqlDbType.NVarChar) { Value = Value },
                    new("@DisplayOrder", System.Data.SqlDbType.SmallInt) { Value = DisplayOrder },
                ];
            return _context.Database.ExecuteSqlRawAsync("EXEC Products_Attributes_Edit @LinkID, @Value, @DisplayOrder", [.. parameters]);
        }

        public Task<int> DeleteAttributes(long LinkID)
        {
            SqlParameter LinkIDParam = new("@LinkID", System.Data.SqlDbType.BigInt) { Value = LinkID };
            return _context.Database.ExecuteSqlRawAsync("EXEC Products_Attributes_Delete @LinkID", LinkIDParam);
        }

        public Task<List<ProductAttibutesListModelView>> GetAttributes(long ProductID)
        {
            SqlParameter ProductIDParam = new("@ProductID", System.Data.SqlDbType.BigInt) { Value = ProductID };
            return _context.ProductAttibutesListModelView.FromSqlRaw("EXEC Products_Attributes_Get @ProductID", ProductIDParam).ToListAsync();
        }
        public Task<List<ProductAttributesTranslatedModel>> GetAttributesByLang(long ProductID, byte LangID)
        {
            List<SqlParameter> parameters =
              [
                  new("@ProductID", System.Data.SqlDbType.BigInt) { Value = ProductID },

                  new("@LangID", System.Data.SqlDbType.TinyInt) { Value = LangID },

              ];
            return _context.Set<ProductAttributesTranslatedModel>().FromSqlRaw("EXEC Products_Attributes_GetByLang @ProductID, @LangID", [.. parameters]).ToListAsync();
        }
        public Task<int> TranslateAttributeValue(TranslateProductAttributeValueDTO dto)
        {
            List<SqlParameter> parameters =
            [
             new("@LinkID", System.Data.SqlDbType.BigInt) { Value = dto.LinkID },
                new("@Value", System.Data.SqlDbType.NVarChar) { Value = dto.Value },
                new("@LangID", System.Data.SqlDbType.TinyInt) { Value = dto.LangID }
            ];
            return _context.Database.ExecuteSqlRawAsync("EXEC Products_Attributes_Translate @LinkID, @Value , @LangID", parameters[0], parameters[1], parameters[2]);
        }
    }
}
