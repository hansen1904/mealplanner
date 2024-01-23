
namespace mealplanner.Application.Repository
{
    public interface IUnitOfWork
    {
        public IFoodItemRepo FoodItemRepo();
        public IRecipeRepo RecipeRepo();
        public void Save();
    }
}
