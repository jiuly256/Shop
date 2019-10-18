
namespace Shop.Web.Data
{

    using Microsoft.AspNetCore.Identity;
    using Shop.Web.Data.Entities;
    using Shop.Web.Helpers;
    using System;
    using System.Linq;
    using System.Threading.Tasks;


    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private readonly Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            // Add user
            var user = await this.userHelper.GetUserByEmailAsync("jiuly256@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Jiuly",
                    LastName = "Rojas",
                    Email = "jiuly256@gmail.com",
                    UserName = "jiuly256@gmail.com",
                    PhoneNumber = "04242179601"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

            // Add products
            if (!this.context.Products.Any())
            {
                this.AddProduct("iPhone X", user);
                this.AddProduct("Magic Mouse", user);
                this.AddProduct("iWatch Series 4", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvailabe = true,
                Stock = this.random.Next(100),
                User = user
            });
        }
    }

}
