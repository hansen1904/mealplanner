namespace mealplanner.Application.FoodItems.Commands.CreateFoodItem
{
    public record CreateFoodItemResponse
    {
        public Guid Id { get; private set; }

        public CreateFoodItemResponse(Guid id)
        {
            Id = id;
        }
    }
}
