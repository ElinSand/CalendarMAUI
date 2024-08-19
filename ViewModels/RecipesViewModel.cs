using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Windows.Input;

namespace CalendarApp.ViewModels
{


    public class RecipesViewModel : BaseViewModel
    {
        private readonly RecipeService _recipeService;
        private ObservableCollection<Recipe> _recipes;
        private string _searchQuery;

        public ObservableCollection<Recipe> Recipes
        {
            get => _recipes;
            set
            {
                _recipes = value;
                OnPropertyChanged();
            }
        }

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
            }
        }

        public ICommand FetchRecipesCommand { get; }

        public RecipesViewModel()
        {
            _recipeService = new RecipeService();
            Recipes = new ObservableCollection<Recipe>();
            FetchRecipesCommand = new Command(async () => await FetchRecipes());
        }

        private async Task FetchRecipes()
        {
            try
            {
                var recipes = await _recipeService.GetRecipesAsync(SearchQuery);
                Recipes.Clear();
                foreach (var recipe in recipes)
                {
                    Recipes.Add(recipe);
                }
            }
            catch (Exception ex)
            {
                // Hantera fel här (logga eller visa ett meddelande)
                Console.WriteLine($"Error fetching recipes: {ex.Message}");
            }
        }
    }

    public class Recipe
    {
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public string Servings { get; set; }
        public string Instructions { get; set; }
    }

    public class RecipeService
    {
        private readonly HttpClient _httpClient;

        public RecipeService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Recipe[]> GetRecipesAsync(string query)
        {
            string apiKey = "R4RBjMCTc4Pel6a2MK0qTw==pqYD4PguPvZvghSW"; // Sätt in din faktiska API-nyckel här
            string requestUrl = $"https://api.api-ninjas.com/v1/recipe?query={query}";

            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", apiKey);

            var response = await _httpClient.GetStringAsync(requestUrl);
            var recipes = JsonConvert.DeserializeObject<Recipe[]>(response);
            return recipes;
        }
    }

}
