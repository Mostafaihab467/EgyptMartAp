using EgyptMart.Services.CMSAPI.Interfaces.Helper;

namespace EgyptMart.Services.CMSAPI.IRepository
{
    public interface IRepositoryWrapper
    {

        ICMSListRepository CMSListRepository { get; }
        ITransalationRepository transalationRepository { get; }

        ILogger Logger { get; }

        IHelperSerivce helperSerivce { get; }

        IWidgets_SocialMediaRepository widgets_SocialMedia { get; }

        IWidgets_HeaderMenu_Repository widgets_HeaderMenu_Repository { get; }

        IProductYouMayLikeTRepository productYouMayLikeTRepository { get; }

        IStoreFrontWidgetsRepository trendingProductRepository { get; }

        ISubscribtionListRepository subscribtionListRepository { get; }

        IFooterLinksRepository footerLinksRepository { get; }

        IWidgets_FixedPagesRepository widgets_FixedPagesRepository { get; }
        ILubsRepository lubsRepository { get; }
        IWidgetSliderRepository WidgetSliderRepository { get; }
        IWidgetFAQRepositroy WidgetFAQRepository { get; }
        ICountryRepository countryRepository { get; }
        IBusinessRepository BusinessRepository { get; }
        IWishListRepository WishListRepository { get; }

        IWidgetContactUsRepository WidgetContactUsRepository { get; }
        IContactCustomerRepository ContactCustomerRepository { get; }

    }
}
