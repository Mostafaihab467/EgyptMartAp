using EgyptMart.Services.ProductsAPI.Data;
using EgyptMart.Services.ProductsAPI.DTO;
using EgyptMart.Services.ProductsAPI.IRepository;
using EgyptMart.Services.ProductsAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.ProductsAPI.Repository
{
    public class CategoryListRepository : ICategoryListRepository
    {
        private readonly DBMasterContext _context;
        public CategoryListRepository(DBMasterContext context)
        {
            _context = context;
        }

        public Task<int> Create(string CategoryTitle, int? ParentID, int? LangID, int? DisplayOrder, string CategoryImageURL)
        {
            SqlParameter ParentIDParam = new("@ParentID", System.Data.SqlDbType.Int)
            {
                Value = ParentID
            };

            SqlParameter LangIDParam = new("@LangID", System.Data.SqlDbType.Int)
            {
                Value = LangID
            };

            SqlParameter DisplayOrderParam = new("@DisplayOrder", System.Data.SqlDbType.Int)
            {
                Value = DisplayOrder
            };

            SqlParameter CategoryTitleParam = new("@CategoryTitle", System.Data.SqlDbType.NVarChar)
            {
                Value = (object)CategoryTitle ?? DBNull.Value
            };

            SqlParameter CategoryImageURLParam = new("@CategoryImageURL", System.Data.SqlDbType.NVarChar)
            {
                Value = (object)CategoryImageURL ?? DBNull.Value
            };

            return _context.Database.ExecuteSqlRawAsync("Execute Bsk_CategoryList_Create @CategoryTitle , @ParentID, @LangID, @DisplayOrder, @CategoryImageURL", CategoryTitleParam, ParentIDParam, LangIDParam, DisplayOrderParam, CategoryImageURLParam);
        }

        public Task<int> Edit(int CategoryID, string CategoryTitle, short DisplayOrder)
        {
            List<SqlParameter> parameters =
                [
                    new("@CategoryID", System.Data.SqlDbType.Int) { Value = CategoryID },
                    new("@CategoryTitle", System.Data.SqlDbType.NVarChar) { Value = CategoryTitle },
                    new("@DisplayOrder", System.Data.SqlDbType.SmallInt) { Value = DisplayOrder }
                ];

            return _context.Database.ExecuteSqlRawAsync("Execute Bsk_CategoryList_Edit @CategoryID, @CategoryTitle, @DisplayOrder", [.. parameters]);
        }

        public Task<int> Delete(int CategoryID)
        {
            SqlParameter CategoryIDParam = new("@CategoryID", System.Data.SqlDbType.Int)
            {
                Value = CategoryID
            };

            return _context.Database.ExecuteSqlRawAsync("Execute Bsk_MR_CategoryList_Delete @CategoryID", CategoryIDParam);
        }

        public Task<List<CategoryListModelView>> GetChildCategory(int ParentID, byte RepType, byte LangID = 1)
        {
            List<SqlParameter> sqlParameters = [
                new("@ParentID", System.Data.SqlDbType.Int)
            {
                Value = ParentID
            },

          new("@RepType", System.Data.SqlDbType.TinyInt)
            {
                Value = RepType
            },
                     new("@LangID", System.Data.SqlDbType.TinyInt)
            {
                Value = LangID
            }
                ];

            return _context.CategoryListModelView.FromSqlRaw("Execute Bsk_CategoryList_GetByParent @ParentID, @RepType , @LangID", [.. sqlParameters]).ToListAsync();
        }

        public Task<List<CategoryListModelView>> GetTopLevel(byte LagID, byte RepType)
        {
            SqlParameter LagIDParam = new("@LagID", System.Data.SqlDbType.TinyInt)
            {
                Value = LagID
            };

            SqlParameter RepTypeParam = new("@RepType", System.Data.SqlDbType.TinyInt)
            {
                Value = RepType
            };

            return _context.CategoryListModelView.FromSqlRaw("Execute Bsk_CategoryList_GetTopLevel @LagID, @RepType", LagIDParam, RepTypeParam).ToListAsync();
        }

        public Task<int> ChangeStatus(long CategoryID, bool IsActive)
        {
            List<SqlParameter> parameters =
                [
                    new("@CategoryID", System.Data.SqlDbType.BigInt) { Value = CategoryID },
                    new("@IsActive", System.Data.SqlDbType.Bit) { Value = IsActive },
                ];
            return _context.Database.ExecuteSqlRawAsync("EXEC Bsk_CategoryList_ChangeStatus @CategoryID, @IsActive", [.. parameters]);
        }

        public Task<List<CategoryListTranslateModel>> Translate(TranslateCategoryDTO dto)
        {

            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                 new("@CategoryID", System.Data.SqlDbType.Int)
            {
                Value = dto.CategoryID
            },

                new("@CategoryTitle", System.Data.SqlDbType.NVarChar)
            {
                Value = dto.CategoryTitle
            },


            new("@LangID", System.Data.SqlDbType.TinyInt)
            {
                Value = dto.LangID
            }
            };

            return _context.Set<CategoryListTranslateModel>().FromSqlRaw("Execute Bsk_CategoryList_Translate @CategoryID , @CategoryTitle , @LangID",
                sqlParameters[0], sqlParameters[1], sqlParameters[2]).ToListAsync();
        }

        public Task<List<CategoryListTranslateModel>> GetByLang(int BaseID, short langID)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                 new("@BaseID", System.Data.SqlDbType.Int)
            {
                Value =BaseID
            },




            new("@LangID", System.Data.SqlDbType.TinyInt)
            {
                Value =langID
            }
            };

            return _context.Set<CategoryListTranslateModel>().FromSqlRaw("Execute Bsk_CategoryList_GetItem_ByLang @BaseID ,  @LangID",
                sqlParameters[0], sqlParameters[1]).ToListAsync();
        }

        public Task<List<CategoryListModelView>> GetParentByChild(int ChildID)
        {
            SqlParameter ChildIDParam = new("@ChildID", System.Data.SqlDbType.Int)
            {
                Value = ChildID
            };



            return _context.CategoryListModelView.FromSqlRaw("Execute Bsk_CategoryList_GetParentByChild @ChildID", ChildIDParam).ToListAsync();
        }

        public Task<List<CategoryListModelView>> GetChildList(byte LangID)
        {
            SqlParameter langIDP = new("@LangID", System.Data.SqlDbType.TinyInt) { Value = LangID };
            return _context.CategoryListModelView.FromSqlRaw("EXEC Bsk_Get_CategoriesChild @LangID", langIDP).ToListAsync();
        }
    }
}
