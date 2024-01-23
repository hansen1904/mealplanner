using mealplanner.Application.FoodItems.Queries.GetFoodItemById;
using mealplanner.Domain.Entities;
using System.Collections.ObjectModel;

namespace mealplanner.Application.FoodItems.Queries.GetFoodItemByCategory
{
    public sealed record ReceivedFoodItemByCategoryDto
    {
        private List<ReceivedFoodItemDto> InternalReceivedFoodItem;
        public ReadOnlyCollection<ReceivedFoodItemDto> ReceivedFoodItem
        {
            get
            {
                return new ReadOnlyCollection<ReceivedFoodItemDto>(InternalReceivedFoodItem);
            }
        }

        private ReceivedFoodItemByCategoryDto(List<ReceivedFoodItemDto> receivedFoodItemDtos)
        {
            this.InternalReceivedFoodItem = receivedFoodItemDtos;
        }

        public static ReceivedFoodItemByCategoryDto Create(List<FoodItem> listOfFoodItems)
        {
            var list = listOfFoodItems.Count == 0 ? new List<ReceivedFoodItemDto>() : listOfFoodItems.Select(x => new ReceivedFoodItemDto(x)).ToList();

            return new ReceivedFoodItemByCategoryDto(list);
        }
    }
}
