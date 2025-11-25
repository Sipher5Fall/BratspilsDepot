using BratspilsDepot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Models
{
    internal class Butik
    {
        private OrdreHistorik ordrehistorik;
        public SpilKatalog spilkatalog;
        public Kurv kurv; 
        public Butik() 
        {
            ordrehistorik = new OrdreHistorik();   
            spilkatalog = new SpilKatalog();
            kurv = new Kurv();

        }

        public void SeKatalog()
        {
            spilkatalog.placeholdernavn();
        }
    }

}
