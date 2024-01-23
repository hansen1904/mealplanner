using mealplanner.Application.Repository;
using mealplanner.Domain.Entities;
using mealplanner.Domain.Enums;

namespace mealplanner.Infrastructure.Persistence
{
    public sealed class FoodItemRepo : IFoodItemRepo
    {
        private readonly ApplicationDbContext context;

        public FoodItemRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(FoodItem entity)
        {
            context.FoodItems.Add(entity);
        }

        public void Delete(Guid id)
        {
            var entity = context.FoodItems.Find(id);
            context.FoodItems.Remove(entity);
        }

        public List<FoodItem> GetAll(int Offset, int Limit)
        {
            return context.FoodItems.OrderBy(e => e.Id).Skip(Offset).Take(Limit).ToList();
        }

        public List<FoodItem> GetAllByCategory(FoodCategory Category, int Offset, int Limit)
        {
            return context.FoodItems.Where(x => x.Category == Category).Skip(Offset).Take(Limit).ToList();
        }

        public FoodItem GetById(Guid Id)
        {
            return context.FoodItems.Find(Id);
        }

        public void Update(FoodItem entity)
        {
            context.FoodItems.Update(entity);
        }
    }
}
