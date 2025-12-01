using BratspilsDepot.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BratspilsDepot.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static Butik weShop;
        private List<Spil> katalog;
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
        public IActionResult PutIkurven(int Id)
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
            List<Spil> Kurv = weShop.hentKurv();
            return View((object)Kurv);
        }

        public IActionResult PlusIKurv(int id)
        {
            weShop.LægIKurv(id);
            List<Spil> Kurv = weShop.hentKurv();
            return View("Kurv",(object)Kurv); 
        }

        public IActionResult MinusIKurv(int id)
        {
            weShop.FjernFraKurv(id);
            List<Spil> Kurv = weShop.hentKurv();
            return View("Kurv", (object)Kurv);
        }

        public IActionResult BestillingsForm()
        {
            return View(); 
        }

        public IActionResult BekræftBestilling(string Navn, string Mail, int TelefonNummer)
        {
            Ordre ordre = weShop.LavOrdre();
            
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
