using System.ComponentModel.DataAnnotations;

namespace cs_all_spell.Models
{
    public class Spell
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string School { get; set; }

        [Required]
        public int Level { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int CastingTime { get; set; }

        [Required]
        public bool Material { get; set; }

        [Required]
        public bool Verbal { get; set; }

        [Required]
        public bool Somatic { get; set; }

        [Required]
        public bool Concentration { get; set; }

    }
}