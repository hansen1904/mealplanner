using mealplanner.Domain.Base;

namespace mealplanner.Domain.Entities
{
    public class MealPlan : AuditableEntity
    {
        public string Name { get; private set; }

        private MealPlan()
        {
        }

        public static MealPlan Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name is invalid");
            }

            return new MealPlan()
            {
                Name = name
            };
        }
    }
}
