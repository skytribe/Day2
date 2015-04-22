using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
     class Employee
    {
        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public Employee()
        {
        }

        public string ShowFullname()
        {
            return string.Concat(this.FirstName, " ", this.LastName);
        }
    }

     class FullTimeEmployee : Employee
    {
        public int YearsEmployed
        {
            get;
            set;
        }
    }

     class PartTimeEmployee : Employee
    {
        public int MonthsEmployed
        {
            get;
            set;
        }
    }

     class Program
    {
        public static void Main(string[] args)
        {
            FullTimeEmployee fullTimeEmployee = new FullTimeEmployee()
            {
                FirstName = "Bill",
                LastName = "Gates",
                YearsEmployed = 40
            };
            FullTimeEmployee x1 = fullTimeEmployee;
            PartTimeEmployee partTimeEmployee = new PartTimeEmployee()
            {
                FirstName = "Steve",
                LastName = "Jobs",
                MonthsEmployed = 2
            };
            PartTimeEmployee x2 = partTimeEmployee;
            Debug.Assert(x1.ShowFullname() == "Bill Gates", "Incorrect name");
            Debug.Assert(x2.ShowFullname() == "Steve Jobs", "Incorrect name");
            Console.WriteLine(x1.ShowFullname());
            Console.WriteLine(x2.ShowFullname());
            Console.WriteLine("Press Any Key To Finish");
            Console.ReadLine();
        }
    }
}
