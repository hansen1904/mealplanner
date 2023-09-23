using mealplanner.Domain.Entities;
using MediatR;

namespace mealplanner.Application.FoodItems.Queries.GetFoodItemById
{
    public class GetFoodItemByNameQuery : IRequest<RecievedFoodItemDto>
    {
        public Guid id { get; set; }
    }

    public class GetFoodItemByNameQueryHandler : IRequestHandler<GetFoodItemByNameQuery, RecievedFoodItemDto>
    {
        public GetFoodItemByNameQueryHandler()
        {

        }

        public Task<RecievedFoodItemDto> Handle(GetFoodItemByNameQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private static RecievedFoodItemDto? MapToDto(FoodItem? recievedFoodItem)
        {
            if (recievedFoodItem is null)
            {
                return null;
            }

            var dto = new RecievedFoodItemDto(recievedFoodItem);

            return dto;
        }
    }
}
