namespace PieShop.Models
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly PieShopDbContext _PieShopDbContext;

        public CategoryRepository(PieShopDbContext pieShopDbContext)
        {
            _PieShopDbContext = pieShopDbContext;
        }

        public IEnumerable<Category> AllCategories => _PieShopDbContext.Categories.OrderBy(p => p.CategoryName);
    }
}
