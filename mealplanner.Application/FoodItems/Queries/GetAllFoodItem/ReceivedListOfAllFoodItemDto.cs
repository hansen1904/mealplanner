using mealplanner.Application.FoodItems.Queries.GetFoodItemById;
using mealplanner.Domain.Entities;
using System.Collections.ObjectModel;

namespace mealplanner.Application.FoodItems.Queries.GetAllFoodItem
{
    public sealed record ReceivedListOfAllFoodItemDto
    {
        public List<ReceivedFoodItemDto> InternalReceivedFoodItem;
        public ReadOnlyCollection<ReceivedFoodItemDto> ReceivedFoodItem
        {
            get
            {
                return new ReadOnlyCollection<ReceivedFoodItemDto>(InternalReceivedFoodItem);
            }
        }

        private ReceivedListOfAllFoodItemDto(List<ReceivedFoodItemDto> readOnlyListOfFoodItems)
        {
            this.InternalReceivedFoodItem = readOnlyListOfFoodItems;
        }

        public static ReceivedListOfAllFoodItemDto Create(List<FoodItem> listOfFoodItems)
        {
            var list = listOfFoodItems.Count == 0 ? new List<ReceivedFoodItemDto>() : listOfFoodItems.Select(x => new ReceivedFoodItemDto(x)).ToList();

            return new ReceivedListOfAllFoodItemDto(list);
        }
    }
}
