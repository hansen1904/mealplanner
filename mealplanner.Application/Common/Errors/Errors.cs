
using System.Net;

namespace mealplanner.Application.Common.Errors
{
    public static partial class Errors
    {
        public static class FoodItem
        {
            public static Error NotFound => new(HttpStatusCode.NotFound, "FoodItem wasn't found");
        }
    }
}
