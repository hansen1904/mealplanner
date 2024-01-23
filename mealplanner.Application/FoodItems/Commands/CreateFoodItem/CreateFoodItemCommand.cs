using mealplanner.Application.Repository;
using mealplanner.Domain.Entities;
using mealplanner.Domain.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace mealplanner.Application.FoodItems.Commands.CreateFoodItem
{
    public sealed record CreateFoodItemCommand : IRequest
    {
        [Required]
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Category { get; set; }
        public double CaloriePr100 { get; set; }
        public double ProteinPr100 { get; set; }
        public double CarbohydratesPr100 { get; set; }
        public double FatPr100 { get; set; }
        public double? FiberPr100 { get; set; }
        public double? SugarPr100 { get; set; }
        public double? SaltPr100 { get; set; }
    }

    public sealed class CreateFoodItemCommandEventHandler : IRequestHandler<CreateFoodItemCommand>
    {
        private IUnitOfWork _unitOfWork;

        public CreateFoodItemCommandEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(CreateFoodItemCommand request, CancellationToken cancellationToken)
        {
            FoodCategory category = FoodCategory.None;
            try
            {
                category = (FoodCategory)request.Category;
            }
            catch (Exception)
            {

                throw new Exception("Couldn't find given food category");
            }
            

            var model = FoodItem.Create(
                request.Name.ToLowerInvariant(),
                request.Brand.ToLowerInvariant(),
                category,
                request.CaloriePr100,
                request.ProteinPr100,
                request.CarbohydratesPr100,
                request.FatPr100,
                request.FiberPr100,
                request.SugarPr100,
                request.SaltPr100
                );

            _unitOfWork.FoodItemRepo().Create(model);
            _unitOfWork.Save();

            return Task.CompletedTask;
        }
    }
}
