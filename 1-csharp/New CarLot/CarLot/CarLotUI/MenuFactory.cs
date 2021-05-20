using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CarLotBL;
using CarLotDL;
using CarLotDL.Entities;

namespace CarLotUI
{
    public class MenuFactory
    {
        public static IMenu GetMenu(string menuType)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            string connectionString = configuration.GetConnectionString("CarLotDB");

            DbContextOptions<PracticeContext> options = new DbContextOptionsBuilder<PracticeContext>()
            .UseSqlServer(connectionString)
            .Options;
            var context = new PracticeContext(options);

            switch (menuType.ToLower())
            {
                case "main":
                    return new MainMenu(new CarBL(new RepoDB(context)), new ValidationService(), new LocationBL(new RepoDB(context)));
                case "login":
                    return new LoginMenu(new CarBL(new RepoDB(context)), new ValidationService());
                case "customer":
                    return new CustomerMenu(new CustomerBL(new RepoDB(context)), new ValidationService());
                case "customertwo":
                    return new CustomerMenuTwo(new CustomerBL(new RepoDB(context)), new ValidationService());
                case "admin":
                    return new AdminMenu(new CarBL(new RepoDB(context)), new ValidationService());
                default:
                    return null;
            }
        }

    }
}