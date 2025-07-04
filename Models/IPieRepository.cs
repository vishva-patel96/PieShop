using System.IO.Pipelines;

namespace PieShop.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }
        IEnumerable<Pie> PiesOfTheWeek { get; }
        Pie? GetPieByID(int id);
        IEnumerable<Pie> SearchPies(string searchQuery);
    }
}
