
using EgyptMart.Services.Auth.DTO.Verfication;
using EgyptMart.Services.Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.Auth.Data;

public partial class DBMasterContext : DbContext
{
    public DBMasterContext(DbContextOptions options)
    : base(options)
    {
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    public DbSet<LupBusinessTypeListModel> LupBusinessTypeListModel { get; set; }
    public DbSet<LupCountryListModel> LupCountryListModel { get; set; }
    public DbSet<PendingVerifySupplierModel> PendingVerifySupplierModel { get; set; }
    public DbSet<PendingVerifyCustomerModel> PendingVerifyCustomerModel { get; set; }
    public DbSet<LoginResponseModel> LoginResponseModel { get; set; }
    public DbSet<FindExistUserModel> FindExistUserModel { get; set; }
    public DbSet<RefreshTokenModel> RefreshTokenModel { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //{addLineAfter-2} 
        modelBuilder.Entity<LupBusinessTypeListModel>(e => e.HasNoKey());
        modelBuilder.Entity<LupCountryListModel>(e => e.HasNoKey());
        modelBuilder.Entity<PendingVerifySupplierModel>(e => e.HasNoKey());
        modelBuilder.Entity<PendingVerifyCustomerModel>(e => e.HasNoKey());
        modelBuilder.Entity<LoginResponseModel>(e => e.HasNoKey());
        modelBuilder.Entity<FindExistUserModel>(e => e.HasNoKey());
        modelBuilder.Entity<FilenameDto>(e => e.HasNoKey());

        modelBuilder.Entity<UserModel>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<UserTypeModel>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<UserTypesCountModel>(entity => { entity.HasNoKey(); });

        #region Tokens
        modelBuilder.Entity<RefreshTokenModel>(entity => { entity.HasNoKey(); });
        #endregion

        OnModelCreatingPartial(modelBuilder);
    }

}
