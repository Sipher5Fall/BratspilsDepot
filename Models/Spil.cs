namespace BratspilsDepot.Models
{
    public class Spil
    {
        private string spilNavn;
        private int spilId;
        private double spilPris;
        private string spilKategori;
        private string spilBeskrivelse;

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

        public string SpilBeskrivelse
        {
            get { return spilBeskrivelse; }
            set { spilBeskrivelse = value; }
        }

        public string SpilInfo()
        {
            return $"Navn: {SpilNavn} Id: {SpilId} Pris: {SpilPris} Kategori: {SpilKategori}";
        }

    }
}
