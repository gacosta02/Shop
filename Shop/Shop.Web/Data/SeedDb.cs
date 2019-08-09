
namespace Shop.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Entities;
    using Helpers;

    public class SeedDb //Alimentacion de la BD
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private readonly UserManager<User> userManager;
        private Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("gacosta.com.do@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Gabriel",
                    LastName = "Acosta",
                    Email = "gacosta.com.do@gmail.com",
                    UserName = "gacosta.com.do@gmail.com"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");

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

