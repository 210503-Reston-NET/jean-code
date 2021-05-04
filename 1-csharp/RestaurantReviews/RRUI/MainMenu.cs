namespace RRUI
{
    public class MainMenu
    {
        public void Start(){

            bool repeat = true;
            do{
            Console.WriteLine("Welcome to my Restaurant Reviews Application!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[0] add a restaurant");
            console.WriteLine("[1] Exit");
            string input = Console.Readline();
            switch(input)
            {
                case "0":
                    ViewRestaurant()
                    break;
                case "1":

                    break;
                default:
                    Console.WriteLine("Please input a valid option");

            }
            } while (repeat);
        }
        private void ViewRestaurant()
        {
            Restaurant goodTaste = new Restaurant("Good Taste", "Baguio City", "Benguet");
            goodTaste.Review = new Review
            {
                Rating = 5,
                Description = "A M A Z I N G"
            };
            Console.WriteLine(goodTaste.ToString());
        }
    }
}
