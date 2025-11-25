using System.IO;


namespace BratspilsDepot.Models
{
    public class SpilKatalog
    {
        List<string[]> TekstKatalog;
        public SpilKatalog() { TekstKatalog = new List<string[]>(); TekstKatalog = HentKatalog(); }
        
        public List<string[]> HentKatalog()
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

        public List<string[]> SeKatalog()
        {
            return TekstKatalog;
        }
  
    }
}
