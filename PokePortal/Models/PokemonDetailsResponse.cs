namespace PokePortal.Models
{
    public class PokemonDetailsResponse
    {
        public int PokemonId { get; set; }
        public string Species { get; set; }
        public List<string> Types { get; set; }
    }
}