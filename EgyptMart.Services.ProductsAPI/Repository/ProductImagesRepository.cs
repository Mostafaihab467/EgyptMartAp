using EgyptMart.Services.ProductsAPI.Data;
using EgyptMart.Services.ProductsAPI.IRepository;
using EgyptMart.Services.ProductsAPI.Models;
using EgyptMart.Services.ProductsAPI.Models.ProductList;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.ProductsAPI.Repository
{
    public class ProductImagesRepository(DBMasterContext context) : IProductImagesRepository
    {
        private readonly DBMasterContext _context = context;

        public Task<int> CreateImages(long ProductID, string ImageURL, bool IsThumbMain, bool IsMain)
        {
            List<SqlParameter> parameters =
                [
                new("@ProductID", System.Data.SqlDbType.BigInt) { Value = ProductID },
                    new("@ImageURL", System.Data.SqlDbType.NVarChar) { Value = ImageURL },
                    new("@IsThumbMain", System.Data.SqlDbType.Bit) { Value = IsThumbMain },
                    new("@IsMain", System.Data.SqlDbType.Bit) { Value = IsMain },
                ];
            return _context.Database.ExecuteSqlRawAsync("EXEC Products_Images_Create @ProductID, @ImageURL, @IsThumbMain, @IsMain", [.. parameters]);
        }

        public Task<int> DeleteImages(long ImageID)
        {
            List<SqlParameter> parameters =
                [
                    new("@ImageID", System.Data.SqlDbType.BigInt) { Value = ImageID },
                ];
            return _context.Database.ExecuteSqlRawAsync("EXEC Products_Images_Remove @ImageID", [.. parameters]);
        }

        public Task<int> EditImages(long ImageID, string ImageURL, bool IsThumbMain, bool IsMain)
        {
            List<SqlParameter> parameters =
                [
                    new("@ImageID", System.Data.SqlDbType.BigInt) { Value = ImageID },
                    new("@ImageURL", System.Data.SqlDbType.NVarChar) { Value = ImageURL },
                    new("@IsThumbMain", System.Data.SqlDbType.Bit) { Value = IsThumbMain },
                    new("@IsMain", System.Data.SqlDbType.Bit) { Value = IsMain },
                ];
            return _context.Database.ExecuteSqlRawAsync("EXEC Products_Images_Edit @ImageID, @ImageURL, @IsThumbMain, @IsMain", [.. parameters]);
        }

        public Task<List<ProductImagesListModelView>> GetImages(long ProductID)
        {
            List<SqlParameter> parameters =
                [
                    new("@ProductID", System.Data.SqlDbType.BigInt) { Value = ProductID },
                ];
            return _context.ProductImagesListModelView.FromSqlRaw("EXEC Products_Images_Get @ProductID", [.. parameters]).ToListAsync();
        }

        public Task<List<Product3DModelView>> GetProduct3DModels(long ProductID)
        {
            List<SqlParameter> parameters =
               [
                   new("@ProductID", System.Data.SqlDbType.BigInt) { Value = ProductID },
                ];
            return _context.Set<Product3DModelView>().FromSqlRaw("EXEC Products_3Ds_Get @ProductID", [.. parameters]).ToListAsync();
        }

        public Task<int> Insert3DModel(long ProductID, string Model3D)
        {
            List<SqlParameter> parameters =
               [
                   new("@ProductID", System.Data.SqlDbType.BigInt) { Value = ProductID },
                   new("@ModelURL", System.Data.SqlDbType.NVarChar , 250) { Value = Model3D },
                ];
            return _context.Database.ExecuteSqlRawAsync("Exec Products_3Ds_Create @ProductID , @ModelURL", [.. parameters]);
        }

        public Task<int> Remove3DModel(long ModelID)
        {
            List<SqlParameter> parameters =
             [
                 new("@modelid", System.Data.SqlDbType.BigInt) { Value = ModelID },
                ];
            return _context.Database.ExecuteSqlRawAsync("EXEC Products_3Ds_Remove @modelid", [.. parameters]);
        }
    }
}
