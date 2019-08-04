using System;
using System.Linq;
using System.Threading.Tasks;
using Shop.Web.Data.Entities;

namespace Shop.Web.Data
{
    public class SeedDb //Alimentacion de la BD
    {
        private readonly DataContext context;
        private Random random;

        public SeedDb(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Products.Any())
            {
                this.AddProduct("IPHONE X");
                this.AddProduct("Magic Mouse");
                this.AddProduct("IWATCH SERIES 4");
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name)
        {
            _ = this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(100),
                IsAvailable = true,
                Stock = this.random.Next(100)
            });
        }
    }



    }

