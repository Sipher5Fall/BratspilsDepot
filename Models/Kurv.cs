using BratspilsDepot.Models;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace BratspilsDepot.Models
{
    public class Kurv
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private List<string[]> varer = new List<string[]>();
        private SpilKatalog katalog;

        public Kurv() 
        {
            katalog = new SpilKatalog();
        }
        public void LægIKurv(string Id)
        {
            List<string[]> spilliste = katalog.SeKatalog();
           for (int i = 0; i<spilliste.Count; i++ )// får counter med. tæller hvor mange gange vi kører igennem.
            { 
                if (spilliste[i][1].Contains(Id))
                {
                    varer.Add(spilliste[i]);
                    break;
                }
            }    

        }

        public void FjernSpil(string Id)
        {
            for (int i = 0; i < varer.Count; i++)
            {
                if (varer[i][1].Contains(Id))
                {
                    varer.RemoveAt(i);
                    break;
                }
            }

        }
        public void VisKurv()
        {
            foreach (var spil in varer)
            {
                Console.WriteLine(spil[0]);
            }
        }

        public void Bestil()
        {
            Ordre ordre = new Ordre();
            ordre.kundeinfo();
            ordre.Varer = varer;
            ordre.beregnetpris();
            ordre.bekræftOrdre();
        }

    }
}
