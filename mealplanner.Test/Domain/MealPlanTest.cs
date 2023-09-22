using AutoFixture;
using FluentAssertions;
using mealplanner.Domain.Entities;

namespace mealplanner.Test.Domain
{
    public class MealPlanTest
    {
        private readonly Fixture _fixture;

        public MealPlanTest()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void CreateMealPlan_Successful()
        {
            //Arrange
            var name = _fixture.Create<string>();

            var model = MealPlan.Create(name);

            model.Should().NotBeNull();
        }

        [Fact]
        public void CreateMealPlan_ThrowException()
        {
            //Arrange
            var name = "";

            Action act = () => MealPlan.Create(name);

            act.Should().Throw<ArgumentException>().WithMessage("Name is invalid");
        }
    }
}
