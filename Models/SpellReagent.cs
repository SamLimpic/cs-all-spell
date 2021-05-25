using System.ComponentModel.DataAnnotations;

namespace cs_all_spell.Models
{
    public class SpellReagentDTO
    {
        public int Id { get; set; }

        [Required]
        public int SpellId { get; set; }

        [Required]
        public int ReagentId { get; set; }
    }



    public class SpellReagentView : Reagent
    {
        public int SpellReagentId { get; set; }

        public int SpellId { get; set; }

        public int ReagentId { get; set; }

        public string SpellName { get; set; }
    }
}