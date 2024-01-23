using mealplanner.Domain.Entities;
using mealplanner.Domain.Enums;

namespace mealplanner.Application.Repository
{
    public interface IFoodItemRepo
    {
        public FoodItem GetById(Guid Id);
        public List<FoodItem> GetAllByCategory(FoodCategory Category, int Offset, int Limit);
        public List<FoodItem> GetAll(int Offset, int Limit);
        public void Create(FoodItem entity);
        public void Update(FoodItem entity);
        public void Delete(Guid id);
    }
}
