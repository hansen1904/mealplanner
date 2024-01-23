using mealplanner.Application.Repository;
using mealplanner.Domain.Entities;
using mealplanner.Domain.Enums;
using mealplanner.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace mealplanner.Infrastructure.Persistence
{
    public class RecipeRepo : IRecipeRepo
    {
        private readonly ApplicationDbContext context;

        public RecipeRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(Recipe entity)
        {
            context.Recipes.Add(entity);
        }

        public void Delete(Guid id)
        {
            var entity = context.Recipes.Find(id);
            context.Recipes.Remove(entity);
        }

        public List<Recipe> GetAll(int Offset, int Limit)
        {
            return context.Recipes
                .Include(fa => fa.FoodAmount)
                .ThenInclude(fa => fa.FoodItem)
                .OrderBy(e => e.Id)
                .Skip(Offset)
                .Take(Limit).ToList();
        }

        public List<Recipe> GetAllByType(RecipeType Type, int Offset, int Limit)
        {
            return context.Recipes.Where(x => x.Type == Type).Skip(Offset).Take(Limit).ToList();
        }

        public Recipe GetById(Guid Id)
        {
            return context.Recipes.Find(Id);
        }

        public void Update(Recipe entity)
        {
            context.Recipes.Update(entity);
        }
    }
}
