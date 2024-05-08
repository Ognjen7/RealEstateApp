namespace RealEstateApp.Models
{
    public class NekretninaDTO
    {
        public int Id { get; set; }
        public string Mesto { get; set; }
        public string AgencijskaOznaka { get; set; }
        public int GodinaIzgradnje { get; set; }
        public double Kvadratura { get; set; }
        public double Cena { get; set; }
        public int AgentId { get; set; }
        public string AgentImeIPrezime { get; set; }
    }
}
