using mealplanner.Application.Common.Errors;
using mealplanner.Application.FoodItems.Queries.GetFoodItemById;
using mealplanner.Domain.Entities;
using MediatR;

namespace mealplanner.Application.FoodItems.Queries.GetAllFoodItem
{
    public class GetAllFoodItemQuery : IRequest<RecievedListOfAllFoodItemDto>
    {
    }

    public class GetAllFoodProductQueryHandler : IRequestHandler<GetAllFoodItemQuery, RecievedListOfAllFoodItemDto>
    {
        public GetAllFoodProductQueryHandler()
        {

        }

        public Task<RecievedListOfAllFoodItemDto> Handle(GetAllFoodItemQuery request, CancellationToken cancellationToken)
        {
            throw Errors.FoodItem.NotFound;
        }

        private static RecievedListOfAllFoodItemDto MapToDto(List<FoodItem> listOfFoodItems)
        {
            if (listOfFoodItems.Count == 0)
            {
                return new RecievedListOfAllFoodItemDto(new List<RecievedFoodItemDto>());
            }

            var listOfFoodProductsDto = listOfFoodItems.Select(x => new RecievedFoodItemDto(x)).ToList();
            
            return new RecievedListOfAllFoodItemDto(listOfFoodProductsDto);
        }
    }
}
