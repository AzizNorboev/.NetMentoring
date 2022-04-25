using System;
using System.Text.RegularExpressions;
using Task2;
using Task3;
using Task3.DoNotChange;

namespace ConsoleApp1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            NumberParser numberParser = new NumberParser();

            //To Check regex. Only last value in the array matches the regex
            //TODO: Delete it after verifying if regex is working as expected
            Regex regex = new Regex("^[-+]?[0-9]*?[0-9]+$");
            string[] strings =
            {"112","", "  ", "1,390,146","$190,235,421,127","0xFA1B","0xFA1B","16e07","134985.0",
                "-+12034","+-12034","0-12034","-00234"
            };
            try
            {
                foreach (string s in strings)
                {
                    if (!regex.IsMatch(s))
                    {
                        Console.WriteLine(numberParser.Parse(s));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Console.WriteLine("Operation completed");
            }
            Console.ReadLine();
        }
    }
    
}
