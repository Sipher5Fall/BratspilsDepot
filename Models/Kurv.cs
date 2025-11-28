using BratspilsDepot.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.X509Certificates;


/// <summary>
/// Constructer for vores kurv klasse.
/// 
/// skrevet af Ida . 
/// </summary>

namespace BratspilsDepot.Models
{
    public class Kurv
    {
        private List<Spil> varer;   // vil man ikke aflevere objeket kan man aflevere det som string. så kunden aldrig rør vores objekt.
        private SpilKatalog katalog;


        public Kurv() 
        {
            varer = new List<Spil>();
            katalog = new SpilKatalog();
            varer = katalog.HentKatalogspil();
        }
        public void LægIKurv(int Id)
        {
           
           for (int i = 0; i <varer.Count; i++ )// får counter med. tæller hvor mange gange vi kører igennem.
            { 
                if (varer[i].SpilId == Id)
                {
                    varer[i].SpilAntal += 1;
                    break;
                }
            }    

        }

        public void FjernSpil(int Id) // skal ændres i
        {
            for (int i = 0; i < varer.Count; i++)
            {
                if (varer[i].SpilId == Id)
                {
                    varer.RemoveAt(i);
                    break;
                }
            }

        }
        public List<Spil> VisKurv()
        {
            return varer;
        }

        public List<Spil> KurvTilDisplay() 
        {
            List<Spil> rettekurv = katalog.HentKatalogspil();  
            for (int i = 0; i < varer.Count; i++)
            {
                if (varer[i].SpilAntal == 0)
                {
                    rettekurv.Remove(rettekurv[i]);
                }
            }
                return rettekurv;
        }

        /// <summary>
        /// Constructer for vores Bestil klasse.
        /// 
        /// skrevet af Siwakon . 
        /// </summary>
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
