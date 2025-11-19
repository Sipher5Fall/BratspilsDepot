using BratspilsDepot.Models;
using Microsoft.VisualBasic;

namespace BratspilsDepot.Models
{
    public class Ordre
    {
        private int OrdreId;
        public void print()
        {
            
        }

        public double beregnetpris(List<double> priser)
        {
            double sum = 0;
            foreach (double pris in priser)
            { 
                sum += pris;
                //sum = sum + pris;
            }
            return sum;
        }
        
        public void bekraft()
        {

        }

        public void dato()
        {
            DateTime bestildato = DateTime.Now;
            string bestilt = $"Bestilling modtaget: {bestildato.DayOfWeek}{bestildato.Day}/{bestildato.Month}/{bestildato.Year} kl.{bestildato.Hour}:{bestildato.Minute}";
        }

        public void kundeinfo()
        {

        }
    }
}
