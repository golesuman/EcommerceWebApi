using EcommerceWebApi.Data;
using EcommerceWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApi.Services
{
    public static class SeedData
    {
        public async static void SeedDatabase(EcommerceDbContext context)
        {
            await context.Database.MigrateAsync();

            if (context.Users.Count() == 0 || context.Users.Count() == 0)
            {
                List<User> users = new();

                User user1 = new()
                {
                    Username = "User1",
                    Email = "contact@gmail.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("User1234@"),

                };

                User user2 = new()
                {

                    Username = "Test",

                    Email = "test@example.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("EmployeeUser1234"),
                };

                users.Add(user1);
                users.Add(user2);
                await context.Users.AddRangeAsync(users);
                await context.SaveChangesAsync();
            }
        }
    }
}