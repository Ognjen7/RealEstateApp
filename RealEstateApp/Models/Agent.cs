using System.ComponentModel.DataAnnotations;

namespace RealEstateApp.Models
{
    public class Agent
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Obavezna vrednost od maksimalno 50 karaktera")]
        public string ImeIPrezime { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Obavezna vrednost sa tacno 4 karaktera")]
        public string Licenca { get; set; }

        [Required]
        [Range(1950, 1995, ErrorMessage = "Obavezna vrednost u rasponu 1950 - 1995")]
        public int GodinaRodjenja { get; set; }

        [Required]
        [Range(0, 50, ErrorMessage = "Obavezna vrednost u rasponu 0 - 50")]
        public int BrojProdatihNekretnina { get; set; }
    }
}
