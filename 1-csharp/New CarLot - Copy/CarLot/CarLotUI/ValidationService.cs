using System;

namespace CarLotUI
{
    public class ValidationService : IValidationService
    {
        public int ValidateInt(string prompt)
        {
            int response = 0;
            bool repeat = true;
            do
            {
                Console.WriteLine(prompt);
                try
                {
                    response = Int32.Parse(Console.ReadLine());
                    if (response > -1)
                    {
                        repeat = false;
                    }
                    else
                    {
                        Console.WriteLine("Input must be nonnegative");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter and integer value.");
                }
            } while (repeat);
            return response;
        }
        public string ValidateString(string prompt)
        {
            string response;
            bool repeat;
            do
            {
                Console.WriteLine(prompt);
                response = Console.ReadLine();
                repeat = String.IsNullOrWhiteSpace(response);
                if (repeat) Console.WriteLine("Please input a non empty string");
            } while (repeat);
            return response;
        }
    }
}