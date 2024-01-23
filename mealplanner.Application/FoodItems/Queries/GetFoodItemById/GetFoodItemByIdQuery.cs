using mealplanner.Application.Repository;
using MediatR;

namespace mealplanner.Application.FoodItems.Queries.GetFoodItemById
{
    public sealed record GetFoodItemByIdQuery : IRequest<ReceivedFoodItemDto?>
    {
        public Guid id { get; set; }
    }

    public sealed class GetFoodItemByNameQueryHandler : IRequestHandler<GetFoodItemByIdQuery, ReceivedFoodItemDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFoodItemByNameQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ReceivedFoodItemDto?> Handle(GetFoodItemByIdQuery request, CancellationToken cancellationToken)
        {
            var model = _unitOfWork.FoodItemRepo().GetById(request.id);

            ReceivedFoodItemDto response = null;

            if (model != null)
            {
                response = new ReceivedFoodItemDto(model);
            }

            return Task.FromResult(response);
        }
    }
}
