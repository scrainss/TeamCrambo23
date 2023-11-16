using PokePortal.Models;

namespace PokePortal.Services
{
    public class PokeApiService
    {
        private readonly HttpClient httpClient;
        private const string BaseUrl = "https://pokeapi.co/api/v2/";

        public PokeApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.httpClient.BaseAddress = new Uri(BaseUrl);
        }

        // NuGet - Microsoft.AspNet.WebApiClient for ReadAsAsync<dynamic> to work.
        // Using dynamic reduces compile-time safety, but is easier than creating a JSON model for the entire PokeAPI Response
        public async Task<PokemonSpriteResponse> GetPokemonSprites(string pokemonName)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"pokemon/{pokemonName.ToLower()}");
            response.EnsureSuccessStatusCode();

            var pokemonApiResponse = await response.Content.ReadAsAsync<dynamic>();

            // Map the relevant information to the simplified model
            var spriteResponse = new PokemonSpriteResponse
            {
                Normal = pokemonApiResponse.sprites.front_default,
                Shiny = pokemonApiResponse.sprites.front_shiny
            };

            return spriteResponse;
        }

        public async Task<PokemonDetailsResponse> GetPokemonDetailsAsync(int pokemonId)
        {
            try
            {
                var response = await httpClient.GetAsync($"pokemon/{pokemonId}/");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    // You can use Newtonsoft.Json.JsonConvert or System.Text.Json.JsonSerializer for deserialization
                    var pokemonDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<PokemonDetailsResponse>(content);

                    return pokemonDetails;
                }
                else
                {
                    // Handle the error, perhaps by logging or throwing an exception
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., network issues)
                return null;
            }
        }
    }
}
