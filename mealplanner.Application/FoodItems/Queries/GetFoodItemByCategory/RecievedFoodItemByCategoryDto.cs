using mealplanner.Application.FoodItems.Queries.GetFoodItemById;

namespace mealplanner.Application.FoodItems.Queries.GetFoodItemByCategory
{
    public record RecievedFoodItemByCategoryDto
    {
        public List<RecievedFoodItemDto> recievedFoodItemDtos { get; private set; }

        public RecievedFoodItemByCategoryDto(List<RecievedFoodItemDto> recievedFoodItemDtos)
        {
            this.recievedFoodItemDtos = recievedFoodItemDtos;
        }
    }
}
