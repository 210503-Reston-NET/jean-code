using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CarLotBL;
using CarLotDL;
using CarLotDL.Entities;

namespace CarLotUI
{
    /// <summary>
    /// Class to menufacture menus using factory dp
    /// </summary>
    public class MenuFactory
    {
        public static IMenu GetMenu(string menuType)
        {
            //getting configurations from a config file
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            //setting up my db connections
            string connectionString = configuration.GetConnectionString("CarLotDB");
            //we're building the dbcontext using the constructor that takes in options, we're setting the connection
            //string outside the context def'n
            DbContextOptions<PracticeContext> options = new DbContextOptionsBuilder<PracticeContext>()
            .UseSqlServer(connectionString)
            .Options;
            //passing the options we just built
            var context = new PracticeContext(options);

            switch (menuType.ToLower())
            {
                case "main":
                    return new MainMenu(new CarBL(new RepoDB(context)), new ValidationService());
                            //To do: implement validation service add implementation here
                   // return new MainMenu(new CarBL(new RepoDB(context)),);
                //    return null;
                case "login":
                    return new LoginMenu(new CarBL(new RepoDB(context)), new ValidationService());
                case "customer":
                    return new CustomerMenu(new CarBL(new RepoDB(context)), new ValidationService());
                default:
                    return null;
            }
        }

    }
}