using System;
using System.Collections.Generic;
namespace covariance_and_contravariance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Derived.Main1();
        }
    }
    class Base
    {
        public static void PrintBases(IEnumerable<Base> bases)
        {
            foreach (Base b in bases)
            {
                Console.WriteLine(b);
            }
        }
    }

    class Derived : Base
    {
        public static void Main1()
        {
            List<Derived> dlist = new List<Derived>();

            Derived.PrintBases(dlist);
            IEnumerable<Base> bIEnum = dlist;
        }
    }
}
