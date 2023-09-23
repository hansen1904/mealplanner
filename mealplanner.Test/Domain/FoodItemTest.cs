using FluentAssertions;
using AutoFixture;
using mealplanner.Domain.Entities;
using mealplanner.Domain.Enums;

namespace mealplanner.Test.Domain
{
    public class FoodItemTest
    {
        private readonly Fixture _fixture;

        public FoodItemTest()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void CreateFoodItem_Successful()
        {
            //Arrange
            var name = _fixture.Create<string>();
            var brand = _fixture.Create<string>();
            var category = _fixture.Create<Category>();
            var caloriePr100 = _fixture.Create<double>();
            var ProteinPr100 = _fixture.Create<double>();
            var CarbohydratesPr100 = _fixture.Create<double>();
            var FatPr100 = _fixture.Create<double>();

            var model = FoodItem.Create(
                name,
                brand,
                category,   
                caloriePr100,
                ProteinPr100,
                CarbohydratesPr100,
                FatPr100,
                null,
                null,
                null
            );

            model.Should().NotBeNull();
        }

        [Fact]
        public void CreateFoodItem_ThrowException()
        {
            //Arrange
            var expectedErrorMessage = "Validation failed:\r\n -- 'Name' must not be empty.\r\n -- 'Brand' must not be empty.\r\n -- 'Protein Pr100' must not be empty.\r\n -- 'Carbohydrates Pr100' must not be empty.\r\n -- 'Fat Pr100' must not be empty.";

            var name = "";
            var brand = "";
            var category = Category.None;
            var caloriePr100 = -0;
            var ProteinPr100 = -0;
            var CarbohydratesPr100 = -0;
            var FatPr100 = -0;

            Action act = () => FoodItem.Create(
                name,
                brand,
                category,
                caloriePr100,
                ProteinPr100,
                CarbohydratesPr100,
                FatPr100,
                null,
                null,
                null
            );

            act.Should().Throw<ArgumentException>().WithMessage(expectedErrorMessage);
        }
    }
}
