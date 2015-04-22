using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalInterfaces
{
     class Program
    {
        public Program()
        {
        }

        private static void Main(string[] args)
        {
            Bear x = new Bear();
            Debug.Assert(x.Name == "Bear", "Invalid Name for Bear");
            Debug.Assert(AnimalUtility.DoSomething(x) == "Roar", "Invalid Sound for Bear");
            Chicken x1 = new Chicken();
            Debug.Assert(x1.Name == "Chicken", "Invalid Name for Chicken");
            Debug.Assert(AnimalUtility.DoSomething(x1) == "Cluck", "Invalid Sound for Chicken");
            Eagle x2 = new Eagle();
            Debug.Assert(x2.Name == "Eagle", "Invalid Name for Eagle");
            Debug.Assert(AnimalUtility.DoSomething(x2) == "Chirp", "Invalid Sound for Eagle");
            Eagle2 x3 = new Eagle2();
            Debug.Assert(x3.Name == "Eagle2", "Invalid Name for Eagle");
            Debug.Assert(AnimalUtility.DoSomething(x3) == "Chirp Flap Flap Flap", "Invalid Sound for Eagle");
            AnimalUtility.DoSomething(x3);
            Console.WriteLine("Complete");
            Console.ReadLine();
        }
    }

     interface AnimalInterface
    {
        string Name
        {
            get;
            set;
        }

        string MakeSound();
    }
     class AnimalUtility
    {
     
        public static string DoSomething(AnimalInterface animal)
        {
            string s = animal.MakeSound();
            if (animal is IBird)
            {
                s = string.Concat(s, " Flap Flap Flap");
            }
            Console.WriteLine(s);
            return s;
        }
    }
     class Bear : AnimalInterface
    {
        public string Name
        {
            get;
            set;
        }

        public Bear()
        {
            this.Name = "Bear";
        }

        public string MakeSound()
        {
            return "Roar";
        }
    }

     class Chicken : AnimalInterface
    {
        public string Name
        {
            get;
            set;
        }

        public Chicken()
        {
            this.Name = "Chicken";
        }

        public string MakeSound()
        {
            return "Cluck";
        }
    }

     class Eagle : AnimalInterface
    {
        public string Name
        {
            get;
            set;
        }

        public Eagle()
        {
            this.Name = "Eagle";
        }

        public string MakeSound()
        {
            return "Chirp";
        }
    }

     class Eagle2 : IBird, AnimalInterface
    {
        public string Name
        {
            get;
            set;
        }

        public Eagle2()
        {
            this.Name = "Eagle2";
        }

        public string MakeSound()
        {
            return "Chirp";
        }
    }

     interface IBird : AnimalInterface
    {

    }
}
