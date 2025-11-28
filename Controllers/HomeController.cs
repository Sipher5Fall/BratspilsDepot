using BratspilsDepot.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BratspilsDepot.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static Butik weShop;
        private List<string[]> katalog;
        public HomeController(ILogger<HomeController> logger) //hver gang IactionResult kører, kører den gennem loggeren. koden kørers igen. 
        {
            _logger = logger;
            weShop = new Butik();
            katalog = weShop.SeKatalog();
        }

        public IActionResult Index()
        {
            return View((object)katalog);     // sker allersidst. return et vidirect med viewets navn.
        }
        public IActionResult PutIkurven(string Id)
        {
            weShop.LægIKurv(Id);
            return View("Index", (object)katalog);     
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Kurv()
        {
            List<string[]> Kurv = weShop.hentKurv();
            return View((object)Kurv);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
