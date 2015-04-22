using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataSources
{
     class Program
    {
        public static void Main(string[] args)
        {
            int words = 0;
            Counter c = new Counter();
            Console.WriteLine("Overloads");
            words = c.CountWords(SourceType.randomstring, " this is a test ");
            words = c.CountWords(SourceType.file, "Textfile1.txt");
            words = c.CountWords(SourceType.url, "http://www.yahoo.com");
            words = c.CountWords(new FileInfo("Textfile1.txt"));

            Console.WriteLine("**********************************************");
            Console.WriteLine("Inheritance");
            Console.WriteLine((new FileCounter("Textfile1.txt")).CountWords());
            Console.WriteLine((new StringCounter("this is a test")).CountWords());
            Console.WriteLine((new URLCounter("http://www.yahoo.com")).CountWords());

            Console.WriteLine("**********************************************");
            Console.WriteLine("Interface");
            Console.WriteLine((new FileCounterInterface("Textfile1.txt")).CountWords());
            Console.WriteLine((new StringCounterInterface("this is a test")).CountWords());
            Console.WriteLine((new URLCounterInterface("http://www.yahoo.com")).CountWords());

            Console.WriteLine("**********************************************");
            Console.WriteLine("Hybrid");
            Console.WriteLine((new FileCounterHybrid("Textfile1.txt")).CountWords());
            Console.WriteLine((new StringCounterHybrid("this is a test")).CountWords());
            Console.WriteLine((new URLCounterHybrid("http://www.yahoo.com")).CountWords());

            Console.WriteLine("**********************************************");
            Console.WriteLine("Hybrid assigning to Base Class");

            BaseCounterHybrid bc = null;

            bc = new FileCounterHybrid("Textfile1.txt");
            Console.WriteLine(bc.CountWords());
            bc = new StringCounterHybrid("this is a test");
            Console.WriteLine(bc.CountWords());
            bc = new URLCounterHybrid("http://www.yahoo.com");
            Console.WriteLine(bc.CountWords());

            Console.WriteLine("**********************************************");
            Console.WriteLine("Interface Calling through Base Interface");
            BaseCounterInterface bci = null;

            bci = new FileCounterInterface("Textfile1.txt");
            Console.WriteLine(bci.CountWords());
            bci = new StringCounterInterface("this is a test");
            Console.WriteLine(bci.CountWords());
            bci = new URLCounterInterface("http://www.yahoo.com");
            Console.WriteLine(bci.CountWords());

            //Console.WriteLine("**********************************************");
            //Console.WriteLine("Requires settting of base class or base class interface objects to null to throw expected expection to something");
            //try
            //{
            //    bci = null;
            //    Console.WriteLine(bci.CountWords());
            //}
            //catch (Exception)
            //{

            //    Console.WriteLine("Expected exception thrown");
            //}
            //try
            //{
            //    bc  = null;
            //    Console.WriteLine(bci.CountWords());
            //}
            //catch (Exception)
            //{

            //    Console.WriteLine("Expected exception thrown");
            //}
          
            Console.ReadLine();
        }
    }














}
