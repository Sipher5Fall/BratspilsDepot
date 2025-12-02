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
            
        }
        public void LægIKurv(int Id)
        {
            List<Spil> localKatalog = katalog.HentKatalogspil();
            for (int i = 0; i < localKatalog.Count; i++) 
            { 
                if (localKatalog[i].SpilId == Id)
                {
                    varer.Add (localKatalog[i]);
                    break;
                }
            }

        }

        public void FjernSpil(int Id)
        {
            for (int i = 0; i < varer.Count; i++)
            {
                if (varer[i].SpilId == Id)
                {
                    varer[i].SpilAntal--;
                    if (varer[i].SpilAntal == 0)
                    {
                        varer.RemoveAt(i);
                    }
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
            List<Spil> localVarer = varer.ToList();
            List<Spil> localList=new List<Spil>();
            for (int j = 0; j < localVarer.Count; j++)
            {
                Spil spil = localVarer[0];
                localVarer.RemoveAt(0);
                if(spil.SpilAntal < 1)
                { 
                    spil.SpilAntal = 1; 
                }

                localList.Add(spil);
                j = -1;
                for (int i = 0; i < localVarer.Count; i++)
                {
                    if (localVarer[i].SpilId == spil.SpilId)
                    {
                        spil.SpilAntal++;
                        localVarer.RemoveAt(i);
                    }
                }
            }
            varer = localList.ToList();
            return localList;
        }

        public void NukeKurv()
        {
            varer.Clear();
        }

        public double beregnetpris()
        {

            double sum = 0;
            foreach (Spil spil in varer)
            {
                sum += spil.SpilPris*spil.SpilAntal;
                //sum = sum + pris;
            }
            return sum;
        }

        /// <summary>
        /// Constructer for vores Bestil klasse.
        /// 
        /// skrevet af Siwakon . 
        /// </summary>
        public void Bestil(Ordre ordre)
        {
            //ordre.kundeinfo();
            ordre.Varer = varer;
            ordre.Total = ordre.beregnetpris();
            ordre.bekræftOrdre();
            //NukeKurv();
        }
        
    }
}
