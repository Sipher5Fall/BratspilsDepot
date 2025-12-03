namespace BratspilsDepot.Models
{
    public class Spil
    {
        private string spilNavn;
        private int spilId;
        private double spilPris;
        private string spilKategori;
        private string spilBilledStiC;
        private string spilBilledStiFuld;
        private int spilantal;

        public string SpilNavn
        {
            get { return spilNavn; }
            set { spilNavn = value; }
        }

        public int SpilId 
        { 
            get { return spilId; } 
            set { spilId = value; }
        }

        public double SpilPris
        { 
            get { return spilPris; }
            set { spilPris = value; }
        }
        public string SpilKategori
        {
            get { return spilKategori; }
            set { spilKategori = value; }
        }

        public string SpilBilledStiC
        {
            get { return spilBilledStiC; }
            set { spilBilledStiC = value; }
        }
        public string SpilBilledStiFuld
        {
            get { return spilBilledStiFuld; }
            set { spilBilledStiFuld = value; }
        }
        public int SpilAntal
        {
            get { return spilantal; }
            set { spilantal = value; }
        }

        public Spil(string navn, int id, double pris, string kategori, string billedstiC, string billedstifuld)
        {
            SpilNavn = navn;
            SpilId = id;
            SpilPris = pris;
            SpilKategori = kategori;
            SpilBilledStiC = billedstiC;
            SpilBilledStiFuld = billedstifuld;
            SpilAntal = 0;
        }

        //Overload for at konstruerer Spil for OrdreHistorik
        public Spil(string navn, int id, double pris, string kategori, string billedstiC, string billedstifuld, int antal)
        {
            SpilNavn = navn;
            SpilId = id;
            SpilPris = pris;
            SpilKategori = kategori;
            SpilBilledStiC = billedstiC;
            SpilBilledStiFuld = billedstifuld;
            SpilAntal = antal;
        }

        public string SpilInfo()
        {
            return $"Navn: {SpilNavn} Id: {SpilId} Pris: {SpilPris} Kategori: {SpilKategori}";
        }

        public string SpilTilString()
        {
            return $"{SpilNavn};{SpilId};{SpilPris};{SpilKategori};{SpilBilledStiC};{SpilBilledStiFuld};{SpilAntal}";
        }

    }
}
