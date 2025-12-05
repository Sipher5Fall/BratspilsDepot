namespace BratspilsDepot.Models
{
    /*
    *  Forfatter: Siw
    *  
    */
    public class Medarbejder
    {
        private string brugerNavn;
        private string password;

        public string Brugernavn { get; }
        public string Password { get; }

        public Medarbejder()
        {
            HentAdminData();
        }

        public void HentAdminData()
        {
           List<string>Brugerdata = FileIO.Read("/AdminData");
            string[] splittetbruger = Brugerdata[0].Split(';');
            brugerNavn = splittetbruger[0];
            password = splittetbruger[1];
        }
    }


}
