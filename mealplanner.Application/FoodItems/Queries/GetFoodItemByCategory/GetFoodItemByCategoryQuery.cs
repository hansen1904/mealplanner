using mealplanner.Application.Repository;
using mealplanner.Domain.Enums;
using MediatR;

namespace mealplanner.Application.FoodItems.Queries.GetFoodItemByCategory
{
    public sealed record GetFoodItemByCategoryQuery : IRequest<ReceivedFoodItemByCategoryDto>
    {
        public FoodCategory Category { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
    }

    public sealed class GetFoodProductByCategoryQueryHandler : IRequestHandler<GetFoodItemByCategoryQuery, ReceivedFoodItemByCategoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFoodProductByCategoryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ReceivedFoodItemByCategoryDto> Handle(GetFoodItemByCategoryQuery request, CancellationToken cancellationToken)
        {
            var list = _unitOfWork.FoodItemRepo().GetAllByCategory(request.Category, request.Offset, request.Limit);

            var response = ReceivedFoodItemByCategoryDto.Create(list);

            return Task.FromResult(response);
        }
    }
}
