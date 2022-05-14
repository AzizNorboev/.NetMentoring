using System;
using System.Collections.Generic;

namespace DictionaryReplacerKata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DictionaryReplacer dictionaryReplacer = new DictionaryReplacer();
            var dict = new Dictionary<string, string>
            {
                ["temp"] = "temporary",
                ["name"] = "John Doe"
            };
            try
            {
                var result = dictionaryReplacer.ReplaceWordsCorrespondingValue("$temp$ here comes the name $name$", dict);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
