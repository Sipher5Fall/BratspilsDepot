using System.IO;


namespace BratspilsDepot.Models
{
    public class SpilKatalog
    {
        List<string[]> TekstKatalog;
        public SpilKatalog() { TekstKatalog = new List<string[]>(); TekstKatalog = SeKatalog(); }
        
        public List<string[]> SeKatalog()
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

        public void placeholdernavn()
        {
            foreach (string[] spil in TekstKatalog)
            {
                Console.WriteLine($"Navn:{spil[0]} ID:{spil[1]} Pris:{spil[2]} Kategori:{spil[3]}");
            }
        }
  
    }
}
