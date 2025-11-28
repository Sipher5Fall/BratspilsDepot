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
            BygKatalogspil();
        }
        
        public List<string[]> HentKatalogtekst()
        {
            
            string Katalogsti = "";
            Katalogsti += "/SpilKatalog";
            List<string> SpilIKatalog = FileIO.Read(Katalogsti);

            foreach (string spil in SpilIKatalog)
            {

                string[] splittet = spil.Split(';');
                TekstKatalog.Add(splittet);
            }
            return TekstKatalog;
        }

        public void BygKatalogspil()
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
        public List<Spil> HentKatalogspil()
        {
            return Katalog; 
        }


        public List<Spil> SeKatalog()
        {
            return Katalog;
        }
  
    }
}
