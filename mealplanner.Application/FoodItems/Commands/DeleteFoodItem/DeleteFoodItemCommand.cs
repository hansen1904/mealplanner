using MediatR;

namespace mealplanner.Application.FoodItems.Commands.DeleteFoodItem
{
    public class DeleteFoodItemCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteFoodItemCommandEventHandler : IRequestHandler<DeleteFoodItemCommand>
    {
        public DeleteFoodItemCommandEventHandler()
        {

        }

        public Task Handle(DeleteFoodItemCommand request, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
