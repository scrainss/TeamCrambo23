using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace PokePortal.Models
{
    public class Pokemon
    {
        // Internal Id used for sorts
        public int Id { get; set; }

        [Required(ErrorMessage = "Pokemon Id is required.")]
        public int PokemonId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "Species is required.")]
        public string Species { get; set; }

        [Required(ErrorMessage = "Type 1 is required.")]
        public string Type1 { get; set; }

        public string? Type2 { get; set; }

        [Required(ErrorMessage = "Level is required.")]
        [Range(1, 100, ErrorMessage = "Level must be between 1 and 100.")]
        public int Level { get; set; }

        //public List<int> AvailableLevels { get; } = Enumerable.Range(1, 99).ToList();

        [Required(ErrorMessage = "Original Trainer ID is required.")]
        public int TrainerId { get; set; }

        public bool IsShiny { get; set; }


    }
}
