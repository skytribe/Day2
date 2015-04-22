using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayExtensions
{
     class Program
    {
        public  static void Main(string[] args)
        {
            string[] headlines = new string[] { "Martians Attack", "blah b;lah blah", "Seahwaks lose" };
            
            // WAS ERROR CONDITIONS TO ASSERT
            //Console.WriteLine((new string[0]).GetRandom());
            //string[] x1 = null;
            //Console.WriteLine(x1.GetRandom());

            Console.WriteLine("*****************************************");
            Console.WriteLine("STRING WITH STRING[] METHOD");
            
            while (true)
            {
                Console.WriteLine(headlines.GetRandomForString());
                Console.WriteLine("Press q to quit");

                if (Console.ReadLine() == "q")
                {
                    break;
                }
            }

            Console.WriteLine("*****************************************");
            Console.WriteLine("INTEGER WITH GENERIC METHOD");
            while (true)
            {
                //Generic Version
                int[] x1a = { 1, 2, 3, 4 };
                var x1r = x1a.GetRandom1();
                Console.WriteLine("{0}", x1r);
                var x2r = x1a.GetRandom1<int>();
                Console.WriteLine("{0}", x2r);
                var x3r = ArrayExtensions.GetRandom1(x1a);
                Console.WriteLine("{0}", x3r);
                var x4r = ArrayExtensions.GetRandom1<int>(x1a);
                Console.WriteLine("{0}", x4r);

                Console.WriteLine("Press q to quit");
                if (Console.ReadLine() == "q")
                {
                    break;
                }
            }
            
            Console.WriteLine("*****************************************");
            Console.WriteLine("STRING WITH GENERIC METHOD");
            while (true)
            {
                //Generic Version
                Console.WriteLine(headlines.GetRandom1());

                Console.WriteLine("Press q to quit");
                if (Console.ReadLine() == "q")
                {
                    break;
                }
            }

            Console.WriteLine("Complete");
            Console.ReadLine();
        }
    }


    
}
