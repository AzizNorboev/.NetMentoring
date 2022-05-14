using System;
using System.Text.RegularExpressions;

namespace Task2
{
    //use regex
    public class NumberParser : INumberParser
    {
        //numbers from 0 to 9 and  + and - signs in the beginning of the string
        Regex regex = new Regex("^[-+]?[0-9]*?[0-9]+$");
        public int Parse(string stringToConvert)
        {
            try
            {
                bool isNegative = false;
                if (stringToConvert == null)
                    throw new ArgumentNullException(nameof(stringToConvert));

                stringToConvert = stringToConvert.Trim();

                if (!regex.IsMatch(stringToConvert))
                    throw new FormatException();

                stringToConvert = ValidateStringForConversion(stringToConvert, ref isNegative);
                var result = ConvertValidatedStringToInt(stringToConvert, isNegative);

                return result;
            }            
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        public int ConvertValidatedStringToInt(string stringToConvert, bool isNegative)
        {
            long result = 0;
            for (int i = 0; i < stringToConvert.Length; i++)
            {
                result *= 10;
                result += stringToConvert[i] - '0';
            }
            if (isNegative)
                result = result * (-1);

            if (result < int.MinValue || result > int.MaxValue)
                throw new OverflowException();
            return (int)result;
        }
        public string ValidateStringForConversion(string stringToConvert,ref bool isNegative)
        {
            for (int i = stringToConvert.Length - 1; i >= 0; i--)
            {
                if (stringToConvert[i] == '-')
                {
                    isNegative = true;
                    stringToConvert = stringToConvert.Replace("-", "");
                }
                else if (stringToConvert[i] == '+')
                    stringToConvert = stringToConvert.Replace("+", "");
            }
            return stringToConvert;
        }
    } 
}