
using EgyptMart.Services.CMSAPI.DTO;
using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.DTOS.CMS;
using EgyptMart.Services.CMSAPI.Models;
using EgyptMart.Services.CMSAPI.Models.Country;
using EgyptMart.Services.CMSAPI.Models.FooterLink;
using EgyptMart.Services.CMSAPI.Models.LangTranslate;
using EgyptMart.Services.CMSAPI.Models.Lup_Lang;
using EgyptMart.Services.CMSAPI.Models.WidgetHeaderMenue;
using EgyptMart.Services.CMSAPI.Models.Widgets_FixedPages;
using EgyptMart.Services.CMSAPI.Models.WidgetsSocialMedia;
using EgyptMart.Services.CMSAPI.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.CMSAPI.Data;


public partial class DBMasterContext : DbContext
{
    public DBMasterContext(DbContextOptions options)
    : base(options)
    {
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    public virtual DbSet<CompanyProfileModelView> CompanyProfileModelView { get; set; }
    public virtual DbSet<ProductYouMayLikeViewModel> productYouMayLikeDtoViewModel { get; set; }
    public virtual DbSet<WidgetSliderModel> WidgetSliderModel { get; set; }
    public virtual DbSet<WidgetFAQModel> WidgetFAQModel { get; set; }
    public virtual DbSet<WishListViewModel> WishListViewModel { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //{addLineAfter-2} 

        modelBuilder.Entity<CreateCompanyProfileDto>(entity => { entity.HasNoKey(); });

        modelBuilder.Entity<CompanyProfileDto>(entity => { entity.HasNoKey(); });


        modelBuilder.Entity<ProductYouMayLikeViewModel>(entity => { entity.HasNoKey(); });



        modelBuilder.Entity<SupplierDto>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<CreateCompanyProfileDto>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<WidgetsSocialMediaGetModel>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<WidgetsHeaderMenuGetTopLevelModel>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<WidgetsHeaderMenuModel>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<WidgetsHeaderModel>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<CompanyProfileModelView>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<WidgetSliderModel>(entity => { entity.HasNoKey(); });

        modelBuilder.Entity<WidgetFAQModel>(entity => { entity.HasNoKey(); });

        modelBuilder.Entity<UserProfileImageModel>(entity => { entity.HasNoKey(); });

        modelBuilder.Entity<ProductBasicViewModel>(entity => { entity.HasNoKey(); });

        modelBuilder.Entity<SubscribtionList_GetListModel>(entity => { entity.HasNoKey(); });


        modelBuilder.Entity<langTranslateModel>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<HeaderMenuModel>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<HeaderMenuModel>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<FooterLinkModel>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<WidgetsFixedPageModel>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<Lup_LangModel>(entity => { entity.HasNoKey(); });


        modelBuilder.Entity<GetWidgetContactUsModel>(entity => { entity.HasNoKey(); });


        #region Customer Contact

        modelBuilder.Entity<ContactCustomerListModel>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<ContactCustomerReplysModel>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<CreateContactCustomerModel>(entity => { entity.HasNoKey(); });

        #endregion



        modelBuilder.Entity<UserProfileImageModel>(entity => { entity.HasNoKey(); });

        modelBuilder.Entity<BusinessTypeTranslationModel>(entity => { entity.HasNoKey(); });

        modelBuilder.Entity<CompantTranslatedGetModel>(entity => { entity.HasNoKey(); });


        modelBuilder.Entity<PreUsersExtSuppliersExtTranslationDto>(entity => { entity.HasNoKey(); });

        modelBuilder.Entity<FilenameDto>(entity => { entity.HasNoKey(); });

        modelBuilder.Entity<ProductBasicViewModel>(entity => { entity.HasNoKey(); });

        modelBuilder.Entity<SubscribtionList_GetListModel>(entity => { entity.HasNoKey(); });


        modelBuilder.Entity<ProfileViewModel>(entity => { entity.HasNoKey(); });

        modelBuilder.Entity<WishListViewModel>(entity => { entity.HasNoKey(); });

        modelBuilder.Entity<CountryModel>(entity => { entity.HasNoKey(); });



        OnModelCreatingPartial(modelBuilder);
    }

}
