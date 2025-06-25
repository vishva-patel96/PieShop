using Microsoft.AspNetCore.Mvc;
using PieShop.Models;

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
    }
}
