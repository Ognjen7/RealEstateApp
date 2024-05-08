using System.ComponentModel.DataAnnotations;

namespace RealEstateApp.Models
{
    public class Nekretnina
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Obavezna vrednost od maksimalno 40 karaktera")]
        public string Mesto { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "Obavezna vrednost od maksimalno 5 karaktera")]
        public string AgencijskaOznaka { get; set; }

        [Required]
        [Range(1900, 2019, ErrorMessage = "Obavezna vrednost u rasponu 1900 - 2019")]
        public int GodinaIzgradnje { get; set; }

        [Required]
        [Range(2, 999, ErrorMessage = "Obavezna vrednost veca od 2")]
        public double Kvadratura { get; set; }

        [Required]
        [Range(1, 100000, ErrorMessage = "Obavezna vrednost veca od 1 i manja od 100000")]
        public double Cena { get; set; }
        public int AgentId { get; set; }
        public Agent Agent { get; set; }
    }
}
