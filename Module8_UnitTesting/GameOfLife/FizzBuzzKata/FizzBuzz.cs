using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzKata
{
    public class FizzBuzz
    {
        public string CheckForFizzBuzz(int number)
        {
            string result = string.Empty;

                if (number % 3 == 0 && number % 5 == 0)
                {
                    result = "FizzBuzz";
                }
                else if (number % 3 == 0)
                {
                    result = "Fizz";
                }
                else if (number % 5 == 0)
                {
                    result = "Buzz";
                }
                else
                {
                    result = number.ToString();
                }

            return result;
        }
    }
}
