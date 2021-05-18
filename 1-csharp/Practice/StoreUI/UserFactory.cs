using StoreBL;
using StoreDL;

namespace StoreUI
{
    public class UserFactory
    {
        public static IMenu GetMenu(string menuType)
        {
            switch(menuType.ToLower())
            {
                case "main":
                    return new menu();
                case "login":
                    return new LoginMenu();
                case "admin":
                    // return new AdminMenu(new ItemBL(new RepoFile()), new ValidationService());
                    return new AdminMenu();
                case "user":
                    // return new AdminMenu();
                    // return new CustMenu(new CustBL(new RepoFile()), new ValidationService());
                default:
                    return null;
            }
        }
    }
}