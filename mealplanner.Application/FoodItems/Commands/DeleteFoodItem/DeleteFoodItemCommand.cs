using mealplanner.Application.Repository;
using MediatR;

namespace mealplanner.Application.FoodItems.Commands.DeleteFoodItem
{
    public sealed record DeleteFoodItemCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public sealed class DeleteFoodItemCommandEventHandler : IRequestHandler<DeleteFoodItemCommand>
    {
        private IUnitOfWork _unitOfWork;

        public DeleteFoodItemCommandEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteFoodItemCommand request, CancellationToken cancellationToken)
        {

            _unitOfWork.FoodItemRepo().Delete(request.Id);
            _unitOfWork.Save();

            return Task.CompletedTask;
        }
    }
}
