using mealplanner.Application.Recipes.Queries.GetRecipeById;
using mealplanner.Domain.Entities;
using System.Collections.ObjectModel;

namespace mealplanner.Application.Recipes.Queries.GetRecipeByType
{
    public class ReceivedRecipeByTypeDto
    {
        private List<ReceivedRecipeDto> InternalReceivedRecipe;
        public ReadOnlyCollection<ReceivedRecipeDto> ReceivedRecipe
        {
            get
            {
                return new ReadOnlyCollection<ReceivedRecipeDto>(InternalReceivedRecipe);
            }
        }

        private ReceivedRecipeByTypeDto(List<ReceivedRecipeDto> receivedRecipeDtos)
        {
            this.InternalReceivedRecipe = receivedRecipeDtos;
        }

        public static ReceivedRecipeByTypeDto Create(List<Recipe> listOfRecipe)
        {
            var list = listOfRecipe.Count == 0 ? new List<ReceivedRecipeDto>() : listOfRecipe.Select(x => new ReceivedRecipeDto(x)).ToList();

            return new ReceivedRecipeByTypeDto(list);
        }
    }

}
