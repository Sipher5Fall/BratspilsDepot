using System.IO;


namespace BratspilsDepot.Models
{
    public class SpilKatalog
    {
        List<string[]> TekstKatalog;
        List<Spil> Katalog;
        public SpilKatalog() 
        { 
            TekstKatalog = new List<string[]>(); 
            TekstKatalog = HentKatalogtekst(); 
            Katalog = new List<Spil>();
            Katalog = HentKatalogspil();
        }
        
        public void HentKatalogtekst()
        {
            
            string Katalogsti = "";
            Katalogsti += "/SpilKatalog";
            List<string> SpilIKatalog = FileIO.Read(Katalogsti);

            foreach (string spil in SpilIKatalog)
            {

                string[] splittet = spil.Split(';');
                TekstKatalog.Add(splittet);
            }
        }

        public void HentKatalogspil()
        {
            string Katalogsti = "";
            Katalogsti += "/SpilKatalog";
            List<string> SpilIKatalog = FileIO.Read(Katalogsti);
            foreach (string spil in SpilIKatalog)
            {

                string[] splittet = spil.Split(';');
                Spil produkt = new Spil(splittet[0], Convert.ToInt32(splittet[1]), Convert.ToDouble(splittet[2]), splittet[3], splittet[4], splittet[5]);
                Katalog.Add(produkt);
            }
        }

        public List<string[]> SeKatalog()
        {
            return TekstKatalog;
        }
  
    }
}
