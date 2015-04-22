using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyMaths
{
     class Program
    {

        public static void Main(string[] args)
        {
            Math m = new Math();
            int result = 0;
            int[] numArray = new int[] { 6, 2 };
            result = m.DoSomething(numArray);
            numArray = new int[] { 6, 2 };
            Debug.Assert(m.DoSomething(numArray) == 3, "This is wrong 2 params");
            numArray = new int[] { 3, 3, 3 };
            Debug.Assert(m.DoSomething(numArray) == 9, "This is wrong 3 params");
            numArray = new int[] { 2, 2, 2, 2 };
            Debug.Assert(m.DoSomething(numArray) == 16, "This is wrong 4 params");
            Console.WriteLine("Complete");
            Console.ReadLine();
        }
    }
     class Math
    {
        public int DoSomething(params int[] values)
        {
            int result = 0;
            if ((int)values.Length == 2)
            {
                result = values[0] / values[1];
            }
            else if ((int)values.Length == 3)
            {
                result = values[0] + values[1] + values[2];
            }
            else if ((int)values.Length == 4)
            {
                result = values[0] * values[1] * values[2] * values[3];
            }
            return result;
        }
    }
}
