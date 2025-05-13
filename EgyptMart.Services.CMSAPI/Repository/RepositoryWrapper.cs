using EgyptMart.Services.CMSAPI.Data;
using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.Interfaces.Helper;
using EgyptMart.Services.CMSAPI.IRepository;

namespace EgyptMart.Services.CMSAPI.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IConfiguration _configuration;
        private DBMasterContext _dbContext;
        public ICMSListRepository cMSListRepository;
        private readonly ILogger _Logger;
        private readonly IHelperSerivce _helperSerivce;
        private readonly IWidgets_SocialMediaRepository _widgets_SocialMedia;
        private readonly IWidgets_HeaderMenu_Repository _HeaderMenu_Repository;
        private readonly IProductYouMayLikeTRepository _productYouMayLikeTRepository;
        private readonly IStoreFrontWidgetsRepository _trendingProductRepository;
        private readonly ISubscribtionListRepository _subscribtionListRepository;
        private readonly IFooterLinksRepository _footerLinksRepository;
        public IWidgetFAQRepositroy _WidgetFAQRepositroy;
        public IWidgetSliderRepository _WidgetSliderRepository;
        private readonly IWidgets_FixedPagesRepository _widgets_FixedPagesRepository;
        private readonly ITransalationRepository _transalationRepository;
        private readonly ILubsRepository _lubsRepository;
        private readonly ICountryRepository _countryRepository;
        private IBusinessRepository _businessRepository;
        private IWishListRepository _wishListRepository;
        private IContactCustomerRepository _contactCustomerRepository;

        private IWidgetContactUsRepository _widgdetContactUsRepository;

        public RepositoryWrapper(DBMasterContext dbContext, ICMSListRepository cMSListRepository, IConfiguration configuration, ILogger<SuppliersEditDto> Logger
            , IHelperSerivce helperSerivce, IWidgets_SocialMediaRepository widgets_SocialMedia, IWidgets_HeaderMenu_Repository headerMenu_Repository,
            IProductYouMayLikeTRepository productYouMayLikeTRepository, IStoreFrontWidgetsRepository trendingProductRepository, ISubscribtionListRepository subscribtionListRepository, IFooterLinksRepository footerLinksRepository, ITransalationRepository transalationRepository, IWidgets_FixedPagesRepository widgets_FixedPagesRepository, ILubsRepository lubsRepository)
        {
            this._dbContext = dbContext;
            this.cMSListRepository = cMSListRepository;
            _configuration = configuration;
            _Logger = Logger;
            _helperSerivce = helperSerivce;
            _widgets_SocialMedia = widgets_SocialMedia;
            _HeaderMenu_Repository = headerMenu_Repository;
            _productYouMayLikeTRepository = productYouMayLikeTRepository;
            _trendingProductRepository = trendingProductRepository;
            _subscribtionListRepository = subscribtionListRepository;
            _footerLinksRepository = footerLinksRepository;
            _transalationRepository = transalationRepository;
            _lubsRepository = lubsRepository;
            _widgets_FixedPagesRepository = widgets_FixedPagesRepository;
        }

        public ICMSListRepository CMSListRepository
        {
            get
            {
                if (cMSListRepository == null)
                {

                    cMSListRepository = new CMSListRepository(_dbContext, _configuration);
                }
                return cMSListRepository;


            }

        }

        public ILogger Logger => _Logger;
        public IHelperSerivce helperSerivce => _helperSerivce;
        public IWidgets_SocialMediaRepository widgets_SocialMedia => _widgets_SocialMedia;
        public IWidgets_HeaderMenu_Repository widgets_HeaderMenu_Repository => _HeaderMenu_Repository;
        public IProductYouMayLikeTRepository productYouMayLikeTRepository => _productYouMayLikeTRepository;
        public IStoreFrontWidgetsRepository trendingProductRepository => _trendingProductRepository;

        public ISubscribtionListRepository subscribtionListRepository => _subscribtionListRepository;

        public IFooterLinksRepository footerLinksRepository => _footerLinksRepository;
        public ITransalationRepository transalationRepository => _transalationRepository;

        public IWidgets_FixedPagesRepository widgets_FixedPagesRepository => _widgets_FixedPagesRepository;

        public ILubsRepository lubsRepository => _lubsRepository;

        public IWidgetSliderRepository WidgetSliderRepository
        {
            get
            {
                if (_WidgetSliderRepository == null)
                {

                    _WidgetSliderRepository = new WidgetsSlidersRepository(_dbContext);
                }
                return _WidgetSliderRepository;
            }
        }

        public IWishListRepository WishListRepository
        {
            get
            {
                if (_wishListRepository == null)
                {

                    _wishListRepository = new WishListRepository(_dbContext);
                }
                return _wishListRepository;
            }
        }

        public IContactCustomerRepository ContactCustomerRepository
        {
            get
            {
                if (_contactCustomerRepository == null)
                {

                    _contactCustomerRepository = new ContactCustomerRepository(_dbContext);
                }
                return _contactCustomerRepository;
            }
        }

        public IWidgetFAQRepositroy WidgetFAQRepository
        {
            get
            {
                if (_WidgetFAQRepositroy == null)
                {

                    _WidgetFAQRepositroy = new WidgetFAQRepository(_dbContext);
                }
                return _WidgetFAQRepositroy;
            }
        }

        public IBusinessRepository BusinessRepository
        {
            get
            {
                if (_businessRepository == null)
                {

                    _businessRepository = new BusinessRepository(_dbContext);
                }
                return _businessRepository;
            }
        }


        public IWidgetContactUsRepository WidgetContactUsRepository
        {
            get
            {
                if (_widgdetContactUsRepository == null)
                {

                    _widgdetContactUsRepository = new WidgetContactUsRepository(_dbContext);
                }
                return _widgdetContactUsRepository;
            }
        }
        public ICountryRepository countryRepository => _countryRepository;



    }
}
