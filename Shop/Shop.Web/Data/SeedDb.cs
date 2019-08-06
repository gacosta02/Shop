using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Shop.Web.Data.Entities;

namespace Shop.Web.Data
{
    public class SeedDb //Alimentacion de la BD
    {
        private readonly DataContext context;
        private readonly UserManager<User> userManager;
        private Random random;

        public SeedDb(DataContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userManager.FindByEmailAsync("gacosta.com.do@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Gabriel",
                    LastName = "Acosta",
                    Email = "gacosta.com.do@gmail.com",
                    UserName = "gacosta.com.do@gmail.com"
                };

                var result = await this.userManager.CreateAsync(user, "123456");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

      

            if (!this.context.Products.Any())
            {
                this.AddProduct("IPHONE X",user);
                this.AddProduct("Magic Mouse",user);
                this.AddProduct("IWATCH SERIES 4",user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            _ = this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(100),
                IsAvailable = true,
                Stock = this.random.Next(100),
                user=user
            });
        }
    }



    }

