using System.Text;

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
            foreach (Spil spil in ordre.Varer)
            {
                encoded.Add($"{spil.SpilNavn}              {spil.SpilPris}");
            }
            encoded.Add($"Samlet pris: {ordre.Total}");

            return encoded;
        }

        public void ArkiverOrdre(Ordre ordre)
        {
            List<string> TilArkiv = new List<string>();
            StringBuilder builder = new StringBuilder();

            builder.Append(ordre.OrdreId+";");
            builder.Append(ordre.KundeNavn+";");
            builder.Append(ordre.KundeMail+";");
            builder.Append(ordre.KundeTlf + ";");
            builder.Append(ordre.Total + ";");
            builder.Append(ordre.bestillingsdato + ";");
            foreach (Spil spil in ordre.Varer)
            {
                builder.Append("-"+spil.SpilTilString()+";");
            }

            string ArkivBuild = builder.ToString();
            TilArkiv.Add(ArkivBuild);

            FileIO.Log(TilArkiv, "/OrdreHistorik");
        }

        public List<Ordre> HentOrdreFraArkiv()
        {
            List<string> ArkivHistorik = FileIO.Read("/OrdreHistorik");

            List<Ordre> ordreHistorie = new List<Ordre>();
            for (int i = 0; i < ArkivHistorik.Count; i++)
            {
                Ordre ordre = new Ordre();

                string[] SplitForSpil = ArkivHistorik[i].Split("-");
                for (int j = 0; j < SplitForSpil.Length; j++)
                {
                    string[] SplitForData = SplitForSpil[j].Split(";");

                    if(j==0)
                    {
                        ordre.OrdreId = Convert.ToInt32(SplitForData[0]);
                        ordre.KundeNavn = SplitForData[1];
                        ordre.KundeMail = SplitForData[2];
                        ordre.KundeTlf = Convert.ToInt32(SplitForData[3]);
                        ordre.Total = Convert.ToDouble(SplitForData[4]);
                        ordre.bestillingsdato = SplitForData[5];
                    }
                    else
                    {
                        string Navn = SplitForData[0];
                        int Id = Convert.ToInt32(SplitForData[1]);
                        double Pris = Convert.ToDouble(SplitForData[2]);
                        string Kategori = SplitForData[3];
                        string BilledStiC = SplitForData[4];
                        string BilledStiFuld = SplitForData[5];
                        int Antal = Convert.ToInt32(SplitForData[6]);

                        Spil spil = new Spil(Navn, Id, Pris, Kategori, BilledStiC, BilledStiFuld, Antal);

                        ordre.Varer.Add(spil);
                    }
                }

                ordreHistorie.Add(ordre);
            }



            return ordreHistorie;
        }
    }
}
