using BratspilsDepot.Models;
using System.Diagnostics;
using System.IO;

namespace BratspilsDepot.Models
{
    public class Kurv
    {
        public int SpilId { get; set;}
        public string Name{ get; set;}

        private List<Spil> SpilIkurv = new List<Spil>();
        public List<Spil> SpilIKurv { get; set; }


        public Kurv() { }
        public void TilføjSpil()
        {
            SpilIKurv.Add(new Spil() { Name = "Matador", SpilId = 1000, SpilPris = 200 });
            SpilIKurv.Add(new Spil() { Name = "Fisk", SpilId = 1001, SpilPris = 50 });
            SpilIKurv.Add(new Spil() { Name = "Uno", SpilId = 1003, SpilPris = 99 });


            string sti ="";
            Directory.SetCurrentDirectory(sti);
            sti += "/Helpers/WriteLines";
           List<string> Spilkatalog = FileIO.Read(sti);


           // string[] linesUp = System.IO.File.ReadAllLines(@"WriteLines.txt");

            // string[] ar = { "I", "Belive", "you" };
            // System.IO.File.WriteAllLines(@"WriteLines.txt", ar);



            foreach (Spil spil in SpilIKurv)
            {
                Console.WriteLine();
            }
         
        }

        public void FjernSpil()
        {
            SpilIKurv.Remove(new Spil());

            

            


        }

        public class ShopServic()
        {
            
        }

    }
}

