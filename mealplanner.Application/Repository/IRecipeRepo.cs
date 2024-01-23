using mealplanner.Domain.Entities;
using mealplanner.Domain.Enums;

namespace mealplanner.Application.Repository
{
    public interface IRecipeRepo
    {
        public Recipe GetById(Guid Id);
        public List<Recipe> GetAllByType(RecipeType Type, int Offset, int Limit);
        public List<Recipe> GetAll(int Offset, int Limit);
        public void Create(Recipe entity);
        public void Update(Recipe entity);
        public void Delete(Guid id);
    }
}
