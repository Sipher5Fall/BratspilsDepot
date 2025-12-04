using BratspilsDepot.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BratspilsDepot.Helpers;

namespace BratspilsDepot.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly object context;
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
            //var beregnetPris = new BeregnetPris { Varer = Kurv };
            double samletpris = weShop.SamletPris();
            ViewBag.SamletPris = samletpris;
            return View((object)Kurv);
        }

        public IActionResult PlusIKurv(int id)
        {
            weShop.LægIKurv(id);
            List<Spil> Kurv = weShop.hentKurv();
            double samletpris = weShop.SamletPris();
            ViewBag.SamletPris = samletpris;
            return View("Kurv", (object)Kurv);
        }

        public IActionResult MinusIKurv(int id)
        {
            weShop.FjernFraKurv(id);
            List<Spil> Kurv = weShop.hentKurv();
            double samletpris = weShop.SamletPris();
            ViewBag.SamletPris = samletpris;
            return View("Kurv", (object)Kurv);
        }

        public IActionResult BestillingsForm()
        {
            return View();
        }

        public IActionResult OrdreHistorik()
        {
            List<Ordre> OrdreHistorik = weShop.HentOrdreHistorik();
            return View((object)OrdreHistorik);
        }

        public IActionResult BekræftBestilling(string KNavn, string KMail, int KTlf)
        {
            Ordre ordre = weShop.LavOrdre();
            ordre.KundeNavn = KNavn;
            ordre.KundeMail = KMail;
            ordre.KundeTlf = KTlf;
            weShop.Bestil(ordre);
            weShop.ArkiverOrdre(ordre);
            List<string> Kvittering = weShop.Kvittering(ordre);
            return View(Kvittering);
        }
        public ActionResult Søg(string kategori)
        {
            SpilKatalog katalog = new SpilKatalog();   
            List<Spil> alleSpil = katalog.HentKatalogspil();  
            List<Spil> SøgeFelt = new List<Spil>();  

            foreach (Spil spil in alleSpil)
                if (spil.SpilKategori.Contains(kategori))
                {
                SøgeFelt.Add(spil);
                }
            return View("Index", SøgeFelt);
        }
    }
}
