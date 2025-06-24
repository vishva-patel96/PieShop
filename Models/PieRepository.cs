using Microsoft.EntityFrameworkCore;

namespace PieShop.Models
{
    public class PieRepository : IPieRepository
    {
        //dependancy Injection
        private readonly PieShopDbContext _pieShopDbContext;

        public PieRepository(PieShopDbContext pieShopDbContext)
        {
            _pieShopDbContext = pieShopDbContext;
        }
        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _pieShopDbContext.Pies.Include(c => c.Category);
            }
        }
        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _pieShopDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }

        }
        public Pie? GetPieByID(int pieId)
        {
            
            {
                return _pieShopDbContext.Pies.FirstOrDefault(c => c.PieId == pieId);
            }

        }
    }
}