using Microsoft.AspNetCore.Mvc;
using PokePortal.Models;

namespace PokePortal.Controllers
{
    public class PokemonController : Controller
    {
        private List<Pokemon> pokemonStorage = new List<Pokemon>();

        // Action for displaying a list of all pokemon
        public IActionResult Index()
        {
            return View(pokemonStorage);
        }

        // Action for displaying details of a specific pokemon
        public IActionResult Details(int id)
        {
            Pokemon pokemon = pokemonStorage.FirstOrDefault(x => x.Id == id);
            if (pokemon == null)
            {
                return NotFound();
            }

            return View(pokemon);
        }

        // Action for displaying a form for adding a new pokemon
        public IActionResult Create()
        {
            return View();
        }

        // Action to handle form submission and adding a new pokemon
        [HttpPost]
        public IActionResult Create(Pokemon pokemon) 
        {
            if (ModelState.IsValid)
            {
                // Add new pokemon to storage system
                pokemon.Id = pokemonStorage.Count + 1;
                pokemonStorage.Add(pokemon);

                // Redirect to pokemon list after successful addition
                return RedirectToAction("Index");
            }

            // If model is not valid return to create form
            return View(pokemon);
        }

        // Action to display a form for editing an existing Pokemon
        public IActionResult Edit(int id)
        {
            Pokemon pokemon = pokemonStorage.FirstOrDefault(p => p.Id == id);
            if (pokemon == null)
            {
                return NotFound(); // Pokemon not found
            }

            return View(pokemon);
        }

        // Action to handle the form submission and update an existing Pokemon
        [HttpPost]
        public IActionResult Edit(int id, Pokemon updatedPokemon)
        {
            Pokemon pokemon = pokemonStorage.FirstOrDefault(p => p.Id == id);
            if (pokemon == null)
            {
                return NotFound(); // Pokemon not found
            }

            if (ModelState.IsValid)
            {
                // Update the existing Pokemon in your storage system
                pokemon.Name = updatedPokemon.Name;
                pokemon.Species = updatedPokemon.Species;
                pokemon.Type1 = updatedPokemon.Type1;
                pokemon.Type2 = updatedPokemon.Type2;
                pokemon.Level = updatedPokemon.Level;
                pokemon.TrainerId = updatedPokemon.TrainerId;
                pokemon.IsShiny = updatedPokemon.IsShiny;

                // Redirect to the Pokemon list after successful update
                return RedirectToAction("Index");
            }

            // If the model is not valid, return to the edit form with errors
            return View(updatedPokemon);
        }

        // Action to handle deleting a Pokemon
        public IActionResult Delete(int id)
        {
            Pokemon pokemon = pokemonStorage.FirstOrDefault(p => p.Id == id);
            if (pokemon == null)
            {
                return NotFound(); // Pokemon not found
            }

            return View(pokemon);
        }

        // Action to handle the deletion confirmation
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Pokemon pokemon = pokemonStorage.FirstOrDefault(p => p.Id == id);
            if (pokemon == null)
            {
                return NotFound(); // Pokemon not found
            }

            // Remove the Pokemon from your storage system
            pokemonStorage.Remove(pokemon);

            // Redirect to the Pokemon list after successful deletion
            return RedirectToAction("Index");
        }
    }
}
