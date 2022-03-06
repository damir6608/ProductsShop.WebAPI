using Microsoft.EntityFrameworkCore;
using ProductsShop.WebAPI.Abstraction.Interfaces;

namespace ProductsShop.WebAPI.Abstraction.DataContext
{
    public class BaseDataContext<TModel> : DbContext
        where TModel : class, IModel
    {
        public DbSet<TModel> Models { get; set; }

        public BaseDataContext(DbContextOptions<BaseDataContext<TModel>> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
