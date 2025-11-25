using BratspilsDepot.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Webshop.Models;

namespace BratspilsDepot.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static Butik weShop; 
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            weShop = new Butik();
        }

        public IActionResult Index()
        {
            List<string[]> katalog = weShop.SeKatalog();
            return View((object)katalog);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Kurv()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
