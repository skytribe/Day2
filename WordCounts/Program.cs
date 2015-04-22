using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounts
{
     class Program
    {
        public static void Main(string[] args)
        {
            Debug.Assert(Counter.CountWords("Hello World") == 2, "Invalid return expected");
            Debug.Assert(Counter.CountWords("The Cat in the Hat") == 5, "Invalid return expected");
            Console.WriteLine(Counter.CountWords("Hello World"));
            Console.ReadLine();
        }
    }
     class Counter
    {

        public static int CountWords(string sentence)
        {
            char[] chrArray = new char[] { ' ' };
            return sentence.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).Count<string>();
        }
    }
}
