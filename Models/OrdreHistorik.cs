namespace BratspilsDepot.Models
{
    public class OrdreHistorik
    {
        private List<Ordre> ordreHistorik;

        public OrdreHistorik()
        {
            ordreHistorik = new List<Ordre>();
        }

        public void TilføjOrdre(Ordre ordre)
        {
            ordreHistorik.Add(ordre)
        }
    }
}
