


namespace Shop.Web.Data
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Shop.Web.Data.Entities;

    public class ProductRepository : GenericRepository<Product>,IProductRepository
        {
        private readonly DataContext context;

        public ProductRepository(DataContext context): base(context)
        {
            this.context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return this.context.Products.Include(p=>p.user);
        }
    }
    
}
