using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter a message");
            string str = Console.ReadLine();
            Console.WriteLine($"First character of the message: {PrintFirstCharOfStr(str)}" );
        }
        public static char PrintFirstCharOfStr(string userInput)
        {
            try
            {
                if (IsEmpty(userInput))
                    throw new ArgumentException("User input is empty");
                return userInput[0];
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return default(char);
            }
            finally
            {
                Console.WriteLine("Operation completed");
            }
        }
        public static bool IsEmpty(string userInput)
        {
            if (userInput == string.Empty)
            {
                return true;
            }
            else
                return false;
        }
    }
}