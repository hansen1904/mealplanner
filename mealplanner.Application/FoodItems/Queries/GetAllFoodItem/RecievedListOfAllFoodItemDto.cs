using mealplanner.Application.FoodItems.Queries.GetFoodItemById;

namespace mealplanner.Application.FoodItems.Queries.GetAllFoodItem
{
    public record RecievedListOfAllFoodItemDto
    {
        public List<RecievedFoodItemDto> recievedFoodProductDtos { get; private set; }

        public RecievedListOfAllFoodItemDto(List<RecievedFoodItemDto> recievedFoodProductDtos)
        {
            this.recievedFoodProductDtos = recievedFoodProductDtos;
        }
    }
}
