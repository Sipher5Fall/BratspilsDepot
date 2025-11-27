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
        public Butik() 
        {
            ordrehistorik = new OrdreHistorik();   
            spilkatalog = new SpilKatalog();
        }

        public List<string[]> SeKatalog()
        {
            return spilkatalog.SeKatalog();
        }
        public void LægIKurv(string Id)
        {
            kurv.LægIKurv(Id);
        }
        public void FjernFraKurv(string Id)
        {
            kurv.FjernSpil(Id);
        }
        public void Bestil()
        {
            kurv.Bestil();
        }
    }

}
