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
            return View(OrdreHistorik);
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

            List<Spil> alleSpil = weShop.SeKatalog();
            List<Spil> Søgefelt = new List<Spil>();

            for (int i = 0; i < alleSpil.Count; i++)
            {
                string spilKatagorier = alleSpil[i].SpilKategori.ToLower();

                if (spilKatagorier.Contains(kategori.ToLower()))
                {
                    Søgefelt.Add(alleSpil[i]);
                }
            }
            return View("Index", Søgefelt);
            
        }

        [HttpPost]
        public IActionResult VisOrdre(int ordreID)
        {
            List<Ordre> OrdreHistorik = weShop.HentOrdreHistorik();
            ViewBag.OrdreID = ordreID;
            return View((object)OrdreHistorik);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
