using EgyptMart.Services.AdsManagmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.AdsManagmentAPI.Data;

public partial class DBMasterContext : DbContext
{
    public DBMasterContext(DbContextOptions options)
    : base(options)
    {
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    public DbSet<AdsLocationsListModel> AdsLocationsListModel { get; set; }
    public DbSet<SubscriptionsListModel> SubscriptionsLisModel { get; set; }
    public DbSet<SubscribtionCreateModel> SubscribtionCreateModel { get; set; }
    public DbSet<UserMySubscriptionModel> UserMySubscriptionModel { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //{addLineAfter-2} 

        modelBuilder.Entity<AdsLocationsListModel>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<SubscriptionsListModel>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<SubscribtionCreateModel>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<UserMySubscriptionModel>(entity => { entity.HasNoKey(); });

        OnModelCreatingPartial(modelBuilder);
    }

}
