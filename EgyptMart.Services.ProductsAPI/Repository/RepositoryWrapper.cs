using EgyptMart.Services.ProductsAPI.Data;
using EgyptMart.Services.ProductsAPI.IRepository;

namespace EgyptMart.Services.ProductsAPI.Repository
{
    public class RepositoryWrapper(DBMasterContext dbContext) : IRepositoryWrapper
    {
        private DBMasterContext _dbContext = dbContext;
        private ICategoryListRepository? _CategoryListRepository;
        private IAttributeRepository? _AttributeRepository;
        private IProductsRepository? _ProductsRepository;
        private IProductAttributeRepository? _ProductAttributeRepository;
        private IProductsRatingsRepository? _ProductsRatingsRepository;
        private IProductImagesRepository? _ProductImagesRepository;

        public IAttributeRepository AttributeRepository
        {
            get
            {
                if (_AttributeRepository == null)
                {
                    _AttributeRepository = new AttributeRepository(_dbContext);
                }
                return _AttributeRepository;
            }
        }
        
        public ICategoryListRepository CategoryListRepository
        {
            get
            {
                if (_CategoryListRepository == null)
                {
                    _CategoryListRepository = new CategoryListRepository(_dbContext);
                }
                return _CategoryListRepository;
            }
        }

        public IProductsRepository ProductsRepository
        {
            get
            {
                if (_ProductsRepository == null)
                {
                    _ProductsRepository = new ProductsRepository(_dbContext);
                }
                return _ProductsRepository;
            }
        }
        
        public IProductAttributeRepository ProductAttributeRepository
        {
            get
            {
                if (_ProductAttributeRepository == null)
                {
                    _ProductAttributeRepository = new ProductAttributeRepository(_dbContext);
                }
                return _ProductAttributeRepository;
            }
        }

        public IProductsRatingsRepository ProductsRatingsRepository
        {
            get
            {
                if (_ProductsRatingsRepository == null)
                {
                    _ProductsRatingsRepository = new ProductsRatingsRepository(_dbContext);
                }
                return _ProductsRatingsRepository;
            }
        }
        
        public IProductImagesRepository ProductImagesRepository
        {
            get
            {
                if (_ProductImagesRepository == null)
                {
                    _ProductImagesRepository = new ProductImagesRepository(_dbContext);
                }
                return _ProductImagesRepository;
            }
        }
    }
}
