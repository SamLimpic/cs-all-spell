namespace cs_all_spell.Models
{
    public class Spell
    {
        public int Id { get; set; }

        public int ReagentId { get; set; }

        public bool Material { get; set; }

        public bool Verbal { get; set; }

        public bool Somatic { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}