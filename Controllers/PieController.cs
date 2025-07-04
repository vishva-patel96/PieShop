using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using PieShop.ViewModels;

namespace PieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPieRepository _pieRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _pieRepository = pieRepository;
        }
        public IActionResult List()
        {
            //ViewBag.CurrentCategory = "Cheese cakes";
            return View(_pieRepository.AllPies);
        }
        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieByID(id);
            if(pie == null)
            {
                return NotFound();
            }
            return View(pie);
        }
        public IActionResult Search()
        {
            return View();
        }
        //public ViewResult List(string category)
        //{
        //    IEnumerable<Pie> pies;
        //    string? currentCategory;

        //    if (string.IsNullOrEmpty(category))
        //    {
        //        pies = _pieRepository.AllPies.OrderBy(p => p.PieId);
        //        currentCategory = "All pies";
        //    }
        //    else
        //    {
        //        pies = _pieRepository.AllPies.Where(p => p.Category.CategoryName == category)
        //            .OrderBy(p => p.PieId);
        //        currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
        //    }

        //    return View(new PieListViewModel(pies, currentCategory));
        //}

    }
}
