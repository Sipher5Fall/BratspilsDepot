using BratspilsDepot.Models;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace BratspilsDepot.Models
{
    /*
    *  Forfatter: Siw
    *  
    */
    public class Ordre
    {


        private int ordreId;
        public int OrdreId { get { return ordreId; } set { ordreId = value; } }

        public string KundeNavn { get; set; }

        public string KundeMail { get; set; }

        public int KundeTlf { get; set; }
        public List<Spil> Varer { get; set; }

        public double Total;
        public string bestillingsdato;
        public void GemOrdreId(int ordreID)
        {
            List<string> OrdreTæller = new List<string>();
            OrdreTæller.Add(ordreId.ToString());

            FileIO.Log(OrdreTæller, "/OrdreID");
        }

        public int HentOrdreId()
        {
            int ordreID = FileIO.ReadOrdreId("/OrdreID");
            return ordreID;
        }
        public Ordre()
        {
            OrdreId = HentOrdreId();
            OrdreId++;
            GemOrdreId(OrdreId);

            Varer = new List<Spil>();
            bestillingsdato = dato();
        }

        public string dato()
        {
            DateTime bestildato = DateTime.Now;
            string bestilt = $"Bestilling modtaget: {bestildato.DayOfWeek} {bestildato.Day}/{bestildato.Month}/{bestildato.Year} kl.{bestildato.Hour}:{((bestildato.Minute < 10) ? "0" + bestildato.Minute : bestildato.Minute)}";
            return bestilt;
        }

    }
}
