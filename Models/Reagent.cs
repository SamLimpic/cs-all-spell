using System.ComponentModel.DataAnnotations;

namespace cs_all_spell.Models
{
    public class Reagent
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}