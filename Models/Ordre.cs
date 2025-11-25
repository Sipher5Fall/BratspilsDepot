using BratspilsDepot.Models;
using Microsoft.VisualBasic;

namespace BratspilsDepot.Models
{
    public class Ordre
    {

        /* TEST KODE
        public string KundeNavn = "Svend";
        public string KundeMail = "Test@ohshit.dk";
        public int KundeTlf = 99999999;
        public List<string[]> Varer = new List<string[]>();
        public string[] spil = { "Carcasonne", "1", "89.95" };
        public double Total = 89.95;

        public Ordre() { Varer.Add(spil); }
        */
        private int ordreId;
        public int OrdreId { get { return ordreId; } }
        public string KundeNavn { get; set; }
        public string KundeMail { get; set; }
        public int KundeTlf { get; set; }
        public List<string[]> Varer { get; set; }

        public double Total;
        public string bestillingsdato;
        public Ordre()
        {
            Varer = new List<string[]>();
            bestillingsdato = dato();
        }

        
        public void printOrdre(List<string[]> Varer)
        {
            foreach (var vare in Varer)
            {
                Console.WriteLine($"Navn: {vare[0]}, Antal: {vare[1]}, Pris: {vare[2]}");
            }
        }

        public List<double> mathhelper(List<string[]> Varer)
        {
            List<double> priser = new List<double>();
            foreach (string[]vare in Varer)
            {
                double pris = Convert.ToDouble(vare[2]);
                priser.Add(pris);
            }

            return priser;
        }
        public double beregnetpris()
        {
            List<double> priser= mathhelper(Varer);
            double sum = 0;
            foreach (double pris in priser)
            {
                sum += pris;
                //sum = sum + pris;
            }
            Total = sum;
            return sum;
        }

        public void bekræftOrdre()
        {
            OrdreHistorik kvittering = new OrdreHistorik();
            List<string> tilprint = kvittering.EncodeOrdre(this);
            foreach(string line in tilprint)
            { 
            Console.WriteLine (line);
            }
            Console.WriteLine("Din ordre er bekræftet, tak for din penge!");
        }

        public string dato()
        {
            DateTime bestildato = DateTime.Now;
            string bestilt = $"Bestilling modtaget: {bestildato.DayOfWeek} {bestildato.Day}/{bestildato.Month}/{bestildato.Year} kl.{bestildato.Hour}:{((bestildato.Minute < 10) ? "0" + bestildato.Minute : bestildato.Minute)}";
            return bestilt;
        }

        public void kundeinfo()
        {
            Console.WriteLine("Please Enter your Name");
            KundeNavn = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Please enter email");
            KundeMail = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Please enter phone number");

            try { KundeTlf = Convert.ToInt32(Console.ReadLine()); }

            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
