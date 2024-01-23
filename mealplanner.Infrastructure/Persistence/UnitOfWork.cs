using mealplanner.Application.Repository;

namespace mealplanner.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDbContext _context;
        private IFoodItemRepo _foodItemRepo;
        private IRecipeRepo _recipeRepo;

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IFoodItemRepo FoodItemRepo()
        {
            if (_foodItemRepo == null)
            {
                _foodItemRepo = new FoodItemRepo(_context);
            }
            return _foodItemRepo;
        }

        public IRecipeRepo RecipeRepo()
        {
            if (_recipeRepo == null)
            {
                _recipeRepo = new RecipeRepo(_context);
            }
            return _recipeRepo;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
