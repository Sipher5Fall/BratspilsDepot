using BratspilsDepot.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BratspilsDepot.Helpers;

namespace BratspilsDepot.Controllers
{
    /*
     *  Forfatter: Lavet af kollektivet
     *  
     */
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
            Medarbejder admin = weShop.LavMedarbejder();
            return View(admin);
        }
        public IActionResult checklogin(string uname, string psw)
        {
            Medarbejder admin = weShop.LavMedarbejder();
            List<Ordre> OrdreHistorik = weShop.HentOrdreHistorik();

            if (uname == admin.Brugernavn && psw == admin.Password)
            { 
                return View("OrdreHistorik", OrdreHistorik); 
            }
            else 
             
                return View("Privacy"); 
            
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

        public IActionResult CheckKurv()
        { 
            List<Spil> VareCheck = weShop.hentKurv(); 
            if (VareCheck.Count != 0)
            { 
                return View("BestillingsForm"); 
            }
            else 
            {
                double samletpris = weShop.SamletPris();
                ViewBag.SamletPris = samletpris;
                string Tomtkurv = "Kurven er tom";
                ViewBag.Tomtkurv = Tomtkurv;
                return View("Kurv", VareCheck); 
            }
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
