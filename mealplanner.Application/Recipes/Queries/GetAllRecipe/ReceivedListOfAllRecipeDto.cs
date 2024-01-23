using mealplanner.Application.Recipes.Queries.GetRecipeById;
using mealplanner.Domain.Entities;
using System.Collections.ObjectModel;

namespace mealplanner.Application.Recipes.Queries.GetAllRecipe
{
    public class ReceivedListOfAllRecipeDto
    {
        public List<ReceivedRecipeDto> InternalReceivedRecipe;
        public ReadOnlyCollection<ReceivedRecipeDto> ReceivedRecipe
        {
            get
            {
                return new ReadOnlyCollection<ReceivedRecipeDto>(InternalReceivedRecipe);
            }
        }

        private ReceivedListOfAllRecipeDto(List<ReceivedRecipeDto> readOnlyListOfRecipe)
        {
            this.InternalReceivedRecipe = readOnlyListOfRecipe;
        }

        public static ReceivedListOfAllRecipeDto Create(List<Recipe> listOfRecipe)
        {
            var list = listOfRecipe.Count == 0 ? new List<ReceivedRecipeDto>() : listOfRecipe.Select(x => new ReceivedRecipeDto(x)).ToList();

            return new ReceivedListOfAllRecipeDto(list);
        }
    }
}
