namespace BratspilsDepot.Models
{
    public class OrdreHistorik
    {
        private List<Ordre> ordreHistorik;

        public OrdreHistorik()
        {
            ordreHistorik = new List<Ordre>();
        }

        public void LogOrdre(Ordre ordre)
        {
            ordreHistorik.Add(ordre);
        }

        public List<string> EncodeOrdre(Ordre ordre)
        {
            List<string> encoded = new List<string>();

            encoded.Add($"*** ORDRENUMMER: {ordre.OrdreId} *** ");
            encoded.Add("-------------------------------------");
            encoded.Add(ordre.dato());
            encoded.Add("-------------------------------------");
            encoded.Add($"Køber: {ordre.KundeNavn}");
            encoded.Add($"Tlf: {ordre.KundeTlf}");
            encoded.Add($"e-mail: {ordre.KundeMail}");
            encoded.Add("-------------------------------------");
            foreach (string[] spil in ordre.Varer)
            {
                encoded.Add($"{spil[0]}              {spil[2]}");
            }
            encoded.Add($"Samlet pris: {ordre.Total}");

            return encoded;
        }

        public void ArkiverOrdre(Ordre ordre)
        {
            List<string> TilArkiv = new List<string>();

            TilArkiv = EncodeOrdre(ordre);
            FileIO.Log(TilArkiv, "/OrdreHistorik");
        }
    }
}
