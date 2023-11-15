namespace PokePortal.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public int Level { get; set; }
        public int TrainerId { get; set; }
        public bool IsShiny { get; set; }

    }
}
