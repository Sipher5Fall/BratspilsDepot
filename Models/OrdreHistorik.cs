using System.Text;

namespace BratspilsDepot.Models
{
    /*
    *  Forfatter: Mikkel
    *  
    */
    public class OrdreHistorik
    {
        private List<Ordre> ordreHistorik;

        public OrdreHistorik()
        {
            ordreHistorik = new List<Ordre>();
        }

        /*
         *  Encode Ordre laver en List<string> som indeholder
         *  en formateret kvittering for en given ordre. og
         *  returnere det.
         */
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

        /*
         *  ArkiverOrdre modtager et Ordre objekt, og bygger en
         *  lang string der indeholder alt data, separeret med ";"
         *  efter alle data specifikke til ordrern, lister den 
         *  List<Spil> Varer, som er varerne i ordre, disse
         *  er prefixed med "-" så vi kan splitte stringen for
         *  ordre data og spil data når vi skal læse fra filen igen.
         */
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
                //her tilføjer vi "-" foran hvert spil, hvor vi så bygger resten af spil stringen
                //igennem Spil objektets egen SpilTilString() metode.
                builder.Append("-"+spil.SpilTilString()+";");
            }

            string ArkivBuild = builder.ToString();
            TilArkiv.Add(ArkivBuild);

            FileIO.Log(TilArkiv, "/OrdreHistorik");
        }

        /*
         *  HentOrdreFraArkiv læser vores OrdreHistorik fil, og fylder en
         *  List<Ordre> med de data der er læst fra filen. Først splittes stringen
         *  ved "-" så vi får et string array med et index for ordre data,
         *  og så mange index mere som der er spil i ordren. Derefter splittes dette
         *  string[] ved ";" for at separare data. Vi ved at det første index i
         *  SplitForSpil altid vil være Ordre data ud fra konstruktionen af vores 
         *  ArkiverOrdre funktion, og derfor har vi en if sætning der checker om vi er på index 0 eller ej.
         */
        public List<Ordre> HentOrdreFraArkiv()
        {
            List<string> ArkivHistorik = FileIO.Read("/OrdreHistorik");

            List<Ordre> ordreHistorie = new List<Ordre>();
            for (int i = 0; i < ArkivHistorik.Count; i++)
            {
                Ordre ordre = new Ordre();

                //her laver vi SplitForSpil, som indeholder [OrdreData] [SpilData] [SpilData] ... osv.
                string[] SplitForSpil = ArkivHistorik[i].Split("-");
                for (int j = 0; j < SplitForSpil.Length; j++)
                {
                    //Her laver vi SplitForData, som splitter hver index i SplitForSpil, så vi nu kan bruge de data
                    string[] SplitForData = SplitForSpil[j].Split(";");

                    try
                    {
                        if (j == 0)
                        {
                            //Hvis vi er på index 0 er vi i OrdreData, og vi bruger disse til at udfylde den ordre vi
                            // initialiserede i det ydre for loop

                            ordre.OrdreId = Convert.ToInt32(SplitForData[0]);
                            ordre.KundeNavn = SplitForData[1];
                            ordre.KundeMail = SplitForData[2];
                            ordre.KundeTlf = Convert.ToInt32(SplitForData[3]);
                            ordre.Total = Convert.ToDouble(SplitForData[4]);
                            ordre.bestillingsdato = SplitForData[5];
                        }
                        else
                        {
                            //Hvis ikke vi er i index 0 er vi i SpilData, og det bruger vi til at initialisere et spil objekt,
                            //som kan tilføjes til ordrens Varer liste. Det er vigtigt at vide at vi første initialisere variabler
                            //med data, så vi kan bruge den originale constructor i Spil klassen.

                            string Navn = SplitForData[0];
                            int Id = Convert.ToInt32(SplitForData[1]);
                            double Pris = Convert.ToDouble(SplitForData[2]);
                            string Kategori = SplitForData[3];
                            string BilledStiC = SplitForData[4];
                            string BilledStiFuld = SplitForData[5];
                            int Antal = Convert.ToInt32(SplitForData[6]);

                            //Her initialiserer vi et Spil objekt med de data der er trukket ud af string[] SplitForData[j]
                            Spil spil = new Spil(Navn, Id, Pris, Kategori, BilledStiC, BilledStiFuld, Antal);

                            //og her tilføjer vi det til ordrens List<Spil> Varer.
                            ordre.Varer.Add(spil);
                        }
                    }
                    catch(Exception e)
                    {
                        FileIO.LogError(e.Message, "/ErrorLog");
                    }
                }

                //Endelig smider vi hele ordren ind i vores List<Ordre> og gentager indtil der ikke er flere ordrer læst fra filen.
                ordreHistorie.Add(ordre);
            }

            //til sidst returnere vi så List<Ordre> så den kan bruges til at se på websiden.
            return ordreHistorie;
        }
    }
}
