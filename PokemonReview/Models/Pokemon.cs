using System.ComponentModel.DataAnnotations;

namespace PokemonReview.Models
{
    public class Pokemon
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Review {get; set; }
        public string Reviewer { get; set; }
       

    }
}
