using BratspilsDepot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BratspilsDepot.Models
{
    internal class Butik
    {
        private OrdreHistorik ordrehistorik;
        public SpilKatalog spilkatalog;
        public static Kurv kurv = new Kurv();
        private Ordre ordre;
        public Butik()
        {
            ordrehistorik = new OrdreHistorik();
            spilkatalog = new SpilKatalog();
        }

        public List<Spil> SeKatalog()
        {
            return spilkatalog.SeKatalog();
        }
        public void LægIKurv(int Id)
        {
            kurv.LægIKurv(Id);
        }
        public void FjernFraKurv(int Id)
        {
            kurv.FjernSpil(Id);
        }

        public Ordre LavOrdre()
        {
            ordre = new Ordre();
            return ordre;
        }
        public void Bestil(Ordre ordre)
        {
            kurv.Bestil(ordre);
        }

        public List<Spil> hentKurv()
        {
            return kurv.KurvTilDisplay();
        }
           
        public double SamletPris()
        {
            return kurv.beregnetpris();
        }

        public List<string> Kvittering(Ordre ordre)
        {
           return ordrehistorik.EncodeOrdre(ordre);
        }
    }

}
