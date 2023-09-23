using mealplanner.Application.FoodItems.Queries.GetFoodItemById;
using mealplanner.Domain.Entities;
using mealplanner.Domain.Enums;
using MediatR;

namespace mealplanner.Application.FoodItems.Queries.GetFoodItemByCategory
{
    public class GetFoodItemByCategoryQuery : IRequest<RecievedFoodItemByCategoryDto>
    {
        public Category Category { get; set; }
    }

    public class GetFoodProductByCategoryQueryHandler : IRequestHandler<GetFoodItemByCategoryQuery, RecievedFoodItemByCategoryDto>
    {
        public GetFoodProductByCategoryQueryHandler()
        {

        }

        public Task<RecievedFoodItemByCategoryDto> Handle(GetFoodItemByCategoryQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private static RecievedFoodItemByCategoryDto MapToDto(List<FoodItem> listOfFoodItems)
        {
            if (listOfFoodItems.Count == 0)
            {
                return new RecievedFoodItemByCategoryDto(new List<RecievedFoodItemDto>());
            }

            var listOfFoodProductsDto = listOfFoodItems.Select(x => new RecievedFoodItemDto(x)).ToList();

            return new RecievedFoodItemByCategoryDto(listOfFoodProductsDto);
        }
    }
}
