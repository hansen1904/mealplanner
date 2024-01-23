using mealplanner.Application.Repository;
using MediatR;

namespace mealplanner.Application.FoodItems.Queries.GetAllFoodItem
{
    public sealed record GetAllFoodItemQuery : IRequest<ReceivedListOfAllFoodItemDto>
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
    }

    public sealed class GetAllFoodProductQueryHandler : IRequestHandler<GetAllFoodItemQuery, ReceivedListOfAllFoodItemDto>
    {
        private IUnitOfWork _unitOfWork;

        public GetAllFoodProductQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ReceivedListOfAllFoodItemDto> Handle(GetAllFoodItemQuery request, CancellationToken cancellationToken)
        {
            var list = _unitOfWork.FoodItemRepo().GetAll(request.Offset, request.Limit);

            var response = ReceivedListOfAllFoodItemDto.Create(list);

            return Task.FromResult(response);
        }
    }
}
