using BratspilsDepot.Models;

namespace BratspilsDepot.Helpers
{
    public static class BeregnetPris
    {

        public static double Beregnpris(List<Spil> varer)
        {
            double sum = 0;
            foreach (Spil spil in varer)
            {
                sum += spil.SpilPris * spil.SpilAntal;
                //sum = sum + pris;
            }

            return sum;
        }
    }
}
