using EgyptMart.Services.ProductsAPI.DTO.AttributeList;
using EgyptMart.Services.ProductsAPI.Models;
using EgyptMart.Services.ProductsAPI.Models.Attribute;
using EgyptMart.Services.ProductsAPI.Models.ProductList;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.ProductsAPI.Data;

public partial class DBMasterContext : DbContext
{
    public DBMasterContext(DbContextOptions options)
    : base(options)
    {
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public virtual DbSet<CategoryListModelView> CategoryListModelView { get; set; }
    public virtual DbSet<ProductListModelView> ProductListModelView { get; set; }
    public virtual DbSet<ProductReviewModelView> ProductReviewModelView { get; set; }
    public virtual DbSet<ProductIDModelView> ProductIDModelView { get; set; }
    public virtual DbSet<ProductAttibutesListModelView> ProductAttibutesListModelView { get; set; }
    public virtual DbSet<ProductImagesListModelView> ProductImagesListModelView { get; set; }
    public virtual DbSet<AttributeLinkMatrixModel> AttributeLinkMatrixModel { get; set; }
    public virtual DbSet<ProductListPaginatedModelView> ProductListPaginatedModelView { get; set; }
    public virtual DbSet<ProductReviewPaginationModelView> ProductReviewPaginationModelView { get; set; }

    public virtual DbSet<GenericReturnIDModelView> GenericReturnIDModelView { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryListModelView>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<CategoryListTranslateModel>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<ProductListModelView>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<ProductReviewModelView>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<ProductIDModelView>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<ProductAttibutesListModelView>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<ProductAttributesTranslatedModel>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<ProductImagesListModelView>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<GenericReturnIDModelView>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<AttributeModel>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<AttributeByID>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<AttributeLinkMatrixModel>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<ProductListPaginatedModelView>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<ProductReviewPaginationModelView>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<Product3DModelView>(entity => { entity.HasNoKey(); });




        //{addLineAfter-2} 

        OnModelCreatingPartial(modelBuilder);
    }

}
